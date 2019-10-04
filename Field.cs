using System;

namespace Savannah
{
    public class Field
    {
        public int[] dimensions = new int[2];
        public IAnimal[,] GameField { get; set; }

        public void CreateField(int height, int width)
        {
            IAnimal[,] gameField = new IAnimal[height, width];
            dimensions[0] = height;
            dimensions[1] = width;
            GameField = gameField;
        }

        public void AddAnimal(int[] position, IAnimal animal)
        {
            GameField[position[0], position[1]] = animal;
        }

        public void RemoveAnimal(IAnimal[,] gameField, int[] position)
        {
            //char emptyPosition = ' ';
            gameField[position[0], position[1]] = null;
        }

        public void DrawField()
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            for (int height = 0; height < GameField.GetLength(0); height++)
            {
                for (int width = 0; width < GameField.GetLength(1); width++)
                {
                    if (GameField[height, width] == null)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(GameField[height, width].Avatar + " ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
