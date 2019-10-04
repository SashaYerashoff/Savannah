using System;
using System.Collections.Generic;

namespace Savannah
{
    public class Think
    {
        //protected int fieldOfView = 9;

        public List<TempAnimal> Predators = new List<TempAnimal>();
        public List<TempAnimal> Preys = new List<TempAnimal>();

        public TempAnimal TempLion;


        public void WatchAround(IAnimal[,] gameField)
        {

            int rowLimit = gameField.GetLength(0);
            int columnLimit = gameField.GetLength(1);

            foreach (IAnimal animal in gameField)
            {
                if (animal != null)
                {
                    int FOV = animal.FieldOfView;
                    int myHeight = animal.Position[0];
                    int myWidth = animal.Position[1];

                    for (int heightPos = myHeight - FOV; heightPos + FOV < rowLimit; heightPos++)
                    {
                        for (int widthPos = myWidth - FOV; widthPos + FOV < columnLimit; widthPos++)
                        {
                            if (!(heightPos < 0 || widthPos < 0) &&
                                  gameField[heightPos, widthPos] != null)
                            {
                                if (gameField[heightPos, widthPos].Avatar == 'L')
                                {
                                    TempAnimal lion = new TempAnimal(heightPos, widthPos);
                                    
                                    int[] myPosition = new int[] { myHeight, myWidth };
                                    Predators.Add(FindDistance(lion, myPosition));
                                    Console.WriteLine($"lion position is: {lion.heightPos} {lion.widthPos} distance from {myPosition[0]} {myPosition[1]} is {lion.Distance}");
                                }
                            }
                        }
                    }
                }
            }




        }

        public TempAnimal FindDistance(TempAnimal lion, int[] myPosition)
        {
            int DistanceHeight = Math.Abs(myPosition[0] - lion.heightPos);
            int DistanceWidth = Math.Abs(myPosition[1] - lion.widthPos);

            int shortestWay = (int)Math.Round( Math.Sqrt(DistanceHeight * DistanceHeight + DistanceWidth * DistanceWidth));
            lion.Distance = shortestWay;
            return lion;
        }

        public void SortByDistance()
        {
            TempAnimal tempLion;
            int lionCount = Predators.Count;

            for (int j = 0; j < lionCount - 2; j++)
            {
                for (int i = 0; i < lionCount - 2; i++)
                {
                    if (Predators[i].Distance > Predators[i + 1].Distance)
                    {
                        tempLion = Predators[i + 1];
                        Predators[i + 1] = Predators[i];
                        Predators[i] = tempLion;
                    }
                }
            }
            //return theLions;
        }

        public int[] findNextMove(int[] myPosition, int speed, char[,] field)
        {
            int[] nextPosition = new int[2];
            TempLion = Predators[0];
            int hPos = TempLion.heightPos;
            int wPos = TempLion.widthPos;

            nextPosition[0] = AvoidAnimal(hPos, myPosition[0], field.GetLength(0), speed);
            nextPosition[1] = AvoidAnimal(wPos, myPosition[1], field.GetLength(1), speed);

            return nextPosition;
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
