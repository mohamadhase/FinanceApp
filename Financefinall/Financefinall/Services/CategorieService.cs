using System;
using System.Collections.Generic;
using System.Text;

using Firebase.Database;
using Financefinall.Models;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;

namespace Financefinall.Services

{
    class CategorieService
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://financiio-default-rtdb.europe-west1.firebasedatabase.app/");
         public async Task<List<User>> GetAllUsers()
         {
            return (await firebaseClient
             .Child("Users")
             .OnceAsync<User>())
             .Select(item => new User
             {
                 Categories = item.Object.Categories.ToList(),
                 currency = item.Object.currency,
                 email = item.Object.email,
                 pass = item.Object.pass,
             }).ToList();
         }
    }



}
