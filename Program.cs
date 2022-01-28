using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW04_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wpisz wartość liczby N : ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wpisz wartość liczby M : ");
            int M = Convert.ToInt32(Console.ReadLine());

            Random rnd = new Random();

            List<List<int>> collection = Enumerable.Range(1, N)
                .Select(x => Enumerable.Range(1, M).Select(a => rnd.Next(100)).ToList())
                .ToList();

            Console.WriteLine("Elementy listy list : ");

            collection.SelectMany(x => { 
                          x.Select( a => { Console.Write(a + " "); return a; }).ToList() ; 
                          Console.WriteLine(); return x; }).ToList();


            Console.WriteLine("Suma elementów listy list =  " + collection.Select(x => x.Sum()).Sum());
            
            Console.ReadKey();
        }
    }
}
