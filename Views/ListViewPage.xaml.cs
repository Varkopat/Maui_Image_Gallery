using MauiProject.ViewModels;

namespace MauiProject.Views;

public partial class ListViewPage : ContentPage
{
	public ListViewPage()
	{
		InitializeComponent();
        BindingContext = new ListViewModel();
    }
}