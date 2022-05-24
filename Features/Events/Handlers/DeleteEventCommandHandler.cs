using CQRS.Features.Events.Commands;
using CQRS.Services.EventService;
using MediatR;

namespace CQRS.Features.Events.Handlers
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, int>
    {
        private readonly IEventService _eventService;

        public DeleteEventCommandHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<int> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var model = await _eventService.GetEventById(request.ID);
            if (model == null)
                return default;
            return await _eventService.DeleteEvent(model);
        }
    }
}
