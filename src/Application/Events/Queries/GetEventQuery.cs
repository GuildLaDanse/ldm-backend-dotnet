using LaDanse.Application.Events.Models;
using MediatR;

namespace LaDanse.Application.Events.Queries
{
    public class GetEventQuery : IRequest<Event>
    {
        public GetEventQuery(string eventId)
        {
            EventId = eventId;
        }
        
        public string EventId { get; }
    }
}