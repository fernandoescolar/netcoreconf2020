using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoApp.Application.Commands;
using TodoApp.Application.Queries;
using TodoApp.Models;

namespace TodoApp.Controllers
{
	public class TasksController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        private const string NotificationMessageKey = "NotificationMessage";

        public TasksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(IndexModelQuery query)
        {
            var model = await _mediator.Send(query);
            model.NotificationMessage = TempData[NotificationMessageKey] as string;
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var model = await _mediator.Send(new EditModelQuery());
            return View("Edit", model);
        }

        public async Task<IActionResult> Edit(EditModelQuery query)
        {
            var model = await _mediator.Send(query);
            if (model.Id == 0)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new AddOrEditCommand();
                _mapper.Map(model, command);
                var result = await _mediator.Send(command);
                if (result.Success)
                {
                    TempData[NotificationMessageKey] = $"Task {(model.IsAdding ? "created" : "updated")}";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, result.ErrorMessage);
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(DeleteModelQuery query)
        {
            var model = await _mediator.Send(query);
            if (model.Id == 0)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new DeleteCommand();
                _mapper.Map(model, command);
                var result = await _mediator.Send(command);
                if (result.Success)
                {
                    TempData[NotificationMessageKey] = "Task deleted";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, result.ErrorMessage);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, bool completed, int? categoryId)
        {
            if (completed)
            {
                var command = new CompleteCommand
                {
                    Id = id,
                };
                await _mediator.Send(command);
                TempData[NotificationMessageKey] = $"Task marked as completed";
            }
            else
            {
                var command = new ResetCommand
                {
                    Id = id,
                };
                await _mediator.Send(command);
                TempData[NotificationMessageKey] = $"Task reset";
            }
            
            return RedirectToAction("Index", categoryId.HasValue ? new { CategoryId = categoryId.Value } : null);
        }
    }
}