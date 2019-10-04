using System;
using System.Threading;

namespace Savannah
{
    class Program
    {
        static void Main()
        {
            Console.WindowHeight = 32;
            Console.WindowWidth = 64;
            int fieldHeight = 28;
            int fieldWidth = 28;
            Field game = new Field();
            game.CreateField(fieldHeight, fieldWidth);

            bool exit = false;

            while (!exit)
            {
                
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.A)
                    {
                        Random random = new Random();
                        int[] animalPos = new int[] { random.Next(fieldHeight), random.Next(fieldWidth) };
                        Prey antilope = new Prey(animalPos, 100, 1, 10, 'A');
                        
                        game.AddAnimal(antilope.Position, antilope);
                    }
                    if (key == ConsoleKey.L)
                    {
                        Random random = new Random();
                        int[] animalPos = new int[] { random.Next(fieldHeight), random.Next(fieldWidth) };
                        Predator lion = new Predator(animalPos, 100, 1, 10, 'L');
                        
                        game.AddAnimal(lion.Position, lion);
                    }
                    if (key == ConsoleKey.Escape)
                    {
                        exit = true;
                    }
                }
                game.DrawField();

                Think think = new Think();
                think.WatchAround(game.GameField);
                //think.SortByDistance();


                //int[] NewPos = think.findNextMove(antilope.Position, antilope.Speed, game.GameField);

                //game.AddAnimal(NewPos, antilope.Avatar);
                Thread.Sleep(100);
            }
        }
    }
}
