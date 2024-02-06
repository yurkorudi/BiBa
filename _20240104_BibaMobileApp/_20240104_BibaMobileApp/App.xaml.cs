//using _20240104_BibaMobileApp.Services;
using _20240104_BibaMobileApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace _20240104_BibaMobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
