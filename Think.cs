using System;
using System.Collections.Generic;

namespace Savannah
{
    public class Think
    {
        protected int fieldOfView = 9;

        public List<TempAnimal> TheLions = new List<TempAnimal>();
        public List<TempAnimal> TheAntilopes = new List<TempAnimal>();

        public TempAnimal TempLion;


        public void WatchAround(char[,] gameField, int[] myPostion)
        {
            int height = myPostion[0];
            int width = myPostion[1];
            int rowLimit = gameField.GetLength(0);
            int columnLimit = gameField.GetLength(1);
            int FoV = fieldOfView;

            if (height-fieldOfView < 0)
            {
                FoV = Math.Abs(height - fieldOfView);
                height = 0; 
            }

            if (width - fieldOfView < 0)
            {
                FoV = Math.Abs(width - fieldOfView);
                width = 0;
            }

            for (int heightPos = height; heightPos + FoV < rowLimit; heightPos++)
            {
                for (int widthPos = width; widthPos + FoV < columnLimit; widthPos++)
                {
                    if (!(heightPos < 0 ||
                          widthPos  < 0 ||
                          heightPos > rowLimit ||
                          widthPos  > columnLimit))
                    {
                        if (gameField[heightPos, widthPos] == 'L')
                        {
                            TempAnimal lion = new TempAnimal(heightPos, widthPos);
                            //TheLions.Add(lion);
                            TheLions.Add(FindDistance(lion, myPostion));
                            Console.WriteLine("lion position is: " + lion.heightPos + " " + lion.widthPos);
                        }
                    }
                }
            }
            
        }

        public TempAnimal FindDistance(TempAnimal lion, int[] myPosition)
        {
            int DistanceHeight = Math.Abs(myPosition[0] - lion.heightPos);
            int DistanceWidth = Math.Abs(myPosition[1] - lion.widthPos);

            if (DistanceHeight < DistanceWidth)
            {
                lion.Distance = DistanceHeight;
            }
            else
            {
                lion.Distance = DistanceWidth;
            };
            return lion;
        }

        public void SortByDistance()
        {
            TempAnimal tempLion;
            int lionCount = TheLions.Count;
            for (int j = 0; j < lionCount - 2; j++)
            {
                for (int i = 0; i < lionCount - 2; i++)
                {
                    //if (theLions[i] == null)
                    //{
                    //    return theLions;
                    //}
                    if (TheLions[i].Distance > TheLions[i + 1].Distance)
                    {
                        tempLion = TheLions[i + 1];
                        TheLions[i + 1] = TheLions[i];
                        TheLions[i] = tempLion;
                    }
                }
            }
            //return theLions;
        }

        public int[] findNextMove(int[] myPosition, int speed, char[,] field)
        {
            int[] nextPosition = new int[2];
            TempLion = TheLions[0];
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
