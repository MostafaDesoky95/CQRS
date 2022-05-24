using CQRS.Data;
using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services.EventService
{
    public class EventService : IEventService
    {
        private readonly DBContext _context;

        public EventService(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetEventsList()
        {
            return await _context.Events
                .ToListAsync();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _context.Events
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Event> CreateEvent(Event model)
        {
            _context.Events.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<int> UpdateEvent(Event model)
        {
            _context.Events.Update(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEvent(Event model)
    {
            _context.Events.Remove(model);
            return await _context.SaveChangesAsync();
        }
    }
}
