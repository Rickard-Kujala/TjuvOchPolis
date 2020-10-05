using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace TjuvOchPolis
{
    class Coallition
    {
        public static int NumberOfMuggins = 0;
        public static int NumberOfArrests = 0;
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
                        if (tmpPerson.Inventory.Count > 0)
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
        public static string Arrest(List<Person> personList)
        {
            string info = " ";
            //int nmbrArrests = 0;
            foreach (var item in personList)
            {
                var tmpPerson = item;
                foreach (var person in personList)
                {
                    if (tmpPerson is Thief && person is Police && tmpPerson.CurentPositionX == person.CurentPositionX
                                                                && tmpPerson.CurentPositionY == person.CurentPositionY
                                                                /*&& tmpPerson.Inventory.Count>0*/)
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
                            CityInfoArrests = "Den misstänkte hade hade inget stöldgods på sig och sätts på fri fot i staden! ";
                        }
                    }
                }
            }
            return info;
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 26);
            Console.WriteLine($"Antal rån i staden: {NumberOfMuggins}");
            Console.WriteLine($"Antal gripna: {NumberOfArrests}");
            Console.WriteLine(CityInfoArrests);

            Console.WriteLine(CityInfoMuggins);

        }
        public static void GenerateActivity(List<Person> personlist)
        {
            CityInfoArrests = " ";
            CityInfoMuggins = " ";
            Muggin(personlist);
            Arrest(personlist);
        }


    }
}