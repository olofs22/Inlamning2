namespace Inlämning2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TransactionManager transactionManager = new TransactionManager();
            Meny meny = new Meny();
            bool running = true;

            while (running)
            {
                meny.WriteMenu();

                int val = Convert.ToInt32(Console.ReadLine());

                switch (val)
                {
                    case 1:
                        transactionManager.AddTransaction();
                        break;
                    case 2:
                        transactionManager.ListTransactions();
                        break;
                    case 5:
                        running = false;
                        break;
                }
            }

            

            
            
        }
    }
}
