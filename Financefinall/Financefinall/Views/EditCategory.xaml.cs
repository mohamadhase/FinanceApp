using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Financefinall.Models;
using Financefinall.ViewModels;
using Xamarin.Forms.Xaml;
using Financefinall.Services;

namespace Financefinall.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCategory : ContentPage
    {

        Category category;
        public EditCategory(Category cat)
        {
            InitializeComponent();
            category = cat;
            NameEntry.Text = cat.categorie_name;
            TypeEntry.Text = cat.type.ToString();
            //EditCategoryViewModel editCategoryViewModel = new EditCategoryViewModel();
            //editCategoryViewModel.category = cat;
            //BindingContext = editCategoryViewModel;
            EdtiCategoryClick();
        }
        public async void editCategory()
        {
            CategorieService categorieService = new CategorieService();
            category.categorie_name = NameEntry.Text;
            category.type = System.Convert.ToInt32(TypeEntry.Text);

            await categorieService.EditCategory("User1", category.categorie_id, category);
            await DisplayAlert("Adding", "The Category Edited", "Ok");
            await Navigation.PushAsync(new Categories());

        }

        void EdtiCategoryClick()
        {
            save.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command( () =>
                {
                    editCategory();

                })
            });
        }


    }
}