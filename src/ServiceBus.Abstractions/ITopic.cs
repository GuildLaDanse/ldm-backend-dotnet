namespace LaDanse.ServiceBus.Abstractions
{
    public interface ITopic
    {
        public void SendMessage(string content);
    }
}