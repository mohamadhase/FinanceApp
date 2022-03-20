using Financefinall.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Financefinall.Views
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