﻿
namespace Savannah
{
    public interface IAnimal
    {
        int[] Position { get; set; }
        int Health { get; set; }
        int Speed { get; set; }
        char Avatar { get; set; }
        int FieldOfView { get; set; }
        

        void GiveBirth(int[] position, char avatar);
        int[] WatchAround(char[,] gameField);
        char[,] Move(char[,] gameField, int[] currentPosition, char avatar);
        char[,] Die(char[,] gameField, int[] currentPosition);
    }
}
