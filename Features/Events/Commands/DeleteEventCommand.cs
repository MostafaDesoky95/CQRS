using MediatR;

namespace CQRS.Features.Events.Commands
{
    public class DeleteEventCommand : IRequest<int>
    {
        public int ID { get; set; }
    }
}
