using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction = CreateFraction();

            FractionMathematicalOperation(fraction);
        }

        static Fraction CreateFraction()
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

            Console.WriteLine("Ułamek zwykły to: " + numerator + "/" + denominator);

            return fraction;
        }

        static void FractionMathematicalOperation(Fraction fraction)
        {
            MathematicalOperation mathematicalOperation = new MathematicalOperation();
            int userSelecion;
            bool leaveTheLoop = false;

            do
            {
                Console.WriteLine("Wybierz działanie, które ma wykonać program:");
                Console.WriteLine("1. Skracanie ułamka");
                Console.WriteLine("2. Odwracanie ułamka");
                Console.WriteLine("3. Zamiana na ułamek dziesiętny");
                Console.WriteLine("4. Zamiana na ułamek właściwy");
                Console.WriteLine("5. Dodawanie ułamków");
                Console.WriteLine("6. Odejmowanie ułamków");
                Console.WriteLine("7. Zakończ program");
                userSelecion = int.Parse(Console.ReadLine());

                switch (userSelecion)
                {
                    case 1:
                        mathematicalOperation.ReduceFraction(fraction);
                        break;

                    case 2:
                        mathematicalOperation.FlippingTheFraction(fraction);
                        break;

                    case 3:
                        mathematicalOperation.ChangeToDecimalFraction(fraction);
                        break;

                    case 4:
                        mathematicalOperation.ChangeToProperFraction(fraction);
                        break;

                    case 5:
                        mathematicalOperation.AddFractions(fraction);
                        break;

                    case 6:
                        mathematicalOperation.SubstractFractions(fraction);
                        break;

                    case 7:
                        leaveTheLoop = true;
                        break;

                    default:
                        {
                            Console.WriteLine("Niestety, na liście nie ma takiego wyboru :(");
                            break;
                        }
                }
            } while (leaveTheLoop != true);
        }

    }
}
