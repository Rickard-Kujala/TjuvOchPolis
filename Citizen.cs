using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Net.Http.Headers;
using System.Text;

namespace TjuvOchPolis
{
    class Citizen : Person
    {
        public Citizen(int curentpositionX, int curentpositionY, int direction, string token)
            : base(curentpositionX, curentpositionY, direction, token)
        {
            CurentPositionX = curentpositionX;
            CurentPositionY = curentpositionY;
            Direction = direction;
        }


        public static void GenerateCitizens(int a)//Skapar x-antal medborgare med Readline, slumpar startpositioner, Lägger till i listan Person
        {
            for (int i = 0; i < a; i++)//slumpa startpositioner
            {
                Random r = new Random();
                int x=r.Next(0,100);

                Random r1= new Random();
                int y= r1.Next(0,25);

                Random r2 = new Random();
                int z = r2.Next(1, 9);
                Inventory.Add(new Inventory("Phone"));
                Inventory.Add(new Inventory("Keys"));
                Inventory.Add(new Inventory("Wallet"));
                Inventory.Add(new Inventory("Money"));

                PersonList.Add(new Citizen(x, y, z, "M"));
            }
        }

    }
}
