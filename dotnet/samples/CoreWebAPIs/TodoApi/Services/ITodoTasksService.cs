using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoTasksService
    {
        Task<List<TodoTask>> GetAsync();
        Task<TodoTask?> GetAsync(string id);
        Task CreateAsync(TodoTask newTodoTask);
        Task UpdateAsync(string id, TodoTask updatedTodoTask);
        Task RemoveAsync(string id);
    }
}
