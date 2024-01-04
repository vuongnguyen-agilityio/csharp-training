using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoTasksService : ITodoTasksService
    {
        private readonly IMongoCollection<TodoTask> _todoTasksCollection;

        public TodoTasksService(
            IOptions<TodoDatabaseSettings> TodoDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                TodoDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                TodoDatabaseSettings.Value.DatabaseName);

            _todoTasksCollection = mongoDatabase.GetCollection<TodoTask>(
                TodoDatabaseSettings.Value.TasksCollectionName);
        }

        public async Task<List<TodoTask>> GetAsync() =>
            await _todoTasksCollection.Find(_ => true).ToListAsync();

        public Task<TodoTask> GetAsync(string id) =>
            Task.FromResult(_todoTasksCollection.Find(x => x.Id == id).FirstOrDefault());

        public async Task CreateAsync(TodoTask newTodoTask) =>
            await _todoTasksCollection.InsertOneAsync(newTodoTask);

        public async Task UpdateAsync(string id, TodoTask updatedTodoTask) =>
            await _todoTasksCollection.ReplaceOneAsync(x => x.Id == id, updatedTodoTask);

        public async Task RemoveAsync(string id) =>
            await _todoTasksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
