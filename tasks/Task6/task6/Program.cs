using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace lesson6
{
    class Bike
    {
        static void Main(string[] args)
        {
            PullExample.Run(); 

            PushExample1.Run();

            PushExample2.Run();

            PushExample3.Run();

            Rx.Run();

            Async.MyAsync().ContinueWith((t) => Console.WriteLine($"Ende")).Wait();

            var items = new IBike[]
             {
                new Rahmen("KTM", "Ultra Sport 2016", 403.99m, Waehrung.EUR),
                new Bremsen("Shimano", "Brake XS", 38500.60m, Waehrung.JPY),
                new Schaltwerk("Shimano", "Deore XTR", 56749.95m, Waehrung.JPY),
                new Reifen("Schwalbe", "Pro 751", 35.24m, Waehrung.EUR),
                new Rahmen("Santa Cruz", "SC1524", 2505.00m, Waehrung.USD),
                new Bremsen("Shimano", "Brake STS", 60500.60m, Waehrung.JPY),
                new Schaltwerk("Shimano", "Deore XTR", 56749.95m, Waehrung.JPY),
                new Reifen("Michelin", "MB 2020", 42.50m, Waehrung.EUR),

             };

            var waehrung = Waehrung.EUR;
            foreach (var x in items)
            {
                Console.WriteLine($"{x.Description} {x.Mod} {x.Preis.ConvertTo(waehrung).Amount,8:0.00} {waehrung} ");
            }

            JSon.Run(items);
        }
    }
}
