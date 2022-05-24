using CQRS.Models;
using MediatR;

namespace CQRS.Features.Events.Queries
{
    public class GetAllEventsQuery : IRequest<IEnumerable<Event>>
    {
    }
}
