using CQRS.Models;

namespace CQRS.Services.EventService
{
    public interface IEventService
    {
        Task<Event> CreateEvent(Event model);
        Task<int> DeleteEvent(Event model);
        Task<Event> GetEventById(int id);
        Task<IEnumerable<Event>> GetEventsList();
        Task<int> UpdateEvent(Event model);
    }
}