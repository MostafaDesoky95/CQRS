using CQRS.Models;

namespace CQRS.Services.PhotoService
{
    public interface IPhotoService
    {
        Task<IEnumerable<Photo>> GetPhotosList();
    }
}