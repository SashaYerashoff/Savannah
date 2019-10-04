using System;
using System.Collections.Generic;
using System.Text;

namespace Savannah
{
    public class Prey : IAnimal
    {
        public int[] Position { get; set; }
        public int Health { get; set ; }
        public int Speed { get; set; }
        public int FieldOfView { get; set; }
        public char Avatar { get; set; }

        public Prey(int[] position, int health, int speed, int fieldOfView, char avatar)
        {
            Position = position;
            Health = health;
            Speed = speed;
            FieldOfView = fieldOfView;
            Avatar = avatar;
        }
        public char[,] Die(char[,] gameField, int[] currentPosition)
        {
            //Field.RemoveAnimal(gameField, currentPosition);
            return gameField;
        }

        public char[,] Move(char[,] gameField, int[] currentPosition, char avatar)
        {
            gameField[currentPosition[0], currentPosition[1]] = avatar;
            return gameField;
        }

        public void GiveBirth(int[] position)
        {
            Position[0] = position[0];
            Position[1] = position[1];
            Health = 100;
            FieldOfView = 3;
            Avatar = 'A';
        }

        public int[] WatchAround(char[,] gameField)
        {
            throw new NotImplementedException();
        }
    }
}
