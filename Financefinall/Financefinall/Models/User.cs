using System;
using System.Collections.Generic;
using System.Text;

namespace Financefinall.Models
{
    public class User
    {
        public string email { get; set; }
        public string pass { get; set; }
        public string currency { get; set; }
        public List<Category> Categories { get; set; }
    }


}
