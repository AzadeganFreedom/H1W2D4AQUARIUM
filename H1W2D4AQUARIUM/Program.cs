using H1W2D4AQUARIUM.Classes;

namespace H1W2D4AQUARIUM
{
    internal class Program
    {
        static MenuClass Menu = new MenuClass();
        static FishClass Fish = new FishClass();
        static AquariumClass Aquarium = new AquariumClass();
        static DataClass Data = new DataClass();
        static void Main(string[] args)
        {
            // Build references
            Data.Aquarium = Aquarium;
            Data.Fish = Fish;

            Fish.Aquarium = Aquarium;
            Fish.Menu = Menu;

            Aquarium.Data = Data;
            Fish.Data = Data;
            Menu.Data = Data;

            Menu.Fish = Fish;
            Menu.Aquarium = Aquarium;

            Data.PrepareProgram();


            while (true)
            {
                Menu.ShowMenu();
                Menu.SelectMenuItem();
            }

        }
    }
}