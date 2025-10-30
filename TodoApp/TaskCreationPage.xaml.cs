using TodoApp.ViewModels;

namespace TodoApp;

public partial class TaskCreationPage : ContentPage
{
	public TaskCreationPage(TaskCreationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}