using CQRS.Models;

namespace CQRS.Services.PhotoAlbumService
{
    public interface IPhotoAlbumsService
    {
        Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsList();
    }
}