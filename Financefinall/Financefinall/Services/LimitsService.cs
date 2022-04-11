using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Financefinall.Models;

using Firebase.Database;
using Firebase.Database.Query;

namespace Financefinall.Services
{
    class LimitsService
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://financiio-default-rtdb.europe-west1.firebasedatabase.app/");

        public void getUserLimits(string UserID,string year,string month)
        {
            ObservableCollection<Category> UserCategories = firebaseClient
             .Child($"Users/{UserID}/categories")
             .AsObservable<Category>()
             .AsObservableCollection();
            Console.WriteLine(UserCategories.Count());

        }
        public void AddCtegoryLimit(string UserID,string CategoryID,Limit limit)
        {
              firebaseClient
             .Child($"Users/{UserID}/categories/{CategoryID}/limits")
             .PostAsync(limit);
             

        }
    }
}
