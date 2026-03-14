using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiProject.ViewModels
{
    internal partial class AboutViewModel
    {
        public string AppVersion => "1.0.0";
        public string AppName => "Maui Image Gallery";
        public string AppDescription => "A simple image gallery application built with .NET MAUI";
        public string DeveloperInfo => "Developed with .NET 8";

        [RelayCommand]
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
