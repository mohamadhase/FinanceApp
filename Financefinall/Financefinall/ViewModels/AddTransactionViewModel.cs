using Financefinall.Models;
using Financefinall.Services;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;

namespace Financefinall.ViewModels
{
    class AddTransactionViewModel: BindableObject
    {
        public ICommand SaveBudget
        {
            get
            {
                return new Command((e) =>
                {
                

                });
            }
        }
        public ICommand CancelButton
        {
            get
            {
                return new Command((e) =>
                {
                    Application.Current.MainPage.Navigation.PopAsync();

                });
            }
        }
    }
}
