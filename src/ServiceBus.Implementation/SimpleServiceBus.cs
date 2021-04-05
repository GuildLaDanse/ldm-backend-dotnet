using LaDanse.ServiceBus.Abstractions;

namespace LaDanse.ServiceBus.Implementation
{
    public class SimpleServiceBus : IServiceBus
    {
        public IQueue GetQueue(string queueName)
        {
            return new DummyQueue();
        }

        public ITopic GetTopic(string topicName)
        {
            return new DummyTopic();
        }
    }
}