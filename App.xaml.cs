using MauiProject.Models;

namespace MauiProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            DataRepository.CheckAppData();
        }
    }
}
