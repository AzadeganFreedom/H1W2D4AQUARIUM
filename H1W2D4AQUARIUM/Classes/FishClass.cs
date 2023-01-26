using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1W2D4AQUARIUM.Classes
{
    internal class FishClass
    {
        public DataClass Data;
        public AquariumClass Aquarium;
        public List<FishObject> FishList = new List<FishObject>();
        public MenuClass Menu;


        public void CreateFish()
        {
            FishObject NewFish = new FishObject();

            string output =
                "Name: \n" +
                "Species: \n" +
                "Watertype f/s: \n" +
                "Aquarium: \n";

            Console.CursorVisible = true;
            Console.SetCursorPosition(0, Menu.cursorStartingIndex);
            Console.WriteLine(output);
            Console.WriteLine();
            Console.Write(Aquarium.GetAquariumList());


            while (true)
            {
                Console.SetCursorPosition(15, Menu.cursorStartingIndex + 0);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    NewFish.Name = input;
                    break;
                }
            }


            while (true)
            {
                Console.SetCursorPosition(15, Menu.cursorStartingIndex + 1);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    NewFish.Species = input;
                    break;
                }
            }


            while (true)
            {
                Console.SetCursorPosition(15, Menu.cursorStartingIndex + 2);
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
                Console.SetCursorPosition(15, Menu.cursorStartingIndex + 3);
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

            NewFish.FishId = FindAvailableId();
            FishList.Add(NewFish);
            Data.SaveData("fish");

            Console.Clear();

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
