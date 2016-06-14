using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace lesson6
{
    class JSon
    {
        public static void Run(IBike[] items)
        {
            var bike = items[0];

            Console.WriteLine(JsonConvert.SerializeObject(bike));

            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(items, settings));

            var text = JsonConvert.SerializeObject(items, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "items.json");
            File.WriteAllText(filename, text);

            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<IBike[]>(textFromFile, settings);
            var currency = Waehrung.EUR;
            foreach (var x in itemsFromFile) Console.WriteLine($"{x.Description} {x.Mod} {x.Preis.ConvertTo(currency).Amount,8:0.00} {currency}");


        }
    }
}