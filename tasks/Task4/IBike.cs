using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4
{
    public interface IBike
    {
        string Description { get; }
        string Mod { get; }
        Preis Preis { get; }
    }
}
