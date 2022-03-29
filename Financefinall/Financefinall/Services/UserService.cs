using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Financefinall.Models;

using Firebase.Database;

namespace Financefinall.Services
{
    class UserService
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://financiio-default-rtdb.europe-west1.firebasedatabase.app/");
        public async Task<User> GetUserDetails(string UserID)
        {
            User allCategories = (await firebaseClient
             .Child($"Users/{UserID}")
             .OnceSingleAsync<User>());
            return allCategories;
        }
    }
}
