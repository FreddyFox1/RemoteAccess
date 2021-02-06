using Client.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Client.Views
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