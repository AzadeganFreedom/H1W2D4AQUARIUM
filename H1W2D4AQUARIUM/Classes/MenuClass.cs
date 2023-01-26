using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace H1W2D4AQUARIUM.Classes
{
    internal class MenuClass
    {
        public AquariumClass Aquarium;
        public FishClass Fish;
        public DataClass Data;
        public ViewType CurrentViewType { get; set; }
        public int cursorStartingIndex { get; set; }

        public enum ViewType
        {
            Menu,
            Fish,
            Data,
            Aquarium
        }

        string[] menuItems = new string[] { "Show Aquarium", "Show Fish", "Add Aquarium", "Delete Aquarium", "Add Fish", "Delete Fish", "", "Exit" };

        public void ShowMenu()
        {
            int menuCounter = 1;

            Console.SetCursorPosition(0, 0);

            foreach (string menuText in menuItems)
            {
                if (menuText != "")
                {
                    Console.WriteLine($"{menuCounter}) {menuText}");
                    menuCounter++;
                }
                else
                {
                    Console.WriteLine();
                }
            }

            cursorStartingIndex = menuItems.Length + 2;

        }
        public void SelectMenuItem()
        {
            ConsoleKeyInfo consoleKey;

            Console.CursorVisible = false;
            consoleKey = Console.ReadKey(true);

            switch (consoleKey.Key)
            {
                case ConsoleKey.D1:
                    Aquarium.GetAquariumList();
                    CurrentViewType = ViewType.Aquarium;
                    return;

                case ConsoleKey.D2:
                    return;

                case ConsoleKey.D3:
                    Aquarium.CreateAquarium();
                    return;

                case ConsoleKey.D4:
                    return;

                case ConsoleKey.D5:
                    Fish.CreateFish();
                    return;

                case ConsoleKey.D6:
                    return;

                case ConsoleKey.D7:
                    return;

                default:
                    break;
            }


        }
    }
}
