using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS.Features.PhotoAlbums.Queries
{
    public class GetAllPhotoAlbumsQuery : IRequest<IEnumerable<SelectListItem>>
    {
    }
}
