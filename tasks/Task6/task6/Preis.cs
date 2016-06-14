using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    public class Preis
    {
        public Preis(decimal amount, Waehrung unit)
        {
            Amount = amount;
            Unit = unit;
        }

        public decimal Amount { get; }

        public Waehrung Unit { get; }

        public Preis ConvertTo(Waehrung targetCurrency)
        {
            if (targetCurrency == Unit) return this;
            return new Preis(Amount * Umrechnung.Get(Unit, targetCurrency), targetCurrency);
        }

        #region Operators

        public static Preis operator +(Preis a, Preis b) => BinaryOp(a, b, (x, y) => x + y);
        public static Preis operator -(Preis a, Preis b) => BinaryOp(a, b, (x, y) => x - y);
        public static Preis operator *(Preis a, Preis b) => BinaryOp(a, b, (x, y) => x * y);
        public static Preis operator /(Preis a, Preis b) => BinaryOp(a, b, (x, y) => x / y);
        public static bool operator <(Preis a, Preis b) => BinaryOp(a, b, (x, y) => x < y);
        public static bool operator <=(Preis a, Preis b) => BinaryOp(a, b, (x, y) => x <= y);
        public static bool operator ==(Preis a, Preis b) => BinaryOp(a, b, (x, y) => x == y);
        public static bool operator !=(Preis a, Preis b) => BinaryOp(a, b, (x, y) => x != y);
        public static bool operator >=(Preis a, Preis b) => BinaryOp(a, b, (x, y) => x >= y);
        public static bool operator >(Preis a, Preis b) => BinaryOp(a, b, (x, y) => x > y);

        private static Preis BinaryOp(Preis x, Preis y, Func<decimal, decimal, decimal> op)
        {
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) throw new ArgumentNullException();
            if (x.Unit == y.Unit) return new Preis(op(x.Amount, y.Amount), x.Unit);
            return new Preis(op(x.Amount, y.ConvertTo(x.Unit).Amount), x.Unit);
        }

        private static bool BinaryOp(Preis x, Preis y, Func<decimal, decimal, bool> op)
        {
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) throw new ArgumentNullException();
            if (x.Unit == y.Unit) return op(x.Amount, y.Amount);
            return op(x.Amount, y.ConvertTo(x.Unit).Amount);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Preis;
            if (object.ReferenceEquals(other, null)) return false;
            return this == other;
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode() ^ Unit.GetHashCode();
        }

        #endregion
    }
}


