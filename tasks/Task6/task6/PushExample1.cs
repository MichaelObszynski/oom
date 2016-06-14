
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace lesson6

{
    public static class PushExample1
    {
        
        public static void Run()
        {
            var w = new Form() { Text = "Push Example", Width = 800, Height = 600 };

        
            w.MouseMove += (s, e) => WriteLine($"[MouseMove event] ({e.X}, {e.Y})");

           
            IObservable<Point> moves = Observable.FromEventPattern<MouseEventArgs>(w, "MouseMove").Select(x => x.EventArgs.Location);
            
            moves
                .Throttle(TimeSpan.FromSeconds(0.2))
                .DistinctUntilChanged()
                .Subscribe(e => WriteLine($"[Delay] ({e.X}, {e.Y})"))
                ;

            Application.Run(w);
        }
    
    }
}