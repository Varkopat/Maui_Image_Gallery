using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiProject.Models;


namespace MauiProject.ViewModels
{
    internal partial class AddImageViewModel : ObservableObject
    {

        [ObservableProperty]
        private string? inputTitle;

        [ObservableProperty]
        private string? inputPath;


        [RelayCommand]
        public async Task BackBtn()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        [RelayCommand]
        public async Task Submit()
        {
            if (InputTitle != null || InputPath != null)
            {
                var image = new ImageView
                {
                    Title = InputTitle,
                    Path = InputPath
                };

                await DataRepository.SaveImageAsync(image);

                WeakReferenceMessenger.Default.Send(new MyMessage("Refresh"));
            }
            return;
        }
    }
}
