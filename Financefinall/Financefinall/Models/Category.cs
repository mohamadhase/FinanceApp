using System;
using System.Collections.Generic;
using System.Text;

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
        public List<Transaction> transactions { get; set; }
        public List<Limit> limits { get; set; }

    }
}
