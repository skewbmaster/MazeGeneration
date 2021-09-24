using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive_Maze_Generator
{
    class DepthFirstTraversal
    {
        bool[,] maze, vertices;
        int[] stack;

        public void SearchMaze()
        {
            maze = Program.mazeArray;

            vertices = new bool[Program.mazeSizeX / 2, Program.mazeSizeY / 2];

            stack = new int[vertices.Length];

            for (int i = 0; i < vertices.Length; i++)
            {
                for (int j = 0; j < vertices.GetLength(i); j++)
                {
                    vertices[i, j] = true;
                }
            }
            
            // X points are sizeX / 2 and same for Y
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
}
