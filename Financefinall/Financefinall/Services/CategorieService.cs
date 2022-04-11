using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Financefinall.Models;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using Firebase.Database.Query;

namespace Financefinall.Services

{
    class CategorieService
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://financiio-default-rtdb.europe-west1.firebasedatabase.app/");
         public  ObservableCollection<Category> getUserCategories(string UserID)
         {
            var x=   firebaseClient
             .Child($"Users/{UserID}/categories")
             .AsObservable<Category>()
             .AsObservableCollection();
            return x;
         }
        public async Task EditCategory(string UserID, string categoryID, Category cat)
        {
             await firebaseClient
           .Child($"Users/{UserID}/categories/{categoryID}")
           .PatchAsync((cat));
        }

        public async Task DeleteCategory(string UserID, string categoryID)
        {
            await firebaseClient
           .Child($"Users/{UserID}/categories/{categoryID}")
           .DeleteAsync();
        }
        public async Task AddCategory(string UserID, Category category)
        {
            var x = await firebaseClient
                .Child($"Users/{UserID}/categories")
                .PostAsync(new Category(category));

            Category cat = new Category(x.Object);
            cat.categorie_id = x.Key;
                await firebaseClient
                .Child($"Users/{UserID}/categories/{cat.categorie_id}")
    .           PatchAsync(cat);
        }



    }



}
