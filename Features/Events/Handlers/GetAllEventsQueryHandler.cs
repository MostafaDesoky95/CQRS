using CQRS.Features.Events.Queries;
using CQRS.Models;
using CQRS.Services.EventService;
using MediatR;

namespace CQRS.Features.Events.Handlers
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<Event>>
    {
        private readonly IEventService _eventService;

        public GetAllEventsQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IEnumerable<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return await _eventService.GetEventsList();
        }
    }
}
