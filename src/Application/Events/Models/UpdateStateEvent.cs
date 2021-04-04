namespace LaDanse.Application.Events.Models
{
    public record UpdateStateEvent
    {
        public string OldState { get; init; }
        
        public string NewState { get; init; }
    }
}