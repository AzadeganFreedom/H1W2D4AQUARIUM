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
        public Fishclass Fish;
        public AquariumClass Aquarium;
        public void PrepareProgram()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Fish.dat"))
            {
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "Fish.dat");
            }

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Aq.dat"))
            {
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "Aq.dat");
            }
;
            LoadData();
        }
        public void LoadData()
        {
            string jsonData = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Fish.dat");
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                Fish.FishLists = JsonSerializer.Deserialize<List<Fishclass.FishObject>>(jsonData);
            }
            jsonData = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Aq.dat");
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                Aquarium.AquariumList = JsonSerializer.Deserialize<List<AquariumClass.AquariumObject>>(jsonData);

            }

        }
        public void SaveData()
        {
            string jsonData = JsonSerializer.Serialize(Fish.FishLists);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Fish.dat", jsonData);
            jsonData = JsonSerializer.Serialize(Aquarium.AquariumList);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Aq.dat", jsonData);
        }
    }
}
