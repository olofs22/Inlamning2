using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//En simpel meny klass som kommer visas så fort programmet startar
namespace Inlämning2
{
    internal class Meny
    {
        public void WriteMenu()
        {
            Console.WriteLine("Välkommen, vänligen välj ett av alternativen nedan");
            Console.WriteLine("1: Lägg till en transaktion");
            Console.WriteLine("2: Lista alla transkationer");
            Console.WriteLine("3: Visa balansen");
            Console.WriteLine("4: Ta bort en transaktion");
            Console.WriteLine("5: Visa statistik");
            Console.WriteLine("6: Avsluta");
        }
        
    }
}
