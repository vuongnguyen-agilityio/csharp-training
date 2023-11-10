using JWTAuthentication.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TodoTasksController : ControllerBase
    {
        private readonly TodoTasksService _todoTasksService;

        public TodoTasksController(TodoTasksService todoTasksService) =>
            _todoTasksService = todoTasksService;

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<List<TodoTask>> Get() =>
            await _todoTasksService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TodoTask>> Get(string id)
        {
            var todoTask = await _todoTasksService.GetAsync(id);

            if (todoTask is null)
            {
                return NotFound();
            }

            return todoTask;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoTask newTodoTask)
        {
            await _todoTasksService.CreateAsync(newTodoTask);

            return CreatedAtAction(nameof(Get), new { id = newTodoTask.Id }, newTodoTask);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TodoTask updatedTodoTask)
        {
            var todoTask = await _todoTasksService.GetAsync(id);

            if (todoTask is null)
            {
                return NotFound();
            }

            updatedTodoTask.Id = todoTask.Id;

            await _todoTasksService.UpdateAsync(id, updatedTodoTask);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var todoTask = await _todoTasksService.GetAsync(id);

            if (todoTask is null)
            {
                return NotFound();
            }

            await _todoTasksService.RemoveAsync(id);

            return NoContent();
        }
    }
}
