using System;

namespace Savannah.Render
{
    public class RenderField
    {
        public void DrawField(IAnimal[,] GameField)
        {
            //Console.Write("          Press L for lion or A for antilope");
            Console.SetCursorPosition(1, 1);
            Console.CursorVisible = false;
            for (int height = 1; height < GameField.GetLength(0); height++)
            {
                for (int width = 0; width < GameField.GetLength(1) - 1; width++)
                {
                    if (GameField[height, width] == null)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ", Console.BackgroundColor);

                    }
                    if (GameField[height, width] != null)
                    {
                        Console.Write(GameField[height, width].Avatar + " ");
                    }
                }
                Console.WriteLine();
                Console.SetCursorPosition(1, height);
            }
        }
        public void DrawBorders(IAnimal[,] GameField)
        {
            Console.SetCursorPosition(0, 0);
            for (int height = 0; height < GameField.GetLength(0); height++)
            {
                for (int width = 0; width < GameField.GetLength(1); width++)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.Write("  ", Console.BackgroundColor);
                }
                Console.WriteLine();
            }
        }
    }
}
