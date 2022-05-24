using CQRS.Features.Events.Commands;
using CQRS.Models;
using CQRS.Services.EventService;
using MediatR;

namespace CQRS.Features.Events.Handlers
{
    public class EditEventCommandHandler : IRequestHandler<EditEventCommand, int>
    {
        private readonly IEventService _eventService;

        public EditEventCommandHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<int> Handle(EditEventCommand request, CancellationToken cancellationToken)
        {
            var model = await _eventService.GetEventById(request.ID);
            if (model == null)
                return default;
            model.ArabicTitle = request.ArabicTitle;
            model.EnglishTitle = request.EnglishTitle;
            model.Content = request.Content;
            model.Address = request.Address;
            model.CoverPhotoID = request.CoverPhotoID;
            model.EndDate = request.EndDate;
            model.PhotoAlbumID = request.PhotoAlbumID;
            model.SourceID = request.SourceID;
            model.StartDate = request.StartDate;

            return await _eventService.UpdateEvent(model);
        }
    }
}
