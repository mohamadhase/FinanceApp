using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Xamarin.Forms;

namespace Financefinall.Models
{
    public class Category
    {
        public Category()
        {

        }
        public Category(Category instans)
        {
            categorie_id = instans.categorie_id;
            categorie_name = instans.categorie_name;
            photo_id = instans.photo_id;
            type = instans.type;
            transactions = instans.transactions;
            limits = instans.limits;

        }
        public string categorie_id { get; set; }
        public string categorie_name { get; set; }
        public string photo_id { get; set; }
        public int type { get; set; }

        public ObservableCollection<Transaction> transactions;

        public ObservableCollection<Limit> limits;
    }
}
