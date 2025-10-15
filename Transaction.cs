using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning2
{
    //Skapa klass transaktion som innehåller attibuterna transkationerna behöver.
    internal class Transaction
    {
        
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public int TransID { get; set; }

        //En tom konstruktor för att få programmet att fungera
        public Transaction()
        {

        }
        //Konstruktor med attributen
        public Transaction(string description, double amount, string category, DateTime date, int transid)
        {
            Description = description;
            Amount = amount;
            Category = category;
            Date = date;
            TransID = transid;
        }
    }

    
}
