using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW04_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wpisz wartość liczby N : ");
            int N = Convert.ToInt32(Console.ReadLine());

            var collection = Enumerable.Range(1, N)
                .Where(x => ((x % 2 != 0 || x % 7 == 0) && x != 5 && x != 9))
                .Select(x => x*x);

            Console.WriteLine("Suma wszystkich elementów kolekcji = " + collection.Sum());
            Console.WriteLine("Liczba wszystkich elementów kolekcji = " + collection.Count());
            Console.WriteLine("Pierwszy element kolekcji = " + collection.First());
            Console.WriteLine("Ostatni element kolekcji = " + collection.Last());

            if (collection.Count() >= 3) Console.WriteLine("Trzeci element kolekcji = " + collection.ElementAtOrDefault(2));
            else Console.WriteLine("Kolekcja nie ma trzeciego elementu");



            Console.ReadKey();
        }
    }
}
