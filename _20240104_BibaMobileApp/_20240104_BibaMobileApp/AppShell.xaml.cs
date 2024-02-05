using _20240104_BibaMobileApp.ViewModels;
using _20240104_BibaMobileApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace _20240104_BibaMobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
