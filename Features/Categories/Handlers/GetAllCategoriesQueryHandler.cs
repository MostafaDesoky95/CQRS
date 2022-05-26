using CQRS.Features.Categories.Query;
using CQRS.Services.CategoryService;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS.Features.Categories.Handlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<SelectListItem>>
    {
        private readonly ICategoryService _categoryService;

        public GetAllCategoriesQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<SelectListItem>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetCategoriesList();
            return result.Select(a => new SelectListItem
            {
                Value = a.ID.ToString(),
                Text = a.Name,
            });
        }
    }
}
