namespace Savannah
{
    public class Lion
    {
        public int hPos { get; set; }
        public int wPos { get; set; }
        public int Distance { get; set; }

        public Lion(int posH, int posW)
        {
            hPos = posH;
            wPos = posW;
           
        }

        public Lion( short distance)
        {
            Distance = distance;
        }
    }
}