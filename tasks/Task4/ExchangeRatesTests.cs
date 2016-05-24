using NUnit.Framework;
using System;
using lesson4;

namespace Tests
{
    [TestFixture]
    public class ExchangeRatesTest
    {
        [Test]
        public void ExchangeRateForSameCurrencyIsOne()
        {
            var x = Umrechnung.Get(Waehrung.EUR, Waehrung.EUR);
            Assert.IsTrue(x == 1);
        }

        [Test]
        public void ExchangeRateForDifferentCurrencyIsNotOne()
        {
            var x = Umrechnung.Get(Waehrung.EUR, Waehrung.JPY);
            Assert.IsTrue(x != 1);
        }

        [Test]
        public void ExchangeRateFromCurrencyAtoCurrencyB_ShouldBeInverseOfCurrencyBtoCurrencyA()
        {
            var x = Umrechnung.Get(Waehrung.USD, Waehrung.USD);
            var y = Umrechnung.Get(Waehrung.USD, Waehrung.USD);

            var p = x * y; 
            Assert.IsTrue(p > 0.999m && p < 1.001m);
        }
    }
}