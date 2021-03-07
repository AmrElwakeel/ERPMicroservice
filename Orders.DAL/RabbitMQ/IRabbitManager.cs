namespace Orders.DAL.RabbitMQ
{
    public interface IRabbitManager
    {
        void Publish<T>(T message, string exchangeName, string exchangeType, string routeKey)
            where T : class;

        string Consumer(string exchangeName, string exchangeType, string routeKey);
    }
}
