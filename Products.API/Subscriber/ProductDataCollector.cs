using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using Products.Application.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Products.API.Subscriber
{
    public class ProductDataCollector : IHostedService
    {
        private readonly ISubscriber subscriber;

        public IUnitOfWork UnitOfWork;

        public ProductDataCollector(ISubscriber subscriber, IUnitOfWork unitOfWork)
        {
            this.subscriber = subscriber;
            UnitOfWork = unitOfWork;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            subscriber.Subscribe( processMessage);
            return Task.CompletedTask;
        }

        bool processMessage(string message, IDictionary<string,object> header)
        {
            var Products = JsonConvert.DeserializeObject<List<ProductInfo>>(message);

            foreach (var product in Products) 
            {
                UnitOfWork.GetProductRepository.DecreaseAmount(product.ProductId, product.Amount);
            }

            return UnitOfWork.SaveChanges();
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    class ProductInfo
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
