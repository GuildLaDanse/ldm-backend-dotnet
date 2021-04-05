namespace LaDanse.ServiceBus.Abstractions
{
    public interface IQueue
    {
        public void SendMessage(string content);
    }
}