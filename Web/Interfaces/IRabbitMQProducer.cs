namespace Web.Interfaces
{
    public interface IRabbitMQProducer
    {
        void SendMessage<T>(T message);
    }
}
