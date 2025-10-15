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
                meny.WriteMenu(); //kör meny metoden

                int val = Convert.ToInt32(Console.ReadLine()); //tar in en input som används för att navigera menyn

                switch (val) //switch för att navigera programmet
                {
                    case 1:
                        transactionManager.AddTransaction();
                        break;
                    case 2:
                        transactionManager.ListTransactions();
                        break;
                    case 4:
                        transactionManager.DeleteTransaction();
                        break;
                    case 5:
                        running = false;
                        break;
                }
            }

            

            
            
        }
    }
}
