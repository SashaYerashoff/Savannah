
namespace Savannah
{
    public interface IAnimal
    {
        int[] Position { get; set; }
        int Health { get; set; }
        int Speed { get; set; }
        char Avatar { get; set; }
        int FieldOfView { get; set; }
        //char Distance { get; set; }
    }
}
