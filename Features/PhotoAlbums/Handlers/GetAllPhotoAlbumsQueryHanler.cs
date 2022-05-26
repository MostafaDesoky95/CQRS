using CQRS.Features.PhotoAlbums.Queries;
using CQRS.Services.PhotoAlbumService;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS.Features.PhotoAlbums.Handlers
{
    public class GetAllPhotoAlbumsQueryHanler : IRequestHandler<GetAllPhotoAlbumsQuery, IEnumerable<SelectListItem>>
    {
        private readonly IPhotoAlbumsService _photoAlbumsService;

        public GetAllPhotoAlbumsQueryHanler(IPhotoAlbumsService photoAlbumsService)
        {
            _photoAlbumsService = photoAlbumsService;
        }

        public async Task<IEnumerable<SelectListItem>> Handle(GetAllPhotoAlbumsQuery request, CancellationToken cancellationToken)
        {
            var result = await _photoAlbumsService.GetPhotoAlbumsList();
            return result.Select(a => new SelectListItem
                {
                  Value = a.ID.ToString(),
                   Text = a.Title
                 });
        }
    }
}
