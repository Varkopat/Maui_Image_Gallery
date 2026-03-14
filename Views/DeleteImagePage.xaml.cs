using MauiProject.ViewModels;

namespace MauiProject.Views;

public partial class DeleteImagePage : ContentPage
{
	public DeleteImagePage()
	{
        InitializeComponent();
        BindingContext = new ListViewModel();
    }
}