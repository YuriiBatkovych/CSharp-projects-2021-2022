using System;
using System.Collections.Generic;
using System.Linq;

namespace CW01
{
    enum EHeroClass
    {
        Barbarzynca,
        Paladyn,
        Amazonka
    }

    class Program
    {
        static Hero hero;
        static List<Location> locations = new List<Location>();
        static Location currentLocation;
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w grze WoodGang");
            Console.WriteLine("[1] Zacznij nową grę");
            Console.WriteLine("[X] Zamknij program");

            string decision = OneXChose();

            if (decision.Equals("1"))
            {
                Console.Clear();
                Console.WriteLine("Wpisz nazwę bohatera : ");
                string name = removeExtraSpaces(Console.ReadLine());

                while (!validName(name))
                {
                    Console.WriteLine("Wpisz poprawną nazwę bohatera (tylko litery i conajmniej dwie): ");
                    name = removeExtraSpaces(Console.ReadLine());
                }

                Console.Clear();

                Console.WriteLine("Witaj, " + name + ", wybierz klasę bohatera, wpisując odpowiednią liczbę");
                Console.WriteLine("1 - barbarzyńca");
                Console.WriteLine("2 - paladyn");
                Console.WriteLine("3 - amazonka");
                string input = Console.ReadLine();
                int number;

                while (!(Int32.TryParse(input, out number) && (number>=1 && number<=3)))
                {
                    Console.WriteLine("Wpisz poprawną liczbę");
                    input = Console.ReadLine();
                }

                hero = new Hero(name, number-1);
                Console.Clear();
                Console.WriteLine(hero.Type + " " + hero.Name + " wyrusza na przygodę");

                ////////  starting initialization for further part of a game  ///////////
                
                Location startLocation = new Location("Bois de Boulogne", true);

                locations.Add(startLocation);
                currentLocation = startLocation;

                //addind another locations

                locations.Add(new Location("Golden City", true));
                locations.Add(new Location("Horror Wood", true));
                locations.Add(new Location("Queen's castle", true));
                locations.Add(new Location("Battle field", false));
                locations.Add(new Location("Secret house", false));
                locations.Add(new Location("Druid's home", true));

                string heroname = "";

                NonPlayerCharacter Astar = new NonPlayerCharacter("Astar", "Witaj, czy możesz mi pomóc dostać się do innego miasta?");
                NonPlayerCharacter Peasant = new NonPlayerCharacter("Peasant", "Hey, czy potrzebujesz jedzenia?");
                NonPlayerCharacter Wanderer = new NonPlayerCharacter("Wanderer","Hej czy to Ty jesteś tym słynnym {0} – pogromcą smoków?");

                
                startLocation.AddNPC(Astar);
                startLocation.AddNPC(Peasant);
                startLocation.AddNPC(Wanderer);

                /// filling Astar dialog ///

                //HeroDialogParts : //

                HeroDialogPart h1 = new HeroDialogPart("Tak , chętnie pomogę");
                HeroDialogPart h2 = new HeroDialogPart("Nie , nie znam drogi");
                HeroDialogPart h3 = new HeroDialogPart("Dam znać jak będę gotowy");
                HeroDialogPart h4 = new HeroDialogPart("100 sztuk złota to za mało!");
                HeroDialogPart h5 = new HeroDialogPart("OK, może być 100 sztuk złota.");
                HeroDialogPart h6 = new HeroDialogPart("W takim razie radź sobie sam.");

                //NpcDialogParts : //
                NpcDialogPart n1 = new NpcDialogPart("Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota");
                NpcDialogPart n2 = new NpcDialogPart("Niestety nie mam więcej. Jestem bardzo biedny");
                NpcDialogPart n3 = new NpcDialogPart("Dziękuję");

                Astar.Start.AddHeroStatement(h1);
                Astar.Start.AddHeroStatement(h2);
                h1.SetNpcDialogPart(n1);
                n1.AddHeroStatement(h3);
                n1.AddHeroStatement(h4);
                h4.SetNpcDialogPart(n2);
                n2.AddHeroStatement(h5);
                n2.AddHeroStatement(h6);
                h5.SetNpcDialogPart(n3);

                ///// filling Peasant dialog /////
                /////HeroDialogParts : //
                
                HeroDialogPart k1 = new HeroDialogPart("Tak , a co proponujesz");
                HeroDialogPart k2 = new HeroDialogPart("Nie , dziękuje");
                HeroDialogPart k3 = new HeroDialogPart("Nie tego szukam");
                HeroDialogPart k4 = new HeroDialogPart("Po ile szprzedajesz?");
                HeroDialogPart k5 = new HeroDialogPart("OK, to biorę");
                HeroDialogPart k6 = new HeroDialogPart("Jest zadrogo");
                HeroDialogPart k7 = new HeroDialogPart("To sprzedasz komuś innemu");
                HeroDialogPart k8 = new HeroDialogPart("To sie zgadzam");

                //NpcDialogParts : //

                NpcDialogPart m1 = new NpcDialogPart("Mam, ziemniaki do sprzedania");
                NpcDialogPart m2 = new NpcDialogPart("30 sztuk złota");
                NpcDialogPart m3 = new NpcDialogPart("Taniej nie będzie , jest to najlepsza cena w całym królewstwie, Prosze Pana");
                NpcDialogPart m4 = new NpcDialogPart("No i ślicznie");

                Peasant.Start.AddHeroStatement(k1);
                Peasant.Start.AddHeroStatement(k2);
                k1.SetNpcDialogPart(m1);
                m1.AddHeroStatement(k3);
                m1.AddHeroStatement(k4);
                k4.SetNpcDialogPart(m2);
                m2.AddHeroStatement(k5);
                m2.AddHeroStatement(k6);
                k6.SetNpcDialogPart(m3);
                m3.AddHeroStatement(k7);
                m3.AddHeroStatement(k8);
                k8.SetNpcDialogPart(m4);

                //// filling Wanderer dialog ///
                /////HeroDialogParts : //
                
                HeroDialogPart l1 = new HeroDialogPart("Tak, jestem {0}");
                HeroDialogPart l2 = new HeroDialogPart("Nie");

                //NpcDialogParts : //

                NpcDialogPart v1 = new NpcDialogPart("WOW! Miło poznać!");

                Wanderer.Start.AddHeroStatement(l1);
                Wanderer.Start.AddHeroStatement(l2);
                l1.SetNpcDialogPart(v1);

                ///// end of initializtion ////

                ShowLocation();

            }
            
        }

        static void ShowLocation() //metoda menu lokalizacji
        {
            do
            { 

                Console.WriteLine("Znajdujesz się w: " + currentLocation.Name + ". Co chcesz zrobić ?");
                int i = 1;
                foreach (NonPlayerCharacter n in currentLocation.NPCs)             //pokazujemy NonPlayerCharacters tej lokacji
                {
                    Console.WriteLine("[" + i + "] Porozmawiaj z " + n.Name);
                    i++;
                }

                Console.WriteLine("[T] Podróżuj");

                Console.WriteLine("[X] Zamknij program");

                string decision = Console.ReadLine();
                int number;

                while (!(Int32.TryParse(decision, out number) && (number >= 1 && number <= currentLocation.NPCs.Count)) 
                    && !decision.Equals("X") && !decision.Equals("T"))  //sprawdzanie poprawności wejscia
                {
                    Console.WriteLine("Wpisz poprawną liczbę");
                    decision = removeExtraSpaces(Console.ReadLine());
                }

                if (decision.Equals("X"))
                {
                    Environment.Exit(0);
                }
                else if(decision.Equals("T"))
                {
                    ChangeLocation();
                }
                else
                {
                    DialogParser dp = new DialogParser(hero);
                    TalkTo(currentLocation.NPCs[number - 1], dp);            // number - 1 , bo numeracja listy od zera, a w menu mamy od 1
                }

                Console.Clear();
            } while (true);
        }

        static void ChangeLocation()
        {
            Console.Clear();

            var locationsForTrip = locations.Where(location => (!location.Name.Equals(currentLocation.Name) && location.IsUnlocked))
                                            .OrderBy(location => location.Name)
                                            .ToArray();

            Console.WriteLine("Znajdujesz się w : "+currentLocation.Name+". Gdzie chcesz wyruszyć?");

            for(int i=1; i<=locationsForTrip.Length; i++)
            {
                Console.WriteLine("["+i+"] "+locationsForTrip[i-1].Name);
            }

            Console.WriteLine("[X] Powrót");

            string decision = Console.ReadLine();
            int number;

            while (!(Int32.TryParse(decision, out number) && (number >= 1 && number <= locationsForTrip.Length))
                && !decision.Equals("X"))  //sprawdzanie poprawności wejscia
            {
                Console.WriteLine("Wpisz poprawną liczbę");
                decision = removeExtraSpaces(Console.ReadLine());
            }

            if (!decision.Equals("X"))
            {
                currentLocation = locationsForTrip[number - 1];
            }

            Console.Clear();
        }

        static void TalkTo (NonPlayerCharacter npc, DialogParser dp)   //metoda realizująca dialog
        {
            Console.Clear();

            NpcDialogPart ndp =  npc.NpcDialogPartStartTalking();          // ndp - NonPlayerCharacterDialogPart 
            HeroDialogPart hdp;

            while(true)
            {
                Console.WriteLine(dp.ParseDialog(ndp));                    //ParseDialog wstawia imie bohatera  w zdania dialogu 
                List<HeroDialogPart> collection = ndp.GetCollection();

                if (collection.Count != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("// wybierz odpowiedz wpisując odpowiednią liczbę //");

                    int i = 1;
                    List<string> parsedMenu = dp.ParseMenu(collection);
                    foreach (string s in parsedMenu)
                    {
                        Console.WriteLine(i + " - " + s);
                        i++;
                    }

                    string input = Console.ReadLine();
                    int number;

                    while (!(Int32.TryParse(input, out number) && (number >= 1 && number <= collection.Count)))
                    {
                        Console.WriteLine("Wpisz poprawną liczbę");
                        input = Console.ReadLine();
                    }

                    hdp = collection[number - 1];
                }
                else
                {
                    Console.WriteLine("<KONIEC>");
                    Console.ReadKey();                       //wcisnij dowolną klawisz żeby wrócić do menu lokalizacji
                    break;
                }

                Console.WriteLine(dp.ParseDialog(hdp));

                if (hdp.GetNDP() != null)
                {
                    ndp = hdp.GetNDP();
                }
                else
                {
                    Console.WriteLine("<KONIEC>");
                    Console.ReadKey();                      //wcisnij dowolną klawisz żeby wrócić do menu lokalizacji
                    break;
                }
            }

            
            Console.Clear();
        }

        static string OneXChose()  // wybor miedzy 1 a x w menu poczatkowym gry
        {
            string decision = removeExtraSpaces(Console.ReadLine());

            while (!decision.Equals("X") && !decision.Equals("1"))
            {
                Console.WriteLine("Wpisz poprawny znak");
                decision = removeExtraSpaces(Console.ReadLine());
            }
            
            return decision;
        }

        static string removeExtraSpaces(string s)    //usun niepotrzebne białe znaki
        {
            string clear_name = "";
            bool last_space = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    clear_name = clear_name + s[i];
                    last_space = false;
                }
                else if (!last_space)
                {
                    clear_name = clear_name + s[i];
                    last_space = true;
                }
            }

            return clear_name;
        }

        static bool validName(string name)                     //tylko litery alfabetu i conajmniej 2 znaczace znaki
        {
            name = removeExtraSpaces(name);
            int number_of_valid_chars = 0;
            foreach (char c in name)
            {
                if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c==' '))
                {
                    return false;
                }

                number_of_valid_chars++;
            }

            if (number_of_valid_chars < 2) return false;

            return true;
        }
    }
}
