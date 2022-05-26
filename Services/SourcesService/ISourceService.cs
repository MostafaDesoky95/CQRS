using CQRS.Models;

namespace CQRS.Services.SourcesService
{
    public interface ISourceService
    {
        Task<IEnumerable<Source>> GetSourcesList();
    }
}