using CQRS.Features.Photos.Queries;
using CQRS.Services.PhotoService;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS.Features.Photos.Handlers
{
    public class GetAllPhotosQueryHandler : IRequestHandler<GetAllPhotosQuery, IEnumerable<SelectListItem>>
    {
        private readonly IPhotoService _photoService;
        [Obsolete]
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public GetAllPhotosQueryHandler(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public async Task<IEnumerable<SelectListItem>> Handle(GetAllPhotosQuery request, CancellationToken cancellationToken)
        {
            var result = await _photoService.GetPhotosList();
            return result.Select(a => new SelectListItem
            {
                Value = a.ID.ToString(),
                Text = a.URL
        
        });
        }
 
    }
}
