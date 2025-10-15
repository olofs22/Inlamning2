using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Inlämning2
{
    internal class TransactionManager
    {
       
        public void AddTransaction()
        {
            
            {
                bool running = true;

                List<Transaction> transactions = new List<Transaction>();

                while (running)
                {
                    Transaction newTransaction = new Transaction();

                    Console.WriteLine("Vill du göra en inbetalning eller utbetalning?");
                    string val = Console.ReadLine();
                    if (val == "Utbetalning")
                    {
                        Console.WriteLine("Ange belopp för utbetalning");
                        double Ut = Convert.ToDouble(Console.ReadLine());
                        Ut = -Math.Abs(Ut);
                        newTransaction.Amount = Ut;
                        
                    }
                    else
                    {
                        Console.WriteLine("Ange belopp för inbetalning");
                        double In = Convert.ToDouble(Console.ReadLine());
                        newTransaction.Amount = In;
                    }

                    Console.WriteLine("Beskriv transaktionen: ");
                    string TransaktionsBeskrivning = Console.ReadLine();
                    newTransaction.Description = TransaktionsBeskrivning;

                    Console.WriteLine("Kategorisera transaktionen");
                    newTransaction.Category = Console.ReadLine();

                    newTransaction.Date = DateTime.Now;

                    transactions.Add(newTransaction);

                    Console.WriteLine($"{newTransaction.Amount}, {newTransaction.Category}, {newTransaction.Description}, {newTransaction.Date}");
                }
            
        
            
            }   
        }
        public void ListTransactions()
        {

        }

    }
}
