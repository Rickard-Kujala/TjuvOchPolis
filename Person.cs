using System;
using System.Collections.Generic;

namespace TjuvOchPolis
{
    abstract class Person
    {
        public int CurentPositionX { get; set; }
        public int CurentPositionY { get; set; }
        public int Direction { get; set; }
        public string Token { get; set; }
        public List<Belongings> Inventory { get; set; }


        //public static List<Belongings> Inventory = new List<Belongings>();

        public static List<Person> PersonList = new List<Person>();

        public Person(int curentpositionX, int curentpositionY, int direction, string token)
        {
            CurentPositionX = curentpositionX;
            CurentPositionY = curentpositionY;
            Direction = direction;
            Token = token;
        }
    }
}
