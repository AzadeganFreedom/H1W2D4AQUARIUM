using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1W2D4AQUARIUM.Classes
{
    internal class MenuClass
    {
        string[] menuItems = new string[] { "Show Aquarium", "Show Fish", "Add Aquarium", "Delete Aquarium", "Add Fish", "Delete Fish", "", "Exit" };

        public void ShowMenu()
        {
            int menuCounter = 1;
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


        }
        public void SelectMenuItem(ConsoleKeyInfo consoleKey)
        {

            switch (consoleKey.Key)
            {
                case ConsoleKey.D1:
                    return;

                case ConsoleKey.D2:
                    return;

                case ConsoleKey.D3:
                    return;

                case ConsoleKey.D4:
                    return;

                case ConsoleKey.D5:
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
