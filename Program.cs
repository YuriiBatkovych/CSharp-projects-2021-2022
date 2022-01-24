using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wpisz ilosc parlamentarzystów : ");
            int numberOfparlamnetars = Convert.ToInt32(Console.ReadLine());
          
            Parlament parlament = new Parlament(numberOfparlamnetars);

            PrintMenuOfCommands();

            Console.WriteLine("NIE WOLNO GŁOSOWAĆ PRZED POCZĄTKIEM LUB PO KOŃCU GŁOSOWANIA\n\n");

            Console.WriteLine("Wpisz komende");

            string input = Console.ReadLine();

            bool votingContinues = false;

            while(!input.Equals("STOP"))
            {
                int endIndex = input.IndexOf(' ');
                if (endIndex == -1) endIndex = input.Length;
                
                string command = input.Substring(0, endIndex);
               
                if (command.Equals("POCZATEK"))
                {
                    if (!votingContinues)
                    {
                        string topic;
                        
                        try
                        {
                            topic = input.Substring(9);
                        }
                        catch(ArgumentOutOfRangeException)
                        {
                            topic = "";
                        }

                        Console.Clear();
                        PrintMenuOfCommands();
                        parlament.StartVoting(topic);
                        votingContinues = true;
                    }
                    else Console.WriteLine("Obecnie trwa inna nieukończona tura głosowania");
                }
                else if (command.Equals("GLOS"))
                {
                    try
                    {
                        int parlamentarNumber = Convert.ToInt32(input.Substring(5)) - 1;
                        if (parlamentarNumber >= 0 && parlamentarNumber < numberOfparlamnetars) parlament.Parlamentars[parlamentarNumber].Vote();
                        else Console.WriteLine("Nieprawidłowy numer parlamentarza");
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Numer parlamentarzysty był podany w nieprawidłowym formacie");
                    }
                }
                else if(command.Equals("KONIEC"))
                {
                    if (votingContinues)
                    {
                        parlament.EndVoting();
                        Console.WriteLine(parlament.GetLastVotingResults());
                        votingContinues = false;
                    }
                    else Console.WriteLine("Nie ma żadnej trwającej tury głosowania");
                }
                else Console.WriteLine("Nieznana komenda, wpisz poprawną ");
                
                input = Console.ReadLine();
            }
        }

        static void PrintMenuOfCommands()
        {
            Console.WriteLine("\nŻeby rozpocząć głosowanie, należy wpisać : POCZATEK [tytuł głosowania]");
            Console.WriteLine("Żeby zagłosować, należy wpisać : GLOS [nr Parlamentarzysty]");
            Console.WriteLine("Żeby zakończyć głosowanie, należy wpisać : KONIEC");
            Console.WriteLine("Żeby zakończyć symulację, należy wpisać STOP\n");
        }
    }
}
