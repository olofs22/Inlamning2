using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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

                Console.WriteLine("klicka Enter för inbetalning, valfri knapp för utbetalning");
                ConsoleKeyInfo keyInfo = Console.ReadKey(); //readkey för att välja mellan in eller utbetalning
               
                //om man väljer utbetalning kommer inputen göras om till ett negativt tal

                //utbetalning får sina egna kategorier
                if (keyInfo.Key != ConsoleKey.Enter)
                {
                    double Ut;
                    bool validInput = false;

                    while (!validInput) 
                    {
                        Console.WriteLine("Ange belopp för utbetalning");
                        string InputUt = Console.ReadLine();

                        if (double.TryParse(InputUt, out Ut))
                        {
                            Ut = -Math.Abs(Ut); //Gör om input till ett negativt tal
                            newTransaction.Amount = Ut;//sätter inputen till attributen
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Fel! Belopp måste bestå av siffror, försök igen!");
                        }
                    }
                    //Välja kategori från listan
                    Console.WriteLine("Kategorisera utbetalningen enligt följande kategorier");

                    string Kat1 = "Hushåll";
                    string Kat2 = "Transport";
                    string Kat3 = "Övrigt";

                    Console.WriteLine($"1. {Kat1}");
                    Console.WriteLine($"2. {Kat2}");
                    Console.WriteLine($"3. {Kat3}");

                    int KatVal;
                    bool validInputkat = false;

                    while (!validInputkat) //while loop för att se till att rätt input matas in
                    {
                        string checkInput = Console.ReadLine();

                        if (int.TryParse(checkInput, out KatVal))
                        {
                            validInputkat = true;
                            {
                                switch (KatVal) //switch sats för att låta användaren välja mellan redan klara kategorier
                                {
                                    case 1:
                                        newTransaction.Category = Kat1;
                                        break;
                                    case 2:
                                        newTransaction.Category = Kat2;
                                        break;
                                    case 3:
                                        newTransaction.Category = Kat3;
                                        break;
                                    default:
                                        Console.WriteLine("Fel! Vänligen välj en av kategorierna från listan");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Fel! Vänligen välj en av kategorierna från listan");
                        }
                    }
                }
                else
                {
                    //inbetalningar får sina egna kategorier
                    double In;
                    bool validInput = false;
                    while (!validInput)
                    {
                        Console.WriteLine("Ange belopp för inbetalning");
                        string InputIn = Console.ReadLine();
                        if (double.TryParse(InputIn, out In)) //if sats för att kolla så inputen är en double
                        {
                            newTransaction.Amount = In;
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Fel! Belopp måste bestå av siffror, försök igen!");
                        }
                    }
                   
                    //ClearCurrentConsoleLine();
                    Console.WriteLine("Kategorisera inbetalningen enligt följande kategorier");

                    string Kat1 = "Lön";
                    string Kat2 = "Gåva";
                    string Kat3 = "Övrigt";

                    Console.WriteLine($"1. {Kat1}");
                    Console.WriteLine($"2. {Kat2}");
                    Console.WriteLine($"3. {Kat3}");

                    int KatVal;
                    bool validInputkat = false;

                    while (!validInputkat) //while loop för att se till att rätt input matas in
                    {
                        string checkInput = Console.ReadLine();

                        if (int.TryParse(checkInput, out KatVal))
                        {
                            validInputkat = true;
                            {
                                switch (KatVal) //switch sats för att låta användaren välja mellan redan klara kategorier
                                {
                                    case 1:
                                        newTransaction.Category = Kat1;
                                        break;
                                    case 2:
                                        newTransaction.Category = Kat2;
                                        break;
                                    case 3:
                                        newTransaction.Category = Kat3;
                                        break;
                                    default:
                                        Console.WriteLine("Vänligen välj en av kategorierna i listan");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Fel! Vänligen välj en av kategorierna från listan");
                        }
                    }
                }

                //do while loop som gör att man måste mata in en beskrivning för att gå vidare
                string TransaktionsBeskrivning;
                do
                {
                    Console.WriteLine("Beskriv transaktionen: ");
                    TransaktionsBeskrivning = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(TransaktionsBeskrivning)) //if sats som kollar så beskrivningen inte är tom
                    {
                        Console.WriteLine("Beskrivningen får inte vara tom, försök igen!");
                    }

                } while (string.IsNullOrWhiteSpace(TransaktionsBeskrivning));

                newTransaction.Description = TransaktionsBeskrivning;
                
                //Lägger till när transkationen gjordes, med hjälp av DateTime.Now får vi realtid :))
                newTransaction.Date = DateTime.Now;

                //Rendom klass för att skapa ett 6 siffrigt id till varje transkation.
                Random rnd = new Random();

                newTransaction.TransID = rnd.Next(100000, 999999);

                //tillslut läggs transaktionen in i listan
                transactions.Add(newTransaction);
                if (newTransaction.Amount < 0)
                {
                    Meny.ColorChange($"Utbetalning {newTransaction.TransID} har lagts till: {newTransaction.Amount}kr, {newTransaction.Category}, {newTransaction.Description}, {newTransaction.Date}",ConsoleColor.Red);
                }
                else
                {
                    Meny.ColorChange($"Inbetalning {newTransaction.TransID} har lagts till: {newTransaction.Amount}kr, {newTransaction.Category}, {newTransaction.Description}, {newTransaction.Date}", ConsoleColor.Green);
                }
                
                //if sats för att se om användaren har fler transkationer att lägga till
                Console.WriteLine("Vill du lägga till en till transaktion? (ja/nej)");

                string continueInput = Console.ReadLine().ToLower();

                if (continueInput != "ja")
                {
                    running = false;
                }
            }
        }

        //Metod som skrier ut alla transakioner i List
        public void ListTransactions()
        {
        transactions.Sort ((x, y) => x.Date.CompareTo(y.Date)); //Sorterar listan efter datum
            if (transactions.Count == 0)
            {
                Console.WriteLine("Finns inga transaktioner att visa");
            }
            else
            {
                foreach (var transaktion in transactions)
                { //if sats som gör att utbetalningar printas röda och inbetalmning printas gröna
                    if (transaktion.Amount < 0)
                    {
                        Meny.ColorChange($"{transaktion.Date} | {transaktion.Amount}kr | Kategori:{transaktion.Category} | Beskriving: {transaktion.Description} | ID: {transaktion.TransID}", ConsoleColor.Red);
                    }
                    else
                    {
                        Meny.ColorChange($"{transaktion.Date} | {transaktion.Amount}kr | Kategori:{transaktion.Category} | Beskriving: {transaktion.Description} | ID: {transaktion.TransID}", ConsoleColor.Green);
                    }
                }
            }
        }
            
        //metod som tar bort en transaktion från listan genom att inputa TransID
        public void DeleteTransaction()
        {
            Console.WriteLine("Ange transaktions-id som tillhör transaktionen du vill ta bort");
            int InputId = Convert.ToInt32(Console.ReadLine());

            //Skapa en ny variabel som blir transaktionen man ska ta bort

            var transactionToRemove = transactions.FirstOrDefault(t => t.TransID == InputId); //om TransID är samma som InputID kommer den transaktionen tas bort


            //if sats för visa om transkationen togs bort eller om den inte hittades
            if (transactionToRemove != null)
            {
                transactions.Remove(transactionToRemove);
                Console.WriteLine($"Transaktion {transactionToRemove.TransID} togs bort!");
            }
            else //annars blir det felmeddelande
            {
                Console.WriteLine($"Ingen transaktion med ID: {InputId} hittades...");
            }
        }
        public void CalculateBalance()
        {
            double Balance = 0; //Ny double som sätts till 0
            foreach (var transaktion in transactions ) //foreach loop för att loopa igenom varenda objekt i listan
            {
                Balance += (transaktion.Amount); //Plussa på varje Amount in i balance
            }
            if (Balance < 0) //om balance är negativ skrivs balansen ut i röd text
            {
                Meny.ColorChange($"Balans: {Balance}kr", ConsoleColor.Red);
            }
            else //om balance är positiv skrivs balansen ut i grön text
            {
                Meny.ColorChange($"Balans: {Balance}kr", ConsoleColor.Green);
            }
        }

        //metod för att visa statistik
        public void Statistics()
        {
            //nya doubles som ska användas för att räkna
            double TotalIncome = 0;
            double TotalExpense = 0;
            int AmountOfTransactions = 0;
            //foreach loop för att loopa igenom alla transaktioner i List
            foreach (var transaktion in transactions)
            {
                if (transaktion.Amount > 0)
                {
                    TotalIncome += transaktion.Amount;
                    AmountOfTransactions++;
                }
                else if (transaktion.Amount < 0)
                {
                    TotalExpense+= transaktion.Amount;
                    AmountOfTransactions++;
                }
            }
            //printa ut resultaten
            Meny.ColorChange("\nStatistik:", ConsoleColor.Yellow);

            Meny.ColorChange($"Totala inkomster: {TotalIncome}kr", ConsoleColor.Green);

            Meny.ColorChange($"Totala inkomster: {TotalExpense}kr", ConsoleColor.Red);

            Console.WriteLine($"Total mängd transaktioner: {AmountOfTransactions}");
        }
    }
}
