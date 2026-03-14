using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiProject.Models;


namespace MauiProject.ViewModels
{
    internal partial class ListViewModel 
    {
        public ImageView SelectedImage { get; set; }
        public ImageCollection Images { get; set; }
        public ListViewModel()
        {
            Images = new ImageCollection();
            InitializeAsync();

            WeakReferenceMessenger.Default.Register<MyMessage>(this, (r, m) =>
            {     
                OnMessageReceived(m.Value);
            });
        }
        /// <summary>
        /// Initializes images for the page
        /// </summary>
        private async void InitializeAsync()
        {
            var output = await DataRepository.GetImagesAsync();
            Images.Collection = output;
        }
        /// <summary>
        /// Event handler for when a message is received
        /// </summary>
        private async void OnMessageReceived(string message)
        {
            await RefreshCollectionAsync();
        }
        /// <summary>
        /// Refreshes the collection
        /// </summary>
        private async Task RefreshCollectionAsync()
        {
            Images.Collection = await DataRepository.GetImagesAsync();
        }
        [RelayCommand]
        public async Task BackBtn()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
        [RelayCommand]
        public async Task DeleteBtn()
        {
            var data = await DataRepository.GetImagesAsync();
            await DataRepository.DeleteImageAsync(SelectedImage);
            WeakReferenceMessenger.Default.Send(new MyMessage("Refresh"));
        }
    }
}
