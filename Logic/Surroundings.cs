using Savannah;
using System;
using System.Collections.Generic;

namespace Savannah.Logic
{
    
    public class Surroundings
    {
        
        public void AnalizeField(IAnimal[,] field)
        {
            foreach (IAnimal cell in field)
            {
                if (cell != null)
                {
                    WatchAround(cell, field);
                    
                }
            }

        }
        private void WatchAround(IAnimal me, IAnimal[,] field)
        {
            int watchDistance = me.FieldOfView;
            int myHeightPos = me.Position[0];
            int myWidthPos = me.Position[1];

            for (int watchHeightPos = myHeightPos - watchDistance; watchHeightPos < field.GetLength(0); watchHeightPos++)
            {
                for (int watchWidthPos = myWidthPos - watchDistance; watchWidthPos < field.GetLength(1); watchWidthPos++)
                {
                    if (!(watchHeightPos < 0 || watchWidthPos < 0) && field[watchHeightPos, watchWidthPos] != null)
                    {
                        
                        
                        Aknowledge(field[watchHeightPos, watchWidthPos], me, field);
                        
                    }
                }
            }
        }


        private void Aknowledge(IAnimal animal, IAnimal me, IAnimal[,] field)
        {
            
            if (animal is Predator && me is Prey)
            {
                int[] tempPosition = me.Position;
                me.Position = Avoid(animal, me);
                field[tempPosition[0], tempPosition[1]] = null;
                field[me.Position[0], me.Position[1]] = me;
                return;
            }
            if (animal is Prey && me is Prey)
            {
                // me.mate();
            }
            if (animal is Prey && me is Predator)
            {
                int[] tempPosition = me.Position;
                me.Position = Approach(animal, me);
                field[tempPosition[0], tempPosition[1]] = null;
                field[me.Position[0], me.Position[1]] = me;
            }

        }

        private int[] Avoid(IAnimal predator, IAnimal me)
        {
            int myHeight = me.Position[0];
            int myWidth  = me.Position[1];
            int avoidHeight = predator.Position[0];
            int avoidWidth  = predator.Position[1];
            int[] nextPosition = new int[2];

            FindNextMove find = new FindNextMove();
            nextPosition[0] = find.AvoidAnimal(avoidHeight, myHeight, 26, 1);
            nextPosition[1] = find.AvoidAnimal(avoidWidth, myWidth, 26, 1);

            return nextPosition;
        }

        private int[] Approach(IAnimal prey, IAnimal me)
        {
            int myHeight = me.Position[0];
            int myWidth = me.Position[1];
            int approachHeight = prey.Position[0];
            int approachWidth = prey.Position[1];
            int[] nextPosition = new int[2];

            FindNextMove find = new FindNextMove();
            nextPosition[0] = find.ApproachAnimal(approachHeight, myHeight, 26, 1);
            nextPosition[1] = find.ApproachAnimal(approachWidth, myWidth, 26, 1);

            return nextPosition;
        }
    }
}
