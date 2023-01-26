using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace H1W2D4AQUARIUM.Classes
{
    internal class DataClass
    {
        public FishClass Fish;
        public AquariumClass Aquarium;

        public void PrepareProgram()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Fish.dat"))
            {
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "Fish.dat");
            }

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Aqaurium.dat"))
            {
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "Aqaurium.dat");
            }
;
            LoadData();
        }
        public void LoadData()
        {
            string jsonData = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Fish.dat");
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                Fish.FishList = JsonSerializer.Deserialize<List<FishClass.FishObject>>(jsonData);
            }


            jsonData = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Aqaurium.dat");
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                Aquarium.AquariumList = JsonSerializer.Deserialize<List<AquariumClass.AquariumObject>>(jsonData);
            }

        }
        public void SaveData(string arg)
        {
            string jsonData;

            if (arg == "all" || arg == "fish")
            {
                jsonData = JsonSerializer.Serialize(Fish.FishList);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Fish.dat", jsonData);
            }

            if (arg == "all" || arg == "aquarium")
            {
                jsonData = JsonSerializer.Serialize(Aquarium.AquariumList);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Aqaurium.dat", jsonData);
            }
        }
    }
}
