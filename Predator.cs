using System;


namespace Savannah
{
    class Predator : IAnimal
    {
        public int[] Position { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public char Avatar { get; set; }
        public int FieldOfView { get; set; }

        public Predator(int[] position, int health, int speed, int fieldOfView, char avatar)
        {
            Position = position;
            Health = health;
            Speed = speed;
            FieldOfView = fieldOfView;
            Avatar = avatar;
        }

        public char[,] Die(char[,] gameField, int[] currentPosition)
        {
            throw new NotImplementedException();
        }

        public void GiveBirth(int[] position)
        {
            Position[0] = position[0];
            Position[1] = position[1];
            Health = 100;
            FieldOfView = 6;
            Avatar = 'L';
        }

        public char[,] Move(char[,] gameField, int[] currentPosition, char avatar)
        {
            throw new NotImplementedException();
        }

        public int[] WatchAround(char[,] gameField)
        {
            throw new NotImplementedException();
        }
    }
}
