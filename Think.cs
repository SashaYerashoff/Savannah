namespace Savannah
{
    public class Think
    {
        protected int fieldOfView { get; set; }


        public Think(int FOV)
        {
            fieldOfView = FOV;
        }

        public Lion[] WatchAround(char[,] gameField, int[] currentPosition)
        {
            int height = currentPosition[0];
            int width = currentPosition[1];
            int rowLimit = gameField.GetLength(0);
            int columnLimit = gameField.GetLength(1);
            Lion[] TheLions = new Lion[10];
            short count = 0;

            for (int hPos = height - fieldOfView; hPos + fieldOfView < rowLimit; hPos++)
            {
                for (int wPos = width - fieldOfView; wPos + fieldOfView < columnLimit; wPos++)
                {
                    if (!(hPos < 0 ||
                          wPos < 0 ||
                          hPos > rowLimit ||
                          wPos > columnLimit))
                    {
                        if (gameField[hPos, wPos] == 'L')
                        {
                            Lion lion = new Lion(hPos, wPos);
                            TheLions[count] = lion;
                            FindNearest(lion, currentPosition);
                            count++;
                        }
                    }
                }
            }
            return TheLions;
        }

        public void FindNearest(Lion lion, int[] preyPosition)
        {
                if (preyPosition[0] < preyPosition[1] && 
                    preyPosition[0] < lion.hPos)
                {
                lion.Distance = lion.hPos - preyPosition[0];
                }
                    //return nextPos;
        }
    }
}
