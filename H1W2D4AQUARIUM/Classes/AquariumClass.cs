using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1W2D4AQUARIUM.Classes
{
    internal class AquariumClass
    {
        public DataClass Data;

        public List<AquariumObject> AquariumList = new List<AquariumObject>();
        public void CreateAquarium()
        {
            Console.Clear();
            AquariumObject NewAquarium = new AquariumObject();
            string output =
                "Size: \n" +
                "WaterType: \n" +
                "Tempurutre: \n";
            Console.WriteLine(output);
            int size = 0;
            double tempurutre =0;
            string watertype = "";
            while (true)
            {
                Console.SetCursorPosition(15, 0);
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
            while (true)
            {
                Console.SetCursorPosition(15, 1);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                        NewAquarium.WaterType = watertype;
                        break;
                }
            }
            while (true)
            {
                Console.SetCursorPosition(15, 2);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (double.TryParse(input,out tempurutre))
                    {
                        NewAquarium.Temp = tempurutre;
                        break;
                    }
                }
            }
            NewAquarium.AquariumId = 1;
            AquariumList.Add(NewAquarium);
        }
        public class AquariumObject
        {
            public int AquariumId { get; set; }
            public double Temp { get; set; }
            public int Size { get; set; }
            public string WaterType { get; set; }
        }
    }
}
