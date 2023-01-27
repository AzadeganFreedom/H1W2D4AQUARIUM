using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static H1W2D4AQUARIUM.Classes.AquariumClass;
using static System.Collections.Specialized.BitVector32;

namespace H1W2D4AQUARIUM.Classes
{
    internal class FishClass
    {
        public DataClass Data;
        public AquariumClass Aquarium;
        public List<FishObject> FishList = new List<FishObject>();
        public MenuClass Menu;


        public void ShowCreateFishViewModel()
        {
            Console.WriteLine("Fish:\n");

            if (Aquarium.AquariumList.Count == 0)
            {
                Console.Write("You need to have an aquarium before you can get fish, or they will");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("DIE!!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            string output =
                "Name: \n" +
                "Species: \n" +
                "Watertype f/s: \n" +
                "Aquarium: \n";

            Console.WriteLine(output);
            Console.WriteLine();
            Console.Write(Aquarium.ShowAquariumList());

        }

        public void AddFish()
        {
            FishObject NewFish = new FishObject();

            Console.CursorVisible = true;
            Console.WriteLine("Fish:\n");

            string output =
                "Name: \n" +
                "Species: \n" +
                "Watertype f/s: \n" +
                "Aquarium: \n";

            Console.WriteLine(output);
            Console.WriteLine();
            Console.Write(Aquarium.ShowAquariumList());

            int startingLine = 5;

            while (true)
            {
                Console.SetCursorPosition(15, startingLine + 0);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    NewFish.Name = input;
                    break;
                }
            }


            while (true)
            {
                Console.SetCursorPosition(15, startingLine + 1);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    NewFish.Species = input;
                    break;
                }
            }


            while (true)
            {
                Console.SetCursorPosition(15, startingLine + 2);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (input.ToLower() == "f" || input.ToLower() == "s")
                    {
                        NewFish.Watertype = input;
                    }
                    break;
                }
            }

            int aquarium = 0;
            while (true)
            {
                Console.SetCursorPosition(15, startingLine + 3);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (int.TryParse(input, out aquarium) && Aquarium.DoAquariumExist(aquarium))
                    {
                        NewFish.Aquarium = aquarium;
                        break;
                    }
                }
            }

            if (NewFish.Watertype == Aquarium.GetAquariumDetails(NewFish.Aquarium).Watertype)
            {
                NewFish.FishId = FindAvailableId();
                FishList.Add(NewFish);
                Data.SaveData("fish");
                Menu.MenuItemIsActive = false;
                return;
            }

            Console.WriteLine("\nYou put the fish in the wrong tank and it died\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("YOU MONSTER !!!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorVisible = false;
            Console.ReadKey();


        }

        public void RemoveFish(int fishPos)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You are currently trying to delete this item :");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(GetFriendlyName(FishList[fishPos].FishId));
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("This action cannot be undone. \n are you sure this is what you want to do?");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("y/n");

            bool DeleteThis = Menu.ConfirmAction();

            if (DeleteThis)
            {
                FishList.RemoveAt(fishPos);
                Data.SaveData("fish");
                Menu.MenuItemIsActive = false;
                Menu.ShowMenu();
            }

        }

        public string GetFriendlyName(int id)
        {
            foreach (FishObject fish in FishList)
            {
                if (fish.FishId == id)
                {
                    return "[" + fish.FishId + "] " + fish.Name;
                }
            }
            return null;

        }

        public string ShowFishList()
        {
            string output;

            if (FishList.Count == 0)
            {
                return "";
            }

            Console.WriteLine("Fish:\n");

            output = "Id".PadRight(5) + "Name".PadRight(15) + "Species".PadRight(12) + "Aquarium".PadRight(25) + "WaterType";
            Console.WriteLine(output);
            output = "";

            for (int i = 0; i < FishList.Count; i++)
            {
                FishObject fish = FishList[i];

                if (Menu.MenuItemIsActive && Menu.VerticalMenuItemSelected == i)
                {
                    Menu.HoverEfftect(true);
                }

                output = Convert.ToString(fish.FishId).PadRight(5) + fish.Name.PadRight(15) + fish.Species.PadRight(12) + Aquarium.GetFriendlyName(fish.Aquarium).PadRight(25) + fish.Watertype;
                Console.WriteLine(output);

                if (Menu.MenuItemIsActive)
                {
                    Menu.HoverEfftect(false);
                }

            }

            return "";
        }

        private int FindAvailableId()
        {
            if (FishList.Count == 0)
            {
                return 1;
            }

            int nextId = FishList.Max(id => id.FishId) + 1;

            return nextId;
        }

        public class FishObject
        {
            public int FishId { get; set; }
            public string Name { get; set; }
            public int Aquarium { get; set; }
            public string Species { get; set; }
            public string Watertype { get; set; }
        }
    }
}
