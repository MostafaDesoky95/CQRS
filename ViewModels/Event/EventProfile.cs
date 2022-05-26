using AutoMapper;

namespace CQRS.ViewModels.Event
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventCreateViewModel, Models.Event>();
        }
    }
}
