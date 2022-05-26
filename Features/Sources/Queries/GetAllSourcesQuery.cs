using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS.Features.Sources.Queries
{
    public class GetAllSourcesQuery : IRequest<IEnumerable<SelectListItem>>
    {
    }
}
