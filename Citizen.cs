using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;

namespace TjuvOchPolis
{
    class Citizen : Person
    {
        public Citizen(int curentpositionX, int curentpositionY, int direction, string token, List<Belongings> inventory)
            : base(curentpositionX, curentpositionY, direction, token)
        {
            CurentPositionX = curentpositionX;
            CurentPositionY = curentpositionY;
            Direction = direction;
            Inventory = inventory;
        }
        public static void GenerateCitizens(int a)//Skapar x-antal medborgare med Readline, slumpar startpositioner, Lägger till i listan Person
        {
            for (int i = 0; i < a; i++)//slumpa startpositioner
            {
                Random r = new Random();
                int x = r.Next(0, 100);

                Random r1 = new Random();
                int y = r1.Next(0, 25);

                Random r2 = new Random();
                int z = r2.Next(1, 9);
                //Inventory.Add(new Belongings("Phone"));
                //Inventory.Add(new Belongings("Keys"));
                //Inventory.Add(new Belongings("Wallet"));
                //Inventory.Add(new Belongings("Money"));

                List<Belongings> Inventory = new List<Belongings>();
                Inventory.Add(new Belongings("telefon"));
                Inventory.Add(new Belongings("Nycklar"));
                Inventory.Add(new Belongings("Plånbok"));
                Inventory.Add(new Belongings("pengar"));


                PersonList.Add(new Citizen(x, y, z, "M", Inventory));
            }
        }

    }
}
