using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Financefinall.Models;
using Financefinall.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Financefinall.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCategory : ContentPage
    {
        public AddCategory()
        {
            InitializeComponent();
            AddCategoryClick();
        }
        public async void addCategory()
        {
            CategorieService categorieService = new CategorieService();
            Category cat = new Category();
            cat.type =  System.Convert.ToInt32(TypeEntry.Text);
            cat.categorie_name = NameEntry.Text;
            Random rd = new Random();
            int rand_num = rd.Next(1, 4000);
            cat.categorie_id = rand_num.ToString();
            await categorieService.AddCategory("User1", cat);
            await Navigation.PushAsync(new Categories());


        }
        void AddCategoryClick()
        {
            save.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command( () =>
                {
                    addCategory();

                })
            });
        }
    }
}