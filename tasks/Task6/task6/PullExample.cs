using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
    {
    public static class PullExample
    {
        public static void Run()
        {
            var liste = new List<Rahmen> { };

            liste.Add(new Rahmen("KTM", "Ultra Sport 2016", 403.99m, Waehrung.EUR));
            liste.Add(new Rahmen("Specialized", "1", 403.99m, Waehrung.USD));
            liste.Add(new Rahmen("JapanBike", "JPB23", 5000.99m, Waehrung.JPY));
            liste.Add(new Rahmen("Trek", "X-Caliber", 670.99m, Waehrung.EUR));
            liste.Add(new Rahmen("KTM", "Ultra Sport 2015", 306.99m, Waehrung.EUR));
           
            var i = liste.GetEnumerator();
            while (i.MoveNext()) Console.WriteLine($"{i.Current} - Hersteller: {i.Current.Produzent}, Modell: {i.Current.Modell}");

            var liste2 = liste.Where((x) => x.Anzahl > 2); //Ausschnitt von erster Liste



        }
    }
}