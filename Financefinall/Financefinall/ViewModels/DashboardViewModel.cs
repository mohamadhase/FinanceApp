using System;
using System.Collections.Generic;
using System.Text;

using Financefinall.Models;
using Financefinall.Services;

using Xamarin.Forms;
namespace Financefinall.ViewModels
{
    class DashboardViewModel : BindableObject
    {
        public List<User> users { get; set; }

        public DashboardViewModel()
        {
            users = new List<User>();
            Button_Clicked();
        }
        async private void Button_Clicked()
        {
            CategorieService categorieservice = new CategorieService();
            users = (await categorieservice.GetAllUsers());

            users.ForEach(x => Console.WriteLine(x.email));

        }
    }
}
