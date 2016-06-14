using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using static System.Console;
using System.Windows.Forms;

//synchron = blockiert bis das fertig ist, asynchron = kann dazwischen was anderes machen während auf Egebnis wartet

namespace lesson6
{
    public static class Async
    {

        public static async Task MyAsync()
        {
            Task<int> longtask = WaitAsync();
            int x = 0;
            while (x < 5)
            {
                Console.WriteLine($"{x}");
                await Task.Delay(500);
                x++;
            }

            int result = await longtask;

        }

        public static async Task<int> WaitAsync()
        {

            int i;
            for (i = 1; i < 10; i++)
            {
                await Task.Delay(1000); //eine Sekunde delay
                Console.WriteLine($"{i}");
                i++;
            }

            Console.WriteLine($"Done");

            return i;
        }


    }
}