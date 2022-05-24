using CQRS.Features.Events.Commands;
using CQRS.Models;
using CQRS.Services.EventService;
using MediatR;

namespace CQRS.Features.Events.Handlers
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Event>
    {
        private readonly IEventService _eventService;

        public CreateEventCommandHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var model = new Event()
            {
                ArabicTitle = request.ArabicTitle,
                EnglishTitle = request.EnglishTitle,
                Content = request.Content,
                Address = request.Address,
                CoverPhotoID = request.CoverPhotoID,
                EndDate = request.EndDate,
                PhotoAlbumID = request.PhotoAlbumID,
                SourceID = request.SourceID,
                StartDate = request.StartDate
            };
            return await _eventService.CreateEvent(model);
        }
    }
}
