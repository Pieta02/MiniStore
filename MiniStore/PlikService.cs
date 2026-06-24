using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore
{
    internal class PlikService
    {
        public static void ZapiszProdukty(List<Produkt> produkty)
        {
            string json = JsonConvert.SerializeObject(produkty, Formatting.Indented);
            File.WriteAllText("produkty.json", json);
        }

        public static List<Produkt> WczytajProdukty()
        {
            if (!File.Exists("produkty.json"))
            {
                return new List<Produkt>();
            }

            string json = File.ReadAllText("produkty.json");

            if (String.IsNullOrWhiteSpace(json))
            {
                return new List<Produkt>();
            }

            return JsonConvert.DeserializeObject<List<Produkt>>(json) ?? new List<Produkt>();
        }
    }
}
