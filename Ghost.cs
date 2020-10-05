using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvOchPolis
{
    class Ghost : Person
    {
        public Ghost(int curentpositionX, int curentpositionY, int direction, string token)
            : base(curentpositionX, curentpositionY, direction, token)
        {
            CurentPositionX = curentpositionX;
            CurentPositionY = curentpositionY;
            Direction = direction;
        }


    }
}
