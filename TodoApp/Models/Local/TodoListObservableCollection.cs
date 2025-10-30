using System.Collections.ObjectModel;

namespace TodoApp.Models.Local
{
    public class TodoListObservableCollection : ObservableCollection<TodoEntity>
    {
        public string SectionTitle { get; set; } = string.Empty;
        public TodoListObservableCollection(List<TodoEntity> todos): base(todos) { }
    }
}
