using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bike
    {
    private string m_producer;
        private string m_modelno;
        private decimal m_price;
    
        public string Producer => m_producer;
        public string Model => m_modelno;

        public decimal Price
        {
            get
            {
                return m_price;
            }
            set
            {
                if (value <= 0) throw new Exception("Preis muss positiven Wert beinhalten!");
                value = m_price;
            }
        }

    }