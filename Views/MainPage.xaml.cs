using MauiProject.ViewModels;

namespace MauiProject.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

    }

}
