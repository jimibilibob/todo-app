using SQLite;
using TodoApp.Models.Local;

namespace TodoApp.Data
{
    public class  Database
    {
        private readonly SQLiteAsyncConnection _connection;
        public Database() {
            var flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "todoDB.db3"), flags);
            _connection.CreateTableAsync<TodoEntity>();
        }

        public SQLiteAsyncConnection GetConnection() => _connection;
    }
}
