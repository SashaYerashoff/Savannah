using System;

namespace Savannah
{
    public class Prey : IAnimal
    {
        public int[] Position { get; set; }
        public int Health { get; set; }
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
    }
}
