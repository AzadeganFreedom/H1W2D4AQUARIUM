using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1W2D4AQUARIUM.Classes
{
    internal class Fishclass
    {
        public List<FishObject> FishLists = new List<FishObject>();
        public void CreateFish()
        {
            Console.Clear();
            FishObject NewFish = new FishObject();
            string output =
                "Species: \n" +
                "WaterType: \n" +
                "Aquarium: \n";
            Console.WriteLine(output);
            string species = "";
            string watertype = "";
            int aquarium = 0;
            while (true)
            {
                Console.SetCursorPosition(15, 0);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    NewFish.Species = input;
                }
            }
            while (true)
            {
                Console.SetCursorPosition(15, 1);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    NewFish.Watertype = input;
                    break;
                }
            }
            while (true)
            {
                Console.SetCursorPosition(15, 2);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (int.TryParse(input, out aquarium))
                    {
                        NewFish.Aquarium = aquarium;
                        break;
                    }
                }
            }
            //NewAquarium.AquariumId = 1;
            //AquariumList.Add(NewAquarium);
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
