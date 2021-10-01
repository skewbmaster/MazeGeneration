using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Recursive_Maze_Generator
{
    class Program
    {
        public const int mazeSizeX = 21;
        public const int mazeSizeY = 21;

        public static bool[,] mazeArray = new bool[mazeSizeX, mazeSizeY];

        static void Main(string[] args)
        {
            while (true)
            {
                RecursiveGeneration.GenerateMaze();
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
