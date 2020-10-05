using System;
using System.Collections.Generic;
using System.Threading;
namespace TjuvOchPolis
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.CursorVisible = false;
            List<Person> Personlist = GeneratePeople(30, 30, 30);
            while (true)
            {
                Console.Clear();

                Game.GenerateGameBoard(Personlist);
                Coallition.GenerateActivity(Personlist);

                Game.Move(Personlist);

            }

        }
        static List<Person> GeneratePeople(int numberOfCitizens, int numberOfThiefs, int numberOfPolices)
        {
            Citizen.GenerateCitizens(numberOfCitizens);
            Thief.GenerateThiefs(numberOfThiefs);
            Police.GeneratePolices(numberOfPolices);
            return Person.PersonList;
        }


    }
}
