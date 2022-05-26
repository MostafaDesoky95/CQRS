using CQRS.Data;
using CQRS.Models;

namespace CQRS.Services.EventCategoryService
{
    public class EventCategoryService : IEventCategoryService
    {
        private readonly DBContext _context;

        public EventCategoryService(DBContext context)
        {
            _context = context;
        }
        public async Task<CategoryEvent> Add(int EventID,int CateogryID)
        {
            var model = new CategoryEvent()
            {
                EventsID = EventID,
                CategoriesID = CateogryID

            };
            _context.CategoryEvent.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
