using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1W2D4AQUARIUM.Classes
{
    internal class DataClass
    {
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

        }
    }
}
