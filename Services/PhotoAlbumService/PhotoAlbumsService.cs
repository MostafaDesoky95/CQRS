using CQRS.Data;
using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services.PhotoAlbumService
{
    public class PhotoAlbumsService : IPhotoAlbumsService
    {
        private readonly DBContext _context;

        public PhotoAlbumsService(DBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsList()
        {
            return await _context.PhotoAlbums
                .ToListAsync();
        }

    }
}
