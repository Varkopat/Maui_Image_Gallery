using MauiProject.ViewModels;

namespace MauiProject.Views;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
        BindingContext = new AboutViewModel();
    }
}
