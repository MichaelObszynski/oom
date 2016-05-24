using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace lesson4
{
    public static class Umrechnung
    {
        private static Dictionary<string, decimal> s_rates = new Dictionary<string, decimal>();

        public static decimal Get(Waehrung from, Waehrung to)
        {
            // exchange rate is 1:1 for same currency
            if (from == to) return 1;

            var key = string.Format("{0}{1}", from, to); // e.g. EURUSD means "How much is 1 EUR in USD?".
            // if we've already downloaded this exchange rate, use the cached value
            if (s_rates.ContainsKey(key)) return s_rates[key];

            // otherwise create the request URL, ...
            var url = string.Format(@"http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=sl1d1t1c1ohgv&e=.csv", key);
            // download the response as string
            var data = new WebClient().DownloadString(url);
            // split the string at ','
            var parts = data.Split(',');
            // convert the exchange rate part to a decimal 
            var rate = decimal.Parse(parts[1], CultureInfo.InvariantCulture);
            s_rates[key] = rate;
            
            return rate;
        }
    }
}