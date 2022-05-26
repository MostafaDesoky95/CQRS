using CQRS.Features.PhotoAlbums.Queries;
using CQRS.Features.Sources.Queries;
using CQRS.Services.SourcesService;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS.Features.Sources.Handlers
{
    public class GetAllSourcesQueryHanler : IRequestHandler<GetAllSourcesQuery, IEnumerable<SelectListItem>>
    {
        private readonly ISourceService _sourceService;

        public GetAllSourcesQueryHanler(ISourceService sourceService)
        {
            _sourceService = sourceService;
        }

        public async Task<IEnumerable<SelectListItem>> Handle(GetAllSourcesQuery request, CancellationToken cancellationToken)
        {
            var result = await _sourceService.GetSourcesList();
            return result.Select(a => new SelectListItem
                {
                  Value = a.ID.ToString(),
                   Text = a.Name
                 });
        }
    }
}
