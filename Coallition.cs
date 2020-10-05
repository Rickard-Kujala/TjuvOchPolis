using System;
using System.Collections.Generic;
using System.Threading;


namespace TjuvOchPolis
{
    class Coallition
    {
        public static int NumberOfMuggins = 0;
        public static int NumberOfArrests = 0;
        public static int NumberOfMurders = 0;

        public static string CityInfoMuggins = " ";
        public static string CityInfoArrests = " ";

        public static void Muggin(List<Person> personList)
        {
            foreach (var item in personList)
            {
                var tmpPerson = item;
                foreach (var person in personList)
                {
                    if (tmpPerson is Citizen && person is Thief && tmpPerson.CurentPositionX == person.CurentPositionX
                                                                && tmpPerson.CurentPositionY == person.CurentPositionY)
                    {
                        bool kill = ProbabilityTrue(10);

                        if (kill==true)
                        {
                            Murder(tmpPerson, personList);
                            NumberOfMurders++;
                            CityInfoMuggins = "EN MEDBORGARE HAR BLIVIT MÖRDAD!";
                            Console.SetCursorPosition(item.CurentPositionX, item.CurentPositionY);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("K");
                            printActivity();
                            Thread.Sleep(5000);
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        else if (tmpPerson.Inventory.Count > 0)
                        {
                            CityInfoMuggins = Robery(tmpPerson, person);
                            Console.SetCursorPosition(item.CurentPositionX, item.CurentPositionY);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("X");
                            NumberOfMuggins++;
                            printActivity();
                            Thread.Sleep(5000);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            CityInfoMuggins = "En tjuv försökte råna en medborgare men medborgaren hade inga värdesaker!";
                            Console.SetCursorPosition(item.CurentPositionX, item.CurentPositionY);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("X");
                            printActivity();
                            Thread.Sleep(5000);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }
        public static string Robery(Person citizen, Person thief)
        {
            string info = " ";
            Random r = new Random();
            int x = r.Next(0, citizen.Inventory.Count);
            thief.Inventory.Add(citizen.Inventory[x]);
            CityInfoArrests = $"Tjuv stal {citizen.Inventory[x].Gadget} från en medborgare!";
            citizen.Inventory.RemoveAt(x);
            return info;
        }
        public static void Arrest(List<Person> personList)
        {
            foreach (var item in personList)
            {
                var tmpPerson = item;
                foreach (var person in personList)
                {
                    if (tmpPerson is Thief && person is Police && tmpPerson.CurentPositionX == person.CurentPositionX
                                                                && tmpPerson.CurentPositionY == person.CurentPositionY)
                    {
                       
                        if (tmpPerson.Inventory.Count > 0)
                        {
                            Seize(tmpPerson, person);
                            Console.SetCursorPosition(item.CurentPositionX, item.CurentPositionY);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("A");
                            CityInfoArrests = $"Polis arresterade en tjuv och beslagtog allt stöldgods! ";
                            NumberOfArrests++;
                            printActivity();

                            Thread.Sleep(5000);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            CityInfoArrests = "Polisen stoppade en misstänkt gärningsman,\n"+
                                "men den misstänkte hade hade inget stöldgods på sig och sätts på fri fot i staden! ";

                            Console.SetCursorPosition(item.CurentPositionX, item.CurentPositionY);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("A");
                            printActivity();

                            Thread.Sleep(5000);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }
        public static void Seize(Person thief, Person police)
        {
            for (int i = 0; i < thief.Inventory.Count; i++)//Loopa igenog tjuven lista och lägg till varje element till polisens lista
            {
                police.Inventory.Add(thief.Inventory[i]);
            }
            thief.Inventory.Clear();
        }
        public static void printActivity()
        {
            Console.SetCursorPosition(0, 26);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Antal rån i staden: {NumberOfMuggins}\n" +
                                    $"Antal gripna: {NumberOfArrests}\n" +
                                      $"Antal mord: {NumberOfMurders}");
            Console.WriteLine ($"{CityInfoArrests}\n{CityInfoMuggins}\n");
        }
        public static void GenerateActivity(List<Person> personlist)
        {
            CityInfoArrests = " ";
            CityInfoMuggins = " ";
            Muggin(personlist);
            Arrest(personlist);
        }

        private static bool ProbabilityTrue(int percent)
        {
            Random Random = new Random();
            int RandomNummer = Random.Next(1, 100 + 1);
            return RandomNummer <= percent;
        }
        private static void Murder(Person Citizen,List<Person> personList )
        {
            //int x = personList.IndexOf(Citizen);
            //personList.RemoveAt(x);
            Citizen = new Ghost(0,0,0," ");
        }

    }
}