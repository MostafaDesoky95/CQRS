using CQRS.Features.Categories.Query;
using CQRS.Features.CategoryEvent.Command;
using CQRS.Features.Events.Commands;
using CQRS.Features.Events.Queries;
using CQRS.Features.PhotoAlbums.Queries;
using CQRS.Features.Photos.Queries;
using CQRS.Features.Sources.Queries;
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
            ViewBag.Albums = _mediator.Send(new GetAllPhotoAlbumsQuery()).Result;
            ViewBag.Sources= _mediator.Send(new GetAllSourcesQuery()).Result;
            ViewBag.Photos= _mediator.Send(new GetAllPhotosQuery()).Result;
            ViewBag.Categories= _mediator.Send(new GetAllCategoriesQuery()).Result;

            try
            {
                if (ModelState.IsValid)
                {
                    var model = await _mediator.Send(command);
                    command.categories.ForEach(x =>
                    {
                        _mediator.Send(new CreateCategoryEventCommand()
                        {
                            CategoriesID = x,
                            EventsID = model.ID
                        });
                    });
                    
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Albums = _mediator.Send(new GetAllPhotoAlbumsQuery()).Result;
            ViewBag.Sources = _mediator.Send(new GetAllSourcesQuery()).Result;

            ViewBag.Photos = _mediator.Send(new GetAllPhotosQuery()).Result;
            return View(await _mediator.Send(new GetEventByIdQuery() { ID = id }));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEventCommand command)
        {

            if (id != command.ID)
            {
                return BadRequest();
            }

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
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteEventCommand() { ID = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
