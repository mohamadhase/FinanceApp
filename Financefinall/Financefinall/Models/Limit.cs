using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace Financefinall.Models
{
    public class Limit
    {
        public Limit()
        {

        }
        public Limit(Limit instans)
        {
            spend = instans.spend;
            month = instans.month;
            year = instans.year;
            limitAmount = instans.limitAmount;

        }
        public string month { get; set; }
        public string year { get; set; }
        public int limitAmount { get; set; }
        public int spend { get; set; }
    }
}
