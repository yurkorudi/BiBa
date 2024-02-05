using _20240104_BibaMobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace _20240104_BibaMobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}