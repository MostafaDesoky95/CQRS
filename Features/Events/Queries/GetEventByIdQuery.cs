using CQRS.Models;
using MediatR;

namespace CQRS.Features.Events.Queries
{
    public class GetEventByIdQuery : IRequest<Event>
    {
        public int ID { get; set; } 
    }
}
