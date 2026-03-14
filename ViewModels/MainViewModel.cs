using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiProject.ViewModels
{
    internal partial class MainViewModel
    {
        [RelayCommand]
        public async Task ListViewBtn()
        {
            await Shell.Current.GoToAsync("//ListView");
        }
        [RelayCommand]
        public async Task AddImageBtn()
        {
            await Shell.Current.GoToAsync("//AddImage");
        }
        [RelayCommand]
        public async Task DeleteBtn()
        {
            await Shell.Current.GoToAsync("//DeleteImage");
        }
        [RelayCommand]
        public async Task AboutBtn()
        {
            await Shell.Current.GoToAsync("//About");
        }
        [RelayCommand]
        public async Task ResetBtn()
        {
            DataRepository.ResetAppData();
            WeakReferenceMessenger.Default.Send(new MyMessage("Refresh"));
        }
    }
}
