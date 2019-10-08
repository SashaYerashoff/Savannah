using System;
namespace Savannah
{
    public class Field
    {
        public IAnimal[,] GameField { get; set; }

        public void CreateField(int height, int width)
        {
            IAnimal[,] gameField = new IAnimal[height, width];
            GameField = gameField;
        }

        public void AddAnimal(IAnimal animal)
        {
            byte height = Convert.ToByte(animal.Position[0]);
            byte width  = Convert.ToByte(animal.Position[1]);
            GameField[height, width] = animal;
        }

        public void RemoveAnimal(IAnimal animal)
        {
            byte height = Convert.ToByte(animal.Position[0]);
            byte width  = Convert.ToByte(animal.Position[1]);
            GameField[height, width] = null;
        }


    }
}
