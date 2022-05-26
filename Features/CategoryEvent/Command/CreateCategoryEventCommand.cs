using MediatR;

namespace CQRS.Features.CategoryEvent.Command
{
    public class CreateCategoryEventCommand : IRequest<Models.CategoryEvent>
    {
        public int CategoriesID { get; set; }
        public int EventsID { get; set; }

    }
}
