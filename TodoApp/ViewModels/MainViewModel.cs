
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TodoApp.Models.Local;
using TodoApp.Repositories;

namespace TodoApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        IRepository _todoRepository;

        [ObservableProperty]
        ObservableCollection<TodoListObservableCollection> groupedItems;

        public MainViewModel(IRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [RelayCommand]
        async Task LoadTodos()
        {
            var pendingTodos = await _todoRepository.GetPendingTodosAsync();
            var completedTodos = await _todoRepository.GetCompletedTodosAsync();

            GroupedItems = new ObservableCollection<TodoListObservableCollection>([
                new TodoListObservableCollection(pendingTodos) { SectionTitle = "Pendientes" },
                new TodoListObservableCollection(completedTodos) { SectionTitle = "Completadas" }
                ]);
        }

        [RelayCommand]
        void NavigateToCreationTask()
        {
            Shell.Current.GoToAsync(nameof(TaskCreationPage));
        }

        [RelayCommand]
        async Task DeleteItem(TodoEntity todo)
        {
            await _todoRepository.DeleteTodoAsync(todo);
            if (todo.IsCompleted)
            {
                GroupedItems.Last().Remove(todo);
            }
            else
            {
                GroupedItems.First().Remove(todo);
            }
        }

        [RelayCommand]
        async Task ToggleTodoStatus(TodoEntity todo)
        {
            todo.IsCompleted = !todo.IsCompleted;
            await _todoRepository.SaveTodoAsync(todo);
            if (todo.IsCompleted)
            {
                GroupedItems.Last().Add(todo);
                GroupedItems.First().Remove(todo);
            } else
            {
                GroupedItems.Last().Remove(todo);
                GroupedItems.First().Add(todo);
            }
        }
    }
}
