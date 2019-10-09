using System;
using System.Collections.Generic;

namespace Savannah
{
    public class Think
    {
        public List<TempAnimal> Predators = new List<TempAnimal>();
        public List<TempAnimal> Preys = new List<TempAnimal>();

        public TempAnimal TempPredator;


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

                    for (int heightPos = myHeight - FOV; heightPos + FOV < rowLimit - 1; heightPos++)
                    {
                        for (int widthPos = myWidth - FOV; widthPos + FOV < columnLimit - 1; widthPos++)
                        {
                            if (!(heightPos < 0 || widthPos < 0) &&
                                  gameField[heightPos, widthPos] != null)
                            {
                                if (gameField[heightPos, widthPos] is Predator)
                                {
                                    TempAnimal predator = new TempAnimal(heightPos, widthPos);
                                    int[] myPosition = new int[] { myHeight, myWidth };
                                    Predators.Add(FindDistance(predator, myPosition));
                                    SortByDistance();
                                    Logic.FindNextMove findMove = new Logic.FindNextMove();
                                    findMove.findNextMove(gameField, animal, Predators);
                                }
                                if (gameField[heightPos, widthPos] is Prey)
                                {
                                    TempAnimal prey = new TempAnimal(heightPos, widthPos);
                                    int[] myPosition = new int[] { myHeight, myWidth };
                                    Preys.Add(FindDistance(prey, myPosition));
                                    SortByDistance();
                                }
                            }
                        }
                    }
                }
            }
        }

        public TempAnimal FindDistance(TempAnimal animal, int[] myPosition)
        {
            int DistanceHeight = Math.Abs(myPosition[0] - animal.heightPos);
            int DistanceWidth = Math.Abs(myPosition[1] - animal.widthPos);

            int shortestWay = (int)Math.Round(Math.Sqrt(DistanceHeight * DistanceHeight + DistanceWidth * DistanceWidth));
            animal.Distance = shortestWay;
            return animal;
        }

        public void SortByDistance()
        {
            TempAnimal tempAnimal;
            int animalCount = Predators.Count;

            for (int j = 0; j < animalCount - 2; j++)
            {
                for (int i = 0; i < animalCount - 2; i++)
                {
                    if (Predators[i].Distance > Predators[i + 1].Distance)
                    {
                        tempAnimal = Predators[i + 1];
                        Predators[i + 1] = Predators[i];
                        Predators[i] = tempAnimal;
                    }
                }
            }
        }
    }       
}
