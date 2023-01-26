using H1W2D4AQUARIUM.Classes;

namespace H1W2D4AQUARIUM
{
    internal class Program
    {
        static MenuClass Menu = new MenuClass();
        static Fishclass Fish = new Fishclass();
        static AquariumClass Aquarium = new AquariumClass();
        static DataClass Data = new DataClass();
        static void Main(string[] args)
        {
            Data.Aquarium = Aquarium;
            Data.Fish = Fish;
            Aquarium.Data = Data;
            Menu.ShowMenu();
            Aquarium.CreateAquarium();
            Console.ReadKey();
        }
    }
}