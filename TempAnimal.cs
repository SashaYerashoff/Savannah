namespace Savannah
{
    public class TempAnimal
    {
        public int heightPos { get; set; }
        public int widthPos { get; set; }
        public int Distance { get; set; }

        public TempAnimal(int posH, int posW)
        {
            heightPos = posH;
            widthPos = posW; 
        }

        public TempAnimal( short distance)
        {
            Distance = distance;
        }
    }
}