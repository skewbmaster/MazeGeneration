using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Recursive_Maze_Generator
{
    class Program
    {
        const int mazeSizeX = 21, mazeSizeY = 41;

        public static List<int[]> possibleDirections = new List<int[]> { new int[] { 0, -1 },
                                                                         new int[] { -1, 0 },
                                                                         new int[] { 1, 0 },
                                                                         new int[] { 0, 1 } };

        static Random rnd = new Random();
        static bool[,] mazeArray = new bool[mazeSizeX, mazeSizeY];

        static void Main(string[] args)
        {
            while (true)
            {
                GenerateMaze();
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void GenerateMaze()
        {
            for (int i = 0; i < mazeSizeX; i++)
            {
                for (int j = 0; j < mazeSizeY; j++)
                {
                    mazeArray[i, j] = false;
                }
            }

            recursiveSearch(1, 1);

            for (int x = 0; x < mazeSizeX; x++)
            {
                for (int y = 0; y < mazeSizeY; y++)
                {
                    if ((x == 1 && y == 0) || (x == mazeSizeX - 1 && y == mazeSizeY - 2))
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(mazeArray[x, y] == false ? "█" : " ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void recursiveSearch(int currCellX, int currCellY)
        {
            //Console.WriteLine("{0}, {1}", currCellX, currCellY);

            List<int[]> possible = GetPossible(currCellX, currCellY);
            int[] randomDirection;

            while (possible.Count > 0)
            {
                randomDirection = possible.ElementAt(rnd.Next(possible.Count));

                for (int i = 1; i < 3; i++)
                {
                    mazeArray[currCellX + i * randomDirection[0], currCellY] = true;
                    mazeArray[currCellX, currCellY + i * randomDirection[1]] = true;
                }

                recursiveSearch(currCellX + randomDirection[0] * 2, currCellY + randomDirection[1] * 2);

                possible = GetPossible(currCellX, currCellY);
            }

            return;
        }

        static List<int[]> GetPossible(int CX, int CY)
        {
            List<int[]> possible = new List<int[]>(possibleDirections);

            int offset = 0;

            if (CY - 2 < 1 || mazeArray[CX, CY - 2])
            {
                possible.RemoveAt(0);
                offset++;
            }

            if (CX - 2 < 1 || mazeArray[CX - 2, CY])
            {
                possible.RemoveAt(1 - offset);
                offset++;
            }

            if (CX + 2 > mazeSizeX - 1 || mazeArray[CX + 2, CY])
            {
                possible.RemoveAt(2 - offset);
                offset++;
            }

            if (CY + 2 > mazeSizeY - 1 || mazeArray[CX, CY + 2])
            {
                possible.RemoveAt(3 - offset);
            }

            return possible;
        }
    }
}
