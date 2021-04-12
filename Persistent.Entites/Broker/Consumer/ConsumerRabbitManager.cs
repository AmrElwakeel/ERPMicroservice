using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Persistence.Entites;
using Products.Application.Interfaces.IRepositories;
using Products.Application.Interfaces.IUnitOfWork;
using Products.Persistence.Entites.Broker.Models;
using Products.Persistence.Entites.Repositories;
using Products.Persistence.Entites.UOW;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Persistence.Entites.Broker
{
    public class ConsumerRabbitManager : BackgroundService
    {
        private readonly ILogger _logger;
        private IConnection _connection;
        private IModel _channel;
        private readonly RabbitOptions _options;
        private readonly ApplicationDbContext context;

        public ConsumerRabbitManager(ILoggerFactory loggerFactory, IOptions<RabbitOptions> optionsAccs, ApplicationDbContext context)
        {
            _options = optionsAccs.Value;
            this._logger = loggerFactory.CreateLogger<ConsumerRabbitManager>();
            InitRabbitMQ();
            this.context = context;
        }

        private void InitRabbitMQ()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _options.HostName,
                UserName = _options.UserName,
                Password = _options.Password,
                Port = _options.Port,
                VirtualHost = _options.VHost,
            };

            // create connection  
            _connection = factory.CreateConnection();

            // create channel  
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare("amq.topic", ExchangeType.Topic,true,false);
            _channel.QueueDeclare("ERPOrderingQueue", false, false, false, null);
            _channel.QueueBind("ERPOrderingQueue", "amq.topic", "ERPOrderingQueue", null);
            _channel.BasicQos(0, 1, false);

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                // received message  
                var content = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());

                // handle the received message  
                HandleMessage(content);
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            _channel.BasicConsume("ERPOrderingQueue", false, consumer);
            return Task.CompletedTask;
        }

        private void HandleMessage(string content)
        {
            // we just print this message   
            //_logger.LogInformation($"consumer received {content}");
             
            var MsgObj = JsonConvert.DeserializeObject<OrderProductMsgModel>(content); 

            IProductRepository repository = new ProductRepository(context);

            if(MsgObj.AddedOrder)
                repository.DecreaseAmount(MsgObj.ProductId,MsgObj.Amount); 
            else
                repository.IncreaseAmount(MsgObj.ProductId, MsgObj.Amount);
             
        }

        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e) { }
        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerRegistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerShutdown(object sender, ShutdownEventArgs e) { }
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e) { }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
