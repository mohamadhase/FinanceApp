using System;
using System.Collections.Generic;
using System.Text;

namespace Financefinall.Models
{
    public class LimitShow
    {
        public string categorie_id { get; set; }
        public string categorie_name { get; set; }   
        public string photo_id { get; set; }
        public int type { get; set; }
        public int limitAmount { get; set; }
        public int spend { get; set; }


    }
}
