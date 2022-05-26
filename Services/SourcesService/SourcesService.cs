using CQRS.Data;
using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services.SourcesService
{
    public class SourcesService : ISourceService
    {
        private readonly DBContext _context;

        public SourcesService(DBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Source>> GetSourcesList()
        {
            return await _context.Sources
                .ToListAsync();
        }

    }
}
