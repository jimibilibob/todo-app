using TodoApp.Models.Local;

namespace TodoApp.Repositories
{
    public interface IRepository
    {
        public Task<List<TodoEntity>> GetAllAsync();

        public Task<List<TodoEntity>> GetPendingTodosAsync();

        public Task<List<TodoEntity>> GetCompletedTodosAsync();

        public Task<int> SaveTodoAsync(TodoEntity todo);

        public Task<int> DeleteTodoAsync(TodoEntity todo);
    }
}
