using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Financefinall.Models;

using Financefinall.Services;
using Financefinall.Views;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Financefinall.ViewModels
{
    class CategoriesViewModel: BindableObject
    {
        CategorieService categorieservice;
        public ObservableCollection<Category> _categories = new ObservableCollection<Category>();
        public ObservableCollection<Category> categories
        {
            get { return _categories; }
            set { _categories = value; OnPropertyChanged(); }
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
            categorieservice = new CategorieService();

            Button_Clicked();
        }
         private void Button_Clicked()
        {
            categories = categorieservice.getUserCategories("User1");


        }


    }
}
