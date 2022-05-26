using CQRS.Data;
using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services.PhotoService
{
    public class PhotoService : IPhotoService
    {
        private readonly DBContext _context;

        public PhotoService(DBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Photo>> GetPhotosList()
        {
            return await _context.Photos
                .ToListAsync();
        }

    }
}
