using System;
using System.Collections.Generic;
using System.Text;

using Financefinall.Models;
using Financefinall.Services;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Financefinall.ViewModels
{
    class DashboardViewModel : BindableObject
    {
        CategorieService categorieservice;
        public ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> users
        {
            get { return _users; }
            set { _users = value; }
        } 

        public DashboardViewModel()
        {
             categorieservice = new CategorieService();

            //Button_Clicked();
        }
        //async private void Button_Clicked()
        //{
        //    //users =  categorieservice.GetAllUsers();


        //}
    }
}
