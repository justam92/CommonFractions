using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFractions
{
    
    class MathematicalOperation
    {
        public void ReduceFraction(Fraction fraction)
        {
            int numerator = fraction.numerator;
            int denominator = fraction.denominator;

            int greatestCommonDivisor = GreatestCommonDivisor(numerator, denominator);

            fraction.numerator = fraction.numerator / greatestCommonDivisor;
            fraction.denominator = fraction.denominator / greatestCommonDivisor;

            Console.WriteLine("Ułamek zwykły po skróceniu wynosi: " + fraction.numerator + "/" + fraction.denominator);
        }

        private int GreatestCommonDivisor(int numerator, int denominator)
        {
            int temp;

            while (denominator != 0)
            {
                temp = numerator;
                numerator = denominator;
                denominator = temp % denominator;
            }
            
            return numerator;
        }

        public void FlippingTheFraction(Fraction fraction)
        {
            int numerator = fraction.numerator;
            int denominator = fraction.denominator;
            int temp = numerator;
            fraction.numerator = denominator;
            fraction.denominator = temp;

            Console.WriteLine("Ułamek zwykły po odwróceniu to: " + fraction.numerator + "/" + fraction.denominator);
        }

        public void ChangeToDecimalFraction(Fraction fraction)
        {
            float changeToDecimalFraction = (float) fraction.numerator / fraction.denominator;

            Console.WriteLine("Ułamek zwykły w postaci ułamka dziesiętnego to: " + changeToDecimalFraction);
        }

        public void ChangeToProperFraction(Fraction fraction)
        {
            int numerator = fraction.numerator;
            int denominator = fraction.denominator;
            int wholeOfImproperFraction=0;
            
            if(numerator > denominator)
            {
                wholeOfImproperFraction = numerator / denominator;
                numerator = numerator - (wholeOfImproperFraction * denominator);
            }

            Console.WriteLine("Ułamek właściwy z podanego ułamka zwykłego to " + wholeOfImproperFraction + "(" + numerator + "/" + denominator + ")");
        }

        public void AddFractions(Fraction fraction)
        {
            int numerator = fraction.numerator;
            int denominator = fraction.denominator;

            Fraction newFraction = CreateAnAdditionalFraction();
            int numerator2 = newFraction.numerator;
            int denominator2 = newFraction.denominator;
            Console.WriteLine("Ułamek zwykły pierwszy to: " + numerator + "/" + denominator);
            Console.WriteLine("Ułamek zwykły drugi to: " + numerator2 + "/" + denominator2);

            int sumOfNumerators = 0;
            int commonDenominator = 0;
            int temp;

            if (denominator != denominator2)
            {
                if (denominator % denominator2 == 0) {
                    temp = denominator / denominator2;
                    commonDenominator = denominator2 * temp;
                    newFraction.numerator = numerator2 * temp;

                    sumOfNumerators = fraction + newFraction;
                }
                else if (denominator2 % denominator == 0) {
                    temp = denominator2 / denominator;
                    commonDenominator = denominator * temp;
                    fraction.numerator = numerator * temp;

                    sumOfNumerators = fraction + newFraction;
                }
                else
                {
                    fraction.numerator = numerator * denominator2;
                    newFraction.numerator = numerator2 * denominator;
                    commonDenominator = denominator * denominator2;

                    sumOfNumerators = fraction + newFraction;
                }
            }
            else
            {
                sumOfNumerators = fraction + newFraction;
                commonDenominator = denominator;
            }
            Console.WriteLine("Wynik dodawania ułamków to: " + sumOfNumerators + "/" + commonDenominator);
        }

        public void SubstractFractions(Fraction fraction)
        {
            int numerator = fraction.numerator;
            int denominator = fraction.denominator;

            Fraction newFraction = CreateAnAdditionalFraction();
            int numerator2 = newFraction.numerator;
            int denominator2 = newFraction.denominator;
            Console.WriteLine("Ułamek zwykły pierwszy to: " + numerator + "/" + denominator);
            Console.WriteLine("Ułamek zwykły drugi to: " + numerator2 + "/" + denominator2);

            int differenceNumerator = 0;
            int commonDenominator = 0;
            int temp;

            if (denominator != denominator2)
            {
                if (denominator % denominator2 == 0)
                {
                    temp = denominator / denominator2;
                    commonDenominator = denominator2 * temp;
                    newFraction.numerator = numerator2 * temp;

                    differenceNumerator = fraction - newFraction;
                }
                else if (denominator2 % denominator == 0)
                {
                    temp = denominator2 / denominator;
                    commonDenominator = denominator * temp;
                    fraction.numerator = numerator * temp;

                    differenceNumerator = fraction - newFraction;
                }
                else
                {
                    fraction.numerator = numerator * denominator2;
                    newFraction.numerator = numerator2 * denominator;
                    commonDenominator = denominator * denominator2;

                    differenceNumerator = fraction - newFraction;
                }
            }
            else
            {
                differenceNumerator = fraction - newFraction;
                commonDenominator = denominator;
            }
            Console.WriteLine("Wynik dodawania ułamków to: " + differenceNumerator + "/" + commonDenominator);
        }

        private Fraction CreateAnAdditionalFraction()
        {
            Fraction fraction = new Fraction();
            bool isNumeratorANumber = false;
            int numerator = 0;

            do
            {
                Console.WriteLine("Podaj liczbę całkowitą, która będzie licznikiem.");

                string numeratorToCheck = Console.ReadLine();

                isNumeratorANumber = int.TryParse(numeratorToCheck, out numerator);

                if (isNumeratorANumber == true)
                {
                    fraction.numerator = numerator;
                }
                else
                {
                    Console.WriteLine("To nie jest liczba!");
                }
            } while (isNumeratorANumber != true);

            bool isDenominatorANumber = false;
            int denominator = 0;

            do
            {
                Console.WriteLine("Podaj liczbę całkowitą, która będzie mianownikiem.");

                string denominatorToCheck = Console.ReadLine();

                isDenominatorANumber = int.TryParse(denominatorToCheck, out denominator);

                if (isDenominatorANumber == true)
                {
                    if (denominator != 0)
                    {
                        fraction.denominator = denominator;
                    }
                    else
                    {
                        Console.WriteLine("Nie dziel przez 0!");
                    }
                }
                else
                {
                    Console.WriteLine("To nie jest liczba całkowita!");
                }
            } while (denominator == 0 || isDenominatorANumber != true);

            return fraction;
        }
    }
}
