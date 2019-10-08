using System;
using System.Threading;
using Savannah.Render;

namespace Savannah
{
    public class GameAssembly
    {
        public void Run()
        {
            Console.WindowHeight = 38;
            Console.WindowWidth = 120;
            int fieldHeight = 28;
            int fieldWidth = 28;
            Field game = new Field();
            game.CreateField(fieldHeight, fieldWidth);

            RenderField render = new RenderField();
            render.DrawBorders(game.GameField);

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

                        Prey antilope = 
                            new Prey(animalPos, Constants.Health, Constants.PreySpeed, Constants.PreyFOV,'A');

                        game.AddAnimal(antilope);
                    }
                    if (key == ConsoleKey.L)
                    {
                        
                        Random random = new Random();
                        int[] animalPos = new int[] { random.Next(fieldHeight), random.Next(fieldWidth) };

                        Predator lion = 
                            new Predator(animalPos, Constants.Health, Constants.LionSpeed, Constants.LionFOV, 'L');

                        game.AddAnimal(lion);
                    }
                    if (key == ConsoleKey.Escape)
                    {
                        exit = true;
                    }
                }

                render.DrawField(game.GameField);

                Think think = new Think();
                think.WatchAround(game.GameField);
                think.SortByDistance();

                Thread.Sleep(100);
            }
        }
    }
}