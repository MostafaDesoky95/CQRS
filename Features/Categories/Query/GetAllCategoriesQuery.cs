using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS.Features.Categories.Query
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<SelectListItem>>
    {
    }
}
