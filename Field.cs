using System;
using System.Collections.Generic;
using System.Text;

namespace Savannah
{
    public class Field
    {
        int[] dimensions = new int[2];

        public void CreateField(int height, int width)
        {
            char[,] gameField = new char[height, width];
            dimensions[0] = height;
            dimensions[1] = width;
        }

        public void AddAnimal (char[,] gameField, int[] position, char avatar)
        {
            gameField[position[0], position[1]] = avatar;
        }

        public void RemoveAnimal (char[,] gameField, int[] position)
        {
            char emptyPosition = ' ';
            gameField[position[0], position[1]] = emptyPosition;
        }

        public void DrawField(char[,] gamefield)
        {
            for (int height = 0; height < gamefield.GetLength(0); height++)
            {
                for (int width = 0; width < gamefield.GetLength(1); width++)
                {
                    Console.Write(gamefield[height, width]);
                }
                Console.WriteLine();
            }
        }
    }
}
