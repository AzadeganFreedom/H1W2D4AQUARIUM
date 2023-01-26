using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace H1W2D4AQUARIUM.Classes
{
    internal class AquariumClass
    {
        public DataClass Data;
        public MenuClass Menu;
        public List<AquariumObject> AquariumList = new List<AquariumObject>();
        public string GetFriendlyName(int aquariumID)
        {
            foreach (AquariumObject aquarium in AquariumList)
            {
                if (aquarium.AquariumId == aquariumID)
                {
                    return aquarium.AquariumId + " " + aquarium.Name;
                }
            }
            return null;
        }

        public bool DoAquariumExist(int aquariumID)
        {
            foreach (AquariumObject aquarium in AquariumList)
            {
                if (aquarium.AquariumId == aquariumID)
                {
                    return true;
                }
            }

            return false;
        }

        public string GetAquariumList()
        {
            string output;

            Console.WriteLine();

            if (AquariumList.Count == 0)
            {
                return "";
            }

            output = "Id".PadRight(5) + "Name".PadRight(15) + "Watertype".PadRight(12) + "Temperature".PadRight(14) + "Size";
            Console.WriteLine(output);
            output = "";

            foreach (AquariumObject aquarium in AquariumList)
            {
                output = Convert.ToString(aquarium.AquariumId).PadRight(5) + aquarium.Name.PadRight(15) + aquarium.Watertype.PadRight(12) + Convert.ToString(aquarium.temperature).PadRight(14) + Convert.ToString(aquarium.Size);
                Console.WriteLine(output);
            }

            return "";
        }

        private int FindAvailableId()
        {
            if (AquariumList.Count == 0)
            {
                return 1;
            }

            int nextId = AquariumList.Max(id => id.AquariumId) + 1;

            return nextId;
        }

        public void CreateAquarium()
        {
            Console.CursorVisible = true;

            AquariumObject NewAquarium = new AquariumObject();

            Console.SetCursorPosition(0, Menu.cursorStartingIndex);
            string output =
                "Name: \n" +
                "Size: \n" +
                "Watertype f/s: \n" +
                "Temperature: \n";

            Console.WriteLine(output);

            int size = 0;

            while (true)
            {
                Console.SetCursorPosition(15, Menu.cursorStartingIndex + 0);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    NewAquarium.Name = input;
                    break;
                }

            }

            while (true)
            {
                Console.SetCursorPosition(15, Menu.cursorStartingIndex + 1);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (int.TryParse(input, out size))
                    {
                        NewAquarium.Size = size;
                        break;
                    }
                }
            }

            string watertype = "";
            while (true)
            {
                Console.SetCursorPosition(15, Menu.cursorStartingIndex + 2);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (input.ToLower() == "f" || input.ToLower() == "s")
                    {
                        NewAquarium.Watertype = input;
                        break;
                    }
                }
            }

            double temperature = 0;
            while (true)
            {
                Console.SetCursorPosition(15, Menu.cursorStartingIndex + 3);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (double.TryParse(input, out temperature))
                    {
                        NewAquarium.temperature = temperature;
                        break;
                    }
                }
            }

            NewAquarium.AquariumId = FindAvailableId();
            AquariumList.Add(NewAquarium);
            Data.SaveData("aquarium");
        }

        public void DeleteAquarium()
        {
            Console.WriteLine("Which Aquarium would like to delete?");
            Console.Write("Aquarium ID: ");

            int aquariumID = 0;
            while (true)
            {
                Console.SetCursorPosition(15, Menu.cursorStartingIndex + 1);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (int.TryParse(input, out aquariumID)&& DoAquariumExist(aquariumID))
                    {                        
                        break;
                    }
                }
            }

            for (int i = 0; i < AquariumList.Count; i++)
            {
                if (AquariumList[i].AquariumId == aquariumID)
                {
                    AquariumList.RemoveAt(i);
                    Data.SaveData("aquarium");
                    return;
                }
            }
        }

        public class AquariumObject
        {
            public int AquariumId { get; set; }
            public string Name { get; set; }
            public double temperature { get; set; }
            public int Size { get; set; }
            public string Watertype { get; set; }
        }
    }
}
