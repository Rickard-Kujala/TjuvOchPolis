using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;



namespace TjuvOchPolis
{
    class Game
    {
        public static Person[,] GameBoard = new Person[100, 25];
        private static int X = 100;
        private static int Y = 25;
        private static void EmptyBoard()
        {
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    GameBoard[j, i] = new Ghost(0, 0, 0, " ");
                }
            }
            foreach (var item in Person.PersonList)
            {
                GameBoard[item.CurentPositionX, item.CurentPositionY] = item;//Gameboard blir == X,y-kordnaterna
            }
        }
        public static void GenerateGameBoard(List<Person> personList)
        {
            EmptyBoard();
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    Console.Write(GameBoard[j, i].Token);
                }
                Console.WriteLine();
            }
        }
        public static void Move(List<Person> personList)
        {
            foreach (var item in personList)
            {
                switch (item.Direction)
                {
                    case 1://Höger
                        item.CurentPositionX++;
                        if (item.CurentPositionX == X)
                        {
                            item.CurentPositionX = 0;
                        }
                        break;
                    case 2://Vänster
                        item.CurentPositionX--;
                        if (item.CurentPositionX == -1)
                        {
                            item.CurentPositionX = X - 1;
                        }
                        break;
                    case 3://upp
                        item.CurentPositionY--;
                        if (item.CurentPositionY == -1)
                        {
                            item.CurentPositionY = Y - 1;
                        }
                        break;
                    case 4://Ner
                        item.CurentPositionY++;
                        if (item.CurentPositionY == Y)
                        {
                            item.CurentPositionY = 0;
                        }

                        break;
                    case 5://Diagonalt upp höger
                        item.CurentPositionX++;
                        item.CurentPositionY--;
                        if (item.CurentPositionY == -1)
                        {
                            item.CurentPositionY = Y - 1;
                        }
                        if (item.CurentPositionX == X)
                        {
                            item.CurentPositionX = 0;
                        }
                        else if (item.CurentPositionX == X && item.CurentPositionY == -1)
                        {
                            item.CurentPositionX = 0;
                            item.CurentPositionY = Y - 1;
                        }
                        break;
                    case 6://Diagonalt ner vänster
                        item.CurentPositionX--;
                        item.CurentPositionY++;
                        if (item.CurentPositionY == Y)
                        {
                            item.CurentPositionY = 0;
                        }
                        if (item.CurentPositionX == -1)
                        {
                            item.CurentPositionX = X - 1;
                        }
                        else if (item.CurentPositionX == -1 && item.CurentPositionY == Y)
                        {
                            item.CurentPositionX = X - 1;
                            item.CurentPositionY = 0;
                        }
                        break;
                    case 7://Diagonalt upp vänster
                        item.CurentPositionX--;
                        item.CurentPositionY--;
                        if (item.CurentPositionX == -1)
                        {
                            item.CurentPositionX = X - 1;
                        }
                        if (item.CurentPositionY == -1)
                        {
                            item.CurentPositionY = Y - 1;
                        }
                        else if (item.CurentPositionX == -1 && item.CurentPositionY == -1)
                        {
                            item.CurentPositionX = X - 1;
                            item.CurentPositionY = Y - 1;
                        }
                        break;
                    case 8://Diagonalt ner höger
                        item.CurentPositionX++;
                        item.CurentPositionY++;
                        if (item.CurentPositionX == X)
                        {
                            item.CurentPositionX = 0;
                        }
                        if (item.CurentPositionY == Y)
                        {
                            item.CurentPositionY = 0;
                        }
                        else if (item.CurentPositionX == X && item.CurentPositionY == Y)
                        {
                            item.CurentPositionX = 0;
                            item.CurentPositionY = 0;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
