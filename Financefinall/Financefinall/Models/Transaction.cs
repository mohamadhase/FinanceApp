using Financefinall.Views;

using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Financefinall.Models
{
    public class Transaction
    {
        public Transaction()
        {

        }
        public Transaction(Transaction instans)
        {
            day = instans.day;
            Month = instans.Month;
            Year = instans.Year;
            amount = instans.amount;

        }

        public string day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int amount { get; set; }

    }
}
