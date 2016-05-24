using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace lesson4
{
    class JSon
    {
        public static void Run(IBike[] items)
        {
            var bike = items[0];
            
            Console.WriteLine(JsonConvert.SerializeObject(bike));

            // 2. ... with nicer formatting
            Console.WriteLine(JsonConvert.SerializeObject(bike, Formatting.Indented));

            // 3. serialize all items
            // ... include type, so we can deserialize sub-classes to interface type
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(items, settings));

            // 4. store json string to file "items.json" on your Desktop
            var text = JsonConvert.SerializeObject(items, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "items.json");
            File.WriteAllText(filename, text);

            // 5. deserialize items from "items.json"
            // ... and print Description and Price of deserialized items
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<IBike[]>(textFromFile, settings);
            var currency = Waehrung.EUR;
            foreach (var x in itemsFromFile) Console.WriteLine($"{x.Description} {x.Mod} {x.Preis.ConvertTo(currency).Amount,8:0.00} {currency}");
        }
    }
}