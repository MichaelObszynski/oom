using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace lesson6
{
    public static class Umrechnung
    {
        private static Dictionary<string, decimal> s_rates = new Dictionary<string, decimal>();

        public static decimal Get(Waehrung from, Waehrung to)
        {
            
            if (from == to) return 1;

            var key = string.Format("{0}{1}", from, to); 
            if (s_rates.ContainsKey(key)) return s_rates[key];

            var url = string.Format(@"http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=sl1d1t1c1ohgv&e=.csv", key);
            var data = new WebClient().DownloadString(url);
            var parts = data.Split(',');
            var rate = decimal.Parse(parts[1], CultureInfo.InvariantCulture);
            s_rates[key] = rate;

            return rate;
        }
    }
}