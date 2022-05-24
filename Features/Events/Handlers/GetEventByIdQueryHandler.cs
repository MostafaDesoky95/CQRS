using CQRS.Features.Events.Queries;
using CQRS.Models;
using CQRS.Services.EventService;
using MediatR;

namespace CQRS.Features.Events.Handlers
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Event>
    {
        private readonly IEventService _eventService;

        public GetEventByIdQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public Task<Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
           return _eventService.GetEventById(request.ID);
        }
    }
}
