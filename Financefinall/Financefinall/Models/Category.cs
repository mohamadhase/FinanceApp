using System;
using System.Collections.Generic;
using System.Text;

namespace Financefinall.Models
{
    public class Category
    {
        public string categorie_id { get; set; }
        public string categorie_name { get; set; }
        public string photo_id { get; set; }
        public int type { get; set; }
        public List<Transaction> transactions { get; set; }
        public List<Limit> limits { get; set; }

    }
}
