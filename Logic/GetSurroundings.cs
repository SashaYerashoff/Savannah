namespace Savannah.Logic
{
    public class GetSurroundings
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
        private void WatchAround(IAnimal animal, IAnimal[,] field)
        {
            int watchDistance = animal.FieldOfView;
            int myHeightPos = animal.Position[0];
            int myWidthPos = animal.Position[1];

            for (int watchHeightPos = myHeightPos - watchDistance; watchHeightPos < field.GetLength(0); watchHeightPos++)
            {
                for (int watchWidthPos = myWidthPos - watchDistance; watchWidthPos < field.GetLength(1); watchWidthPos++)
                {
                    if ((watchHeightPos >= 0 || watchWidthPos >= 0) && field[watchHeightPos, watchWidthPos] != null)
                    {
                        Aknowledge(field[watchHeightPos, watchWidthPos], animal);
                    }
                }
            }
        }

        private void Aknowledge(IAnimal animal, IAnimal me)
        {
            if (animal is Predator && me is Prey)
            {
               // me.avoid();
            }
            if (animal is Prey && me is Prey)
            {
               // me.mate();
            }
            if (animal is Prey && me is Predator)
            {
               // me.feed();
            }

        }
    }
}
