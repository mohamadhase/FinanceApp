using System;
using System.Collections.Generic;
using System.Text;

namespace Financefinall.Models
{
    public class Limit
    {
        public string month { get; set; }
        public string year { get; set; }
        public int limitAmount { get; set; }
        public int spend { get; set; }
    }
}
