using MauiProject.ViewModels;

namespace MauiProject.Views;

public partial class AddImagePage : ContentPage
{
	public AddImagePage()
	{
		InitializeComponent();
        BindingContext = new AddImageViewModel();
    }
}