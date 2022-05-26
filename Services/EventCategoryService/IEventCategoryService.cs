using CQRS.Models;

namespace CQRS.Services.EventCategoryService
{
    public interface IEventCategoryService
    {
        Task<CategoryEvent> Add(int EventID, int CateogryID);
    }
}