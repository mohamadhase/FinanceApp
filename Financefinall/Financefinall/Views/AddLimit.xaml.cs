using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Financefinall.Models;
using Financefinall.ViewModels;

namespace Financefinall.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLimit : ContentPage
    {
        public AddLimit(Category cat) 
        {
            InitializeComponent();
            BindingContext = new AddLimitViewModel(cat);
        }
    }
}