using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive_Maze_Generator
{
    class DepthFirstTraversal
    {
        public static int[][] possibleDirections = new int[][] { new int[] { 0, -1 }, new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 } };

        int mazeSizeX, mazeSizeY;

        static bool[,] maze;
        static int[] stack;
        //static BinaryBool[] vertices;

        int stackPointer = 0;

        public void SearchMaze()
        {
            mazeSizeX = Program.mazeSizeX;
            mazeSizeY = Program.mazeSizeY;
            
            int halfX = mazeSizeX / 2, halfY = mazeSizeY / 2;

            maze = Program.mazeArray;

            stack = new int[halfX * halfY];

            nextDirection(1, 1);

            // X points are sizeX / 2 and same for Y
        }

        private bool nextDirection(int cx, int cy)
        {
            bool[] currentPossible;
            int[] currentDirection;

            if (cx == mazeSizeX - 1 && cy == mazeSizeY - 2)
            {
                return true;
            }

            currentPossible = GetPossible(cx, cy);

            for (int p = 0; p < 4; p++)
            {
                if (currentPossible[p])
                {
                    currentDirection = possibleDirections[p];

                    stack[stackPointer] = p;
                    stackPointer++;

                    if (nextDirection(cx + currentDirection[0] * 2, cy + currentDirection[1] * 2))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        private bool[] GetPossible(int CX, int CY)
        {
            bool[] possible = new bool[] { false, false, false, false };

            if (maze[CX, CY - 1])
            {
                possible[0] = true;
            }
            if (maze[CX - 1, CY])
            {
                possible[1] = true;
            }
            if (maze[CX + 1, CY])
            {
                possible[2] = true;
            }
            if (maze[CX, CY + 1])
            {
                possible[3] = true;
            }

            return possible;
        }
    }

    internal struct BinaryBool
    {
        long Word;

        public BinaryBool(long word)
        {
            Word = word;
        }

        public bool getAtBit(short bit)
        {
            return (Word & ((long)1 << bit)) != 0;
        }

        public void flipAtBit(short bit)
        {
            Word ^= (long)1 << bit;
        }
    }
}
