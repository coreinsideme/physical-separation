namespace Web.Models
{
    internal class RabbitMQConfiguration
    {
        public const string SectionName = "RabbitMQConfiguration";

        public string HostName { get; set; }
        public string Queue { get; set; }
    }
}
