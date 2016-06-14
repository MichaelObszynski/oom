using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    public interface IBike
    {
        string Description { get; }
        string Mod { get; }
        object Name { get; set; }
        Preis Preis { get; }
    }
}
