using System;
using System.Collections.Generic;


namespace Savannah.Logic
{
    public class FindNextMove
    {
        public void findNextMove(IAnimal[,] field, IAnimal animal, List<TempAnimal> AnimalsAround)
        {
            int[] nextPosition = new int[2];
            int[] myPosition = animal.Position;
            int hPos = AnimalsAround[0].heightPos;
            int wPos = AnimalsAround[0].widthPos;

            if (animal is Prey)
            {
                nextPosition[0] = AvoidAnimal(hPos, myPosition[0], field.GetLength(0), animal.Speed);
                nextPosition[1] = AvoidAnimal(wPos, myPosition[1], field.GetLength(1), animal.Speed);
            }
            else
            {
                nextPosition[0] = ApproachAnimal(hPos, myPosition[0], field.GetLength(0), animal.Speed);
                nextPosition[1] = ApproachAnimal(wPos, myPosition[1], field.GetLength(1), animal.Speed);
            }

           
            AddAnimal(animal, field);

        }
        public void AddAnimal(IAnimal animal, IAnimal[,] field)
        {
            byte height = Convert.ToByte(animal.Position[0]);
            byte width = Convert.ToByte(animal.Position[1]);
            field[height, width] = animal;
        }

        public int AvoidAnimal(int AnimalPos, int myPos, int fieldMax, int speed)
        {
            int nextPos;

            if (AnimalPos <= myPos && myPos + speed <= fieldMax)
            {
                nextPos = myPos + speed;
            }
            else if (AnimalPos > myPos && myPos - speed >= 0)
            {
                nextPos = myPos - speed;
            }
            else
            {
                nextPos = myPos;
            }
            return nextPos;
        }

        public int ApproachAnimal(int AnimalPos, int myPos, int fieldMax, int speed)
        {
            int nextPos;

            if (AnimalPos <= myPos && myPos + speed <= fieldMax)
            {
                nextPos = myPos - speed;
            }
            else if (AnimalPos > myPos && myPos - speed >= 0)
            {
                nextPos = myPos + speed;
            }
            else
            {
                nextPos = myPos;
            }
            return nextPos;
        }
    }
}

