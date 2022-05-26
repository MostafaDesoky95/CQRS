using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS.Features.Photos.Queries
{
    public class GetAllPhotosQuery : IRequest<IEnumerable<SelectListItem>>
    {
    }
}
