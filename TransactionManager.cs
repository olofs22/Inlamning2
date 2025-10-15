using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
//Klass som sköter logiken kring transaktionerna
namespace Inlämning2
{
    internal class TransactionManager
    {
        
        //Skapa en lista som innehåller transaktioner, dessa är objekt av "Transactions" klassen.
        List<Transaction> transactions = new List<Transaction>();

        //Metod för att lägga till transaktioner
        public void AddTransaction()
        {
            //En boolean "running" för att kunna kontrollera när programmet ska stängas av
            bool running = true;
            //While loop som gör så metoden körs tills använder avslutar den
            while (running) 
            {
                //Skapar en ny instans av objekten listan består av
                Transaction newTransaction = new Transaction();

                Console.WriteLine("Vill du göra en inbetalning eller utbetalning?");
                string val = Console.ReadLine();
                //if sats för att bestämma om man ska göra en in eller utbetalning
                //om man väljer utbetalning kommer inputen göras om till ett negativt tal
                if (val == "Utbetalning")
                {
                    Console.WriteLine("Ange belopp för utbetalning");
                    double Ut = Convert.ToDouble(Console.ReadLine());
                    Ut = -Math.Abs(Ut); //Gör om input till ett negativt tal
                    newTransaction.Amount = Ut;//sätter inputen till attributen
                }
                else
                {
                    Console.WriteLine("Ange belopp för inbetalning");
                    double In = Convert.ToDouble(Console.ReadLine());
                    newTransaction.Amount = In;
                }

                //simpel rl för att lägga till en beskrivning
                Console.WriteLine("Beskriv transaktionen: ");
                string TransaktionsBeskrivning = Console.ReadLine();
                newTransaction.Description = TransaktionsBeskrivning;

                //simpel rl för att lägga till en kategori
                Console.WriteLine("Kategorisera transaktionen");
                newTransaction.Category = Console.ReadLine();

                //Lägger till när transkationen gjordes, med hjälp av DateTime.Now får vi realtid :))
                newTransaction.Date = DateTime.Now;

                //Rendom klass för att skapa ett 6 siffrigt id till varje transkation.
                Random rnd = new Random();

                newTransaction.TransID = rnd.Next(100000, 999999);

                //tillslut läggs transaktionen in i listan
                transactions.Add(newTransaction);

                //if sats för att se om användaren har fler transkationer att lägga till
                Console.WriteLine("Vill du lägga till en till transaktion? (ja/nej)");
                string continueInput = Console.ReadLine().ToLower();
                if (continueInput != "ja")
                {
                    Console.WriteLine($"{newTransaction.Amount}, {newTransaction.Category}, {newTransaction.Description}, {newTransaction.Date}, {newTransaction.TransID}");

                    running = false;

                    
                }
            }
        }

        //Metod som skrier ut alla transakioner i List
        public void ListTransactions()
        {
            foreach (var transaktion in transactions)
                if(transaktion == null)
                {
                    Console.WriteLine("Finns inga transaktioner att visa");
                }
                else
                { //if sats som gör att utbetalningar printas röda och inbetalmning printas gröna
                    if (transaktion.Amount < 0)
                    {
                        var originalColor = Console.ForegroundColor; //sparar färgen i konsolen
                        Console.ForegroundColor = ConsoleColor.Red; //sätter färgen till röd
                        Console.WriteLine($"{transaktion.Date} | {transaktion.Amount}kr | Kategori:{transaktion.Category} | Beskriving: {transaktion.Description} | ID: {transaktion.TransID}");
                        Console.ForegroundColor = originalColor;//ställer tillbaka färgen till det den var innan
                    }
                    else
                    {
                        var originalColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{transaktion.Date} | {transaktion.Amount}kr | Kategori:{transaktion.Category} | Beskriving: {transaktion.Description} | ID: {transaktion.TransID}");
                        Console.ForegroundColor = originalColor;

                    }
                }
        }
        //metod som tar bort en transaktion från listan genom att inputa TransID
        public void DeleteTransaction()
        {
            Console.WriteLine("Ange transaktion-id som tillhör transaktionen du vill ta bort");
            int InputId = Convert.ToInt32(Console.ReadLine());

            //Skapa en ny variabel som blir transaktionen man ska ta bort

            var transactionToRemove = transactions.FirstOrDefault(t => t.TransID == InputId); //TransID är samma som InputID kommer den transaktionen tas bort


            //if sats för visa om transkationen togs bort eller om den inte hittades
            if (transactionToRemove != null)
            {
                transactions.Remove(transactionToRemove);
                Console.WriteLine($"Transaktion {transactionToRemove.TransID} togs bort!");
            }
            else
            {
                Console.WriteLine($"Ingen transaktion med {InputId} hittades...");
            }
        }
    }
}
