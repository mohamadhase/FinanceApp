using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Input;

using Financefinall.Models;

using Financefinall.Services;
using Financefinall.Views;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Financefinall.ViewModels
{
    class CategoriesViewModel: BindableObject
    {
        public string _incomeColor;
        public string _outcomeColor;
        public int currentType = 0;
        public string IncomeColor
        {
            get
            {
                return _incomeColor;
            }
            set
            {
                _incomeColor = value;
                OnPropertyChanged();

            }
        }
        public string OutComeColor
        {
            get
            {
                return _outcomeColor;
            }
            set
            {
                _outcomeColor = value;
                OnPropertyChanged();
            }
        }
        CategorieService categorieservice;
        public ObservableCollection<Category> _categories = new ObservableCollection<Category>();
        public ObservableCollection<Category> _categories2 = new ObservableCollection<Category>();
        public ObservableCollection<Category> categories
        {
            get { return _categories; }
            set { _categories = value;
                OnPropertyChanged(); 
            }
        }
        public ObservableCollection<Category> categories2
        {
            get { return _categories2; }
            set {  _categories2 = value; OnPropertyChanged(); }
        }
        private Category previousSelected;
        Category selectedCategory;
        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (value != null)
                {
                    Application.Current.MainPage.Navigation.PushAsync(new EditCategory(value));
                    previousSelected = value;

                    value = null;
                }

                selectedCategory = value;
                OnPropertyChanged();

            }
        }
        public CategoriesViewModel()
        {
            IncomeColor = "#FFFFFF";
            OutComeColor = "#EFEFF0";
            categorieservice = new CategorieService();
            categories = categorieservice.getUserCategories("User1");
            categories.CollectionChanged += OnCollectionChanged;
        }


        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                categories2.Clear();
                foreach(Category cat in categories)
                {
                    if (cat.type == currentType)
                    {
                        Category newCategory = new Category(cat);
                        categories2.Add(newCategory);
                    }

                }

            }



        }
        public ICommand AddButtonCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new AddCategory());

                });
            }
        }

        public ICommand IncomeCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    currentType = 0;
                    IncomeColor = "#FFFFFF";
                    OutComeColor = "#EFEFF0";
                    categories2 = new ObservableCollection<Category>(categories);
                    categories2.Clear();
                    foreach (var cat in categories)
                    {
                        if (cat.type == 0)
                        {
                            categories2.Add(cat);
                        }
                    }
                });
            }
        }
        public ICommand OutcomeCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    currentType = 1;

                    OutComeColor = "#FFFFFF";
                    IncomeColor = "#EFEFF0";
                    categories2 = new ObservableCollection<Category>(categories);
                    categories2.Clear();
                    foreach (var cat in categories)
                    {
                        
                        if (cat.type == 1)
                        {
                            categories2.Add(cat);
                        }
                    }
                });
            }
        }
    }
}
