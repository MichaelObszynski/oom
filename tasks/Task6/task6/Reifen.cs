﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Newtonsoft.Json;

namespace lesson6
{
    [JsonObject(MemberSerialization.Fields)]
    class Reifen : IBike
    {

        private Preis m_preis;

        public Reifen(string produzent, string modell, decimal preis, Waehrung waehrung)
            : this(produzent, modell, new Preis(preis, waehrung))
        { }

        [JsonConstructor]
        public Reifen(string produzent, string modell, Preis price)
        {
            if (string.IsNullOrWhiteSpace(produzent)) throw new ArgumentException("Bitte Produzenten angeben.", nameof(produzent));
            if (string.IsNullOrWhiteSpace(modell)) throw new ArgumentException("Bitte Modell angeben.", nameof(modell));

            Produzent = produzent;
            Modell = modell;
            UpdatePrice(price.Amount, price.Unit);
        }

        public string Produzent { get; }

        public string Modell { get; }

        public void UpdatePrice(decimal newPrice, Waehrung waehrung)
        {
            if (newPrice < 0) throw new ArgumentException("Preis muss positiv sein.", nameof(newPrice));
            m_preis = new Preis(newPrice, waehrung);
        }

        public void UpdatePrice(Preis newPrice)
        {
            if (newPrice.Amount < 0) throw new ArgumentException("Preis muss positiv sein.", nameof(newPrice));
            m_preis = newPrice;
        }

        #region IItem implementation

        public string Description => Produzent;

        public string Mod => Modell;

        public Preis Preis => m_preis;

        public object Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }


        #endregion
    }
}
