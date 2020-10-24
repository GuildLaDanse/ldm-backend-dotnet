using System;
using System.Collections.Generic;
using LaDanse.Application.Events.Models;
using MediatR;

namespace LaDanse.Application.Events.Queries.GetAllEvents
{
    public class GetAllEventsQuery : IRequest<IEnumerable<Event>>
    {
        public GetAllEventsQuery()
        {
        }
    }
}