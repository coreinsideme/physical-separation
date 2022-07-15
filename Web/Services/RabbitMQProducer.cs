using Microsoft.Extensions.Options;

using Web.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

using Web.Models;

namespace Web.Services
{
    internal class RabbitMQProducer: IRabbitMQProducer
    {
        private RabbitMQConfiguration _rabbitmqConfiguration;

        public RabbitMQProducer(IOptions<RabbitMQConfiguration> configuration)
        {
            _rabbitmqConfiguration = configuration.Value;
        }

        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory() { HostName = _rabbitmqConfiguration.HostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _rabbitmqConfiguration.Queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string jsonMessage = JsonSerializer.Serialize<T>(message);
                var body = Encoding.UTF8.GetBytes(jsonMessage);

                channel.BasicPublish(exchange: "",
                                     routingKey: "price",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
