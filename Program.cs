namespace Inlämning2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //skapar instanser av klasserna
            TransactionManager transactionManager = new TransactionManager();
            Meny meny = new Meny();

            //running bool för att kunna kontrollera hur programmet körs
            bool running = true;

            while (running)
            {
                //Console.Clear();
                meny.WriteMenu(); //kör meny metoden

                int val;

                bool checkInput = int.TryParse(Console.ReadLine(), out val); //kollar så att inputen är en integer

                if (checkInput == false) //if sats för att kolla så att inputen är giltig, om den inte är det kommer ett felmeddelande visas
                {
                    Console.WriteLine("Ogiltigt val, försök igen!");
                }
                else
                {
                    switch (val) //switch för att navigera programmet
                    {
                        case 1:
                            //Console.Clear();
                            transactionManager.AddTransaction();
                            break;
                        case 2:
                            //Console.Clear();
                            transactionManager.ListTransactions();
                            break;
                        case 3:
                            //Console.Clear();
                            transactionManager.CalculateBalance();
                            break;
                        case 4:
                            //Console.Clear();
                            transactionManager.DeleteTransaction();
                            break;
                        case 5:
                            //Console.Clear();
                            transactionManager.Statistics();
                            break;
                        case 6:

                            running = false;
                            break;
                        default:
                            //Console.Clear();
                            Console.WriteLine("Ogiltigt val, försök igen!"); //kollar så att inputen är giltig, att användaren väljer mellan 1-6
                            break;
                    }
                }
            }
        }
    }
}
