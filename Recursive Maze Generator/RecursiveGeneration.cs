using System;
using System.Linq;
using System.Collections.Generic;

namespace Recursive_Maze_Generator
{
    class RecursiveGeneration
    {
        public static int[][] possibleDirections = new int[][] { new int[] { 0, -1 }, new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 } };

        static Random rnd = new Random();

        static int mazeSizeX, mazeSizeY;
        static bool[,] mazeArray;

        public static void GenerateMaze()
        {
            mazeSizeX = Program.mazeSizeX;
            mazeSizeY = Program.mazeSizeY;
            mazeArray = Program.mazeArray;

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
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(mazeArray[x, y] == false ? "██" : "  ");
                    }
                }
                Console.WriteLine();
            }

            DepthFirstTraversal.SearchMaze();
        }

        static void recursiveSearch(int currCellX, int currCellY)
        {
            bool[] possible = GetPossible(currCellX, currCellY);
            int[] chosenDirection;
            int randomDirection = -1;
            int possibleCount = possible.Count(p => p);

            while (!possible.All(p => !p))
            {
                possibleCount = possible.Count(p => p);
                randomDirection = rnd.Next(possibleCount);

                chosenDirection = possibleDirections[possible.TakeWhile(p => (randomDirection -= p ? 1 : 0) > -1).Count()];

                for (int i = 1; i < 3; i++)
                {
                    mazeArray[currCellX + i * chosenDirection[0], currCellY] = true;
                    mazeArray[currCellX, currCellY + i * chosenDirection[1]] = true;
                }

                recursiveSearch(currCellX + chosenDirection[0] * 2, currCellY + chosenDirection[1] * 2);

                possible = GetPossible(currCellX, currCellY);
            }

            return;
        }

        private static bool[] GetPossible(int CX, int CY)
        {
            bool[] possible = new bool[] { true, true, true, true };

            if (CY - 2 < 1 || mazeArray[CX, CY - 2])
            {
                possible[0] = false;
            }

            if (CX - 2 < 1 || mazeArray[CX - 2, CY])
            {
                possible[1] = false;
            }

            if (CX + 2 > mazeSizeX - 1 || mazeArray[CX + 2, CY])
            {
                possible[2] = false;
            }

            if (CY + 2 > mazeSizeY - 1 || mazeArray[CX, CY + 2])
            {
                possible[3] = false;
            }

            return possible;
        }
    }
}
