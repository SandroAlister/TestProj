using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.NativeGen
{
    public static class Function
    {
        public delegate double CalcFunction(double x);

        /// <summary>
        /// Выбор функции
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static CalcFunction SetFunc(int num)
        {
            CalcFunction calcFunction;

            switch (++num)
            {
                case 1:
                    calcFunction = Func1;
                    break;
                case 2:
                    calcFunction = Func2;
                    break;
                case 3:
                    calcFunction = Func3;
                    break;
                case 4:
                    calcFunction = Func4;
                    break;
                case 5:
                    calcFunction = Func5;
                    break;
                default:
                    return null;

            }
            return calcFunction;
        }

        static double Func1(double x)
        {
            return x;
        }
        static double Func2(double x)
        {
            return x * x;
        }
        static double Func3(double x)
        {
            return x + 2;
        }
        static double Func4(double x)
        {
            return x * x + 2 * x + 10;
        }
        static double Func5(double x)
        {
            double Y = 5 - (24 * x) + (17 * Math.Pow(x, 2)) - (Convert.ToDouble(11.0 / 3.0) * Math.Pow(x, 3)) + (0.25 * Math.Pow(x, 4));
            return Y;
        }
    }
}
