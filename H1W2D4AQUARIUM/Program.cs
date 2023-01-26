using H1W2D4AQUARIUM.Classes;

namespace H1W2D4AQUARIUM
{
    internal class Program
    {
        static MenuClass Menu = new MenuClass();
        static void Main(string[] args)
        {
            Menu.ShowMenu();
            Console.ReadKey();
        }
    }
}