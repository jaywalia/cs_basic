// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading
using System;

namespace Step03
{
    public class Fraction
    {
        private readonly int _num;
        private readonly int _den;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
            }
            _num = numerator;
            _den = denominator;
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a._num, a._den);

        // cross multiply 
        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a._num * b._den + b._num * a._den, a._den * b._den); 

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a._num * b._num, a._den * b._den);
        
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b._num == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a._num * b._den, a._den * b._num);
        }

        public override string ToString() => $"{_num} / {_den}";
    }
}