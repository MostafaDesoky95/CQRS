using CQRS.Features.CategoryEvent.Command;
using CQRS.Services.EventCategoryService;
using MediatR;

namespace CQRS.Features.CategoryEvent.Handlers
{
    public class CreateCategoryEventCommandHandler : IRequestHandler<CreateCategoryEventCommand, Models.CategoryEvent>
    {
        private readonly IEventCategoryService _eventCategoryService;

        public CreateCategoryEventCommandHandler(IEventCategoryService eventCategoryService)
        {
            _eventCategoryService = eventCategoryService;
        }

        public async Task<Models.CategoryEvent> Handle(CreateCategoryEventCommand request, CancellationToken cancellationToken)
        {
            return await _eventCategoryService.Add(request.EventsID, request.CategoriesID);
        }
    }
}
