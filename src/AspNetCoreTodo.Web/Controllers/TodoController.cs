using System.Threading.Tasks;
using AspNetCoreTodo.Core.Services;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            // Get to-do items from database
            var items = await _todoItemService.GetIncompleteItemsAsync();

            // Put items into a model
            var viewModel = new TodoViewModel()
            {
                Items = items
            };

            // Pass the view to a model and render
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if(!await _todoItemService.AddItemAsync(newItem))
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }
    }
}
