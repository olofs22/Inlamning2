namespace Inlämning2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TransactionManager transactionManager = new TransactionManager();
            
            

            transactionManager.AddTransaction();
            transactionManager.ListTransactions();
        }
    }
}
