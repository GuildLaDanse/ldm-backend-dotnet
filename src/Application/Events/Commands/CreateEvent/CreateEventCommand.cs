using System;
using LaDanse.Application.Events.Models;
using MediatR;

namespace LaDanse.Application.Events.Commands.CreateEvent
{
    public record CreateEventCommand : IRequest<EventCreated>
    {
        public Models.CreateEvent CreateEvent { get; init; }
    }
}