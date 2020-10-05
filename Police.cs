using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvOchPolis
{
    class Police : Person
    {
        public Police(int curentpositionX, int curentpositionY, int direction, string token, List<Belongings> inventory)
            : base(curentpositionX, curentpositionY, direction, token)
        {
            CurentPositionX = curentpositionX;
            CurentPositionY = curentpositionY;
            Direction = direction;
            Token = token;
            Inventory = inventory;
        }
        public static void GeneratePolices(int a)//Skapar x-antal medborgare med Readline, slumpar startpositioner, Lägger till i listan Person
        {
            for (int i = 0; i < a; i++)//slumpa startpositioner
            {
                Random r = new Random();
                int x = r.Next(0, 100);
                Random r1 = new Random();
                int y = r1.Next(0, 25);
                Random r2 = new Random();
                int z = r2.Next(1, 9);
                List<Belongings> Inventory = new List<Belongings>();

                PersonList.Add(new Police(x, y, z, "P", Inventory));
            }
        }
    }
}
