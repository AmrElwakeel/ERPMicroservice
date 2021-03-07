using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using Orders.DAL.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Orders.BLL.Broker
{
    public class RabbitManager : IRabbitManager
    {
        private readonly DefaultObjectPool<IModel> _objectPool;

        public RabbitManager(IPooledObjectPolicy<IModel> objectPolicy)
        {
            _objectPool = new DefaultObjectPool<IModel>(objectPolicy, Environment.ProcessorCount * 2);
        }

        public void Publish<T>(T message, string exchangeName, string exchangeType, string routeKey)
            where T : class
        {
            if (message == null)
                return;

            var channel = _objectPool.Get();

            try
            {
                channel.ExchangeDeclare(exchangeName, exchangeType, true, false, null);

                var sendBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchangeName, routeKey, properties, sendBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _objectPool.Return(channel);
            }
        }

        public string Consumer(string exchangeName, string exchangeType, string routeKey)
        {
            var channel = _objectPool.Get();

            channel.ExchangeDeclare(exchangeName, exchangeType, true, false, null);

            var Consumer = new EventingBasicConsumer(channel);

            string Msg="";
            Consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                Msg = Encoding.UTF8.GetString(body); 
            };

            return Msg;
        }
    }
}
