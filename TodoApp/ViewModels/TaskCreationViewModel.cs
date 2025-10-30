using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoApp.Models.Local;
using TodoApp.Repositories;

namespace TodoApp.ViewModels
{
    public partial class TaskCreationViewModel : ObservableObject
    {
        IRepository _todoRepository;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        string description;

        [ObservableProperty]
        bool isInvalidTitle;

        public TaskCreationViewModel(IRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [RelayCommand]
        async Task CreateTodo() {
            OnTitleChanged(Title);
            if (IsInvalidTitle)
                return;

            await _todoRepository.SaveTodoAsync(new TodoEntity() { Title = Title, Description = Description });
            await AppShell.Current.GoToAsync("..");
        }

        partial void OnTitleChanged(string value)
        {
            IsInvalidTitle = string.IsNullOrEmpty(Title);
        }
    }
}
