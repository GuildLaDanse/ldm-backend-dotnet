namespace LaDanse.ServiceBus.Abstractions
{
    public interface IServiceBus
    {
        public IQueue GetQueue(string queueName);

        public ITopic GetTopic(string topicName);
    }
}