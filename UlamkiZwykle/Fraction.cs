using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFractions
{
    class Fraction
    {

        public int numerator { get; set; }
        public int denominator { get; set; }

        public static int operator +(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.numerator + fraction2.numerator;
        }

        public static int operator -(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.numerator - fraction2.numerator;
        }
    }
}
