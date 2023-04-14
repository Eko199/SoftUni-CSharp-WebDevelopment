using Microsoft.AspNetCore.Mvc;

namespace Eventmi.Controllers
{
    using Core.Models;
    using Core.Services.Contracts;

    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var events = await _eventService.GetAllAsync();

            return View(events);
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(EventFormModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Error", "Home");

            await _eventService.AddAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            EventFormModel eventModel = await _eventService.GetByIdAsync(id);

            return View(eventModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EventFormModel eventModel = await _eventService.GetByIdAsync(id);

            return View(eventModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Error", "Home");

            await _eventService.UpdateAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.DeleteAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
