using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning2
{
    internal class Transaction
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public Transaction()
        {

        }
        public Transaction(string description, double amount, string category, DateTime date)
        {
            Description = description;
            Amount = amount;
            Category = category;
            Date = date;
        }
    }

    
}
