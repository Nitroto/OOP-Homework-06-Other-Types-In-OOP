using System;
using System.Numerics;
using System.Text;

namespace FractionCalculator
{
    struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get
            {
                return this.numerator;
            }
            set
            {
                this.numerator = value;
            }
        }
        public long Denominator
        {
            get
            {
                return this.denominator;
            }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be 0.");
                }
                this.denominator = value;
            }
        }
        public Decimal FractionResult
        {
            get
            {
                decimal fractionResult = (decimal)this.Numerator / this.Denominator;
                return fractionResult;
            }
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            BigInteger resultingDenominator = (f1.Denominator * f2.Denominator);
            if (ChackResult(resultingDenominator))
            {
                throw new ArgumentOutOfRangeException("resultingDenominator", "Resulting denominator is too large or too small!");
            }
            BigInteger resultingNumerator = ((f1.Numerator * f2.Denominator) + (f2.Numerator * f1.Denominator));
            if (ChackResult(resultingNumerator))
            {
                throw new ArgumentOutOfRangeException("resultingNumerator", "Resulting numerator is too large or too small!");
            }
            return new Fraction((long)resultingNumerator, (long)resultingDenominator);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            BigInteger resultingDenominator = (f1.Denominator * f2.Denominator);
            if (ChackResult(resultingDenominator))
            {
                throw new ArgumentOutOfRangeException("resultingDenominator", "Resulting denominator is too large or too small!");
            }
            BigInteger resultingNumerator = ((f1.Numerator * f2.Denominator) - (f2.Numerator * f1.Denominator));
            if (ChackResult(resultingNumerator))
            {
                throw new ArgumentOutOfRangeException("resultingNumerator", "Resulting numerator is too large or too small!");
            }
            return new Fraction((long)resultingNumerator, (long)resultingDenominator);
        }
        private static bool ChackResult(BigInteger number)
        {
            if (number > long.MaxValue || number < long.MinValue)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("{0:F27}", this.FractionResult));
            return output.ToString();
        }
    }
}
