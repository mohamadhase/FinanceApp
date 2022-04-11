using Financefinall.Views;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;
using Financefinall.Models;
using Financefinall.Services;
namespace Financefinall.ViewModels
{
    
    class AddLimitViewModel :BindableObject

    {
        public Category Cat;
        public LimitsService limitService;
        public AddLimitViewModel(Category cat)
        {
            Console.WriteLine(cat);
            Console.WriteLine("hi");
            Cat = new Category(cat);
            limitService = new LimitsService();

        }
        public int _BudgetLimit;
        public int BudgetLimit
        {
            get { return _BudgetLimit; }
            set
            {
                _BudgetLimit = value;
                OnPropertyChanged();
            }
        }
        public ICommand SaveBudget
        {
            get
            {
                return new Command( (e) =>
                {
                    Limit limit = new Limit();
                    limit.limitAmount = BudgetLimit;
                    limit.month = DateTime.Now.Month.ToString();
                    limit.year = DateTime.Now.Year.ToString();
                    limit.spend = 0;
                    limitService.AddCtegoryLimit("User1", Cat.categorie_id, limit);
                    Application.Current.MainPage.Navigation.PopAsync();

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
