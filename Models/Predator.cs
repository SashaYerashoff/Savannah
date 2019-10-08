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
        //public char Distance { get; set; }


        public Predator(int[] position, int health, int speed, int fieldOfView, char avatar)
        {
            Position = position;
            Health = health;
            Speed = speed;
            FieldOfView = fieldOfView;
            Avatar = avatar;
        }
    }
}
