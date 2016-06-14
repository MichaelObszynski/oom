using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;


namespace lesson6
{
    public static class Rx
    {
        public static void Run()
        {
            Subject<Rahmen> Rx = new Subject<Rahmen>();

            Rx.Where(x => x.Anzahl > 2).Subscribe((x) => Console.WriteLine($"Rahmen: {x.Produzent}, {x.Modell}"));

            Task.Run(() =>
            {
                Task.Delay(5000).Wait();
                Rx.OnNext(new Rahmen("KTM", "Ultra Sport 2016", 403.99m, Waehrung.EUR));
                Rx.OnNext(new Rahmen("Specialized", "1", 403.99m, Waehrung.USD));
                Rx.OnNext(new Rahmen("JapanBike", "JPB23", 5000.99m, Waehrung.JPY));
                Rx.OnNext(new Rahmen("Trek", "X-Caliber", 670.99m, Waehrung.EUR));
                Rx.OnNext(new Rahmen("KTM", "Ultra Sport 2015", 306.99m, Waehrung.EUR));
               

            }); //füllt das in einen neuen Task und macht es nebenbei


        }
    }
}