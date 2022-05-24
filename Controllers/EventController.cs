using CQRS.Features.Events.Commands;
using CQRS.Features.Events.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    public class EventController : Controller
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllEventsQuery()));
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetEventByIdQuery() { ID = id }));
        }
        public async Task<IActionResult> Create(CreateEventCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(command);
        }
    }
}
