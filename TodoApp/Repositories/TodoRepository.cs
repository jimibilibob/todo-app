using SQLite;
using TodoApp.Data;
using TodoApp.Models.Local;

namespace TodoApp.Repositories
{
    public class TodoRepository : IRepository
    {
        private SQLiteAsyncConnection _database;
        public TodoRepository(Database database)
        {
            _database = database.GetConnection();
        }
        public async Task<int> DeleteTodoAsync(TodoEntity todo)
        {
            return await _database.DeleteAsync(todo);
        }

        public async Task<List<TodoEntity>> GetAllAsync()
        {
            return await _database.Table<TodoEntity>().ToListAsync();
        }

        public async Task<List<TodoEntity>> GetCompletedTodosAsync()
        {
            return await _database.Table<TodoEntity>().Where(t => t.IsCompleted).ToListAsync();
        }

        public async Task<List<TodoEntity>> GetPendingTodosAsync()
        {
            return await _database.Table<TodoEntity>().Where(t => !t.IsCompleted).ToListAsync();
        }

        public async Task<int> SaveTodoAsync(TodoEntity todo)
        {
            if(todo.Id == 0)
                return await _database.InsertAsync(todo);

            return await _database.UpdateAsync(todo);
        }
    }
}
