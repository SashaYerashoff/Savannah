using System;
using System.Collections.Generic;
using System.Text;

namespace Savannah
{
    public class Prey : IAnimal
    {
        //char Avatar = 'A';
        char Evil = 'L';

        public int[] Position { get; set; }
        public int Health { get; set ; }
        public int Speed { get; set; }
        public int FieldOfView { get; set; }
        public char Avatar { get; set; }

        public void Die(int[] currentPosition)
        {
            throw new NotImplementedException();
        }

        public char[,] Move(char[,] gameField, int[] currentPosition, char avatar)
        {
            gameField[currentPosition[0], currentPosition[1]] = avatar;
            return gameField;
        }

        public void NewAnimal(int[] position, char avatar)
        {
            Random rand = new Random();
            Position[0] = position[0];
            Position[1] = position[1];
            Health = 100;
            FieldOfView = 3;
            Avatar = avatar;
        }

        public int[] WatchAround(char[,] gameField)
        {
            throw new NotImplementedException();
        }
    }
}
