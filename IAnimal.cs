using System;
using System.Collections.Generic;
using System.Text;

namespace Savannah
{
    public interface IAnimal
    {
        int[] Position { get; set; }
        int Health { get; set; }
        int Speed { get; set; }
        char Avatar { get; set; }
        int FieldOfView { get; set; }
        //surroundings<T> Animals { get; set }

        void NewAnimal(int[] position, char avatar);
        int[] WatchAround(char[,] gameField);
        int[] Move(int[] currentPosition, char Avatar);
        void Die(int[] currentPosition);
    }
}
