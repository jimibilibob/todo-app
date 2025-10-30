using TodoApp.ViewModels;

namespace TodoApp
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            viewModel = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadTodosCommand.Execute(default);
        }
    }
}
