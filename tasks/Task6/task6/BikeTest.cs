using NUnit.Framework;
using System;
using lesson6;

namespace Tests
{
    [TestFixture]
    public class RahmenTests
    {
        [Test]
        public void CanCreateRahmen()
        {
            var x = new Rahmen("KTM", "Ultra Sport 2016", 403.99m, Waehrung.EUR);

            Assert.IsTrue(x.Produzent == "Real-Time Rendering");
            Assert.IsTrue(x.Modell == "Ultra Sport 2016");
            Assert.IsTrue(x.Preis.Amount == 403.99m);
            Assert.IsTrue(x.Preis.Unit == Waehrung.EUR);
        }

        [Test]
        public void CannotCreateRahmen1()
        {
            Assert.Catch(() =>
            {
                var x = new Rahmen(null, "Ultra Sport 2016", 403.99m, Waehrung.EUR);
            });
        }

        [Test]
        public void CannotCreateRahmen2()
        {
            Assert.Catch(() =>
            {
                var x = new Rahmen("", "Ultra Sport 2016", 403.99m, Waehrung.EUR);
            });
        }

        [Test]
        public void CannotCreateRahmenModell1()
        {
            Assert.Catch(() =>
            {
                var x = new Rahmen("KTM", null, 403.99m, Waehrung.EUR);
            });
        }

        [Test]
        public void CannotCreateRahmenModell2()
        {
            Assert.Catch(() =>
            {
                var x = new Rahmen("KTM", "", 403.99m, Waehrung.EUR);
            });
        }

        [Test]
        public void CannotCreateRahmenWithNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new Rahmen("KTM", "Ultra Sport 2016", -1, Waehrung.EUR);
            });
        }

        [Test]
        public void CanUpdateRahmenWithPrice()
        {
            var x = new Rahmen("KTM", "Ultra Sport 2016", 403.99m, Waehrung.EUR);
            x.UpdatePrice(39.90m, Waehrung.JPY);

            Assert.IsTrue(x.Preis.Amount == 39.90m);
            Assert.IsTrue(x.Preis.Unit == Waehrung.JPY);
        }

        [Test]
        public void CannotUpdateRahmenWithNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new Rahmen("KTM", "Ultra Sport 2016", 403.99m, Waehrung.EUR);
                x.UpdatePrice(-9.90m, Waehrung.JPY);
            });
        }
    }
}
