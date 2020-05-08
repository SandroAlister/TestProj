using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.MathFeatures
{
    /// <summary>
    /// Преобразоване типа числа (положительного целого)
    /// </summary>
    public static class MathConvert
    {
        /// <summary>
        /// Перевод из Десятичной системы в Двоичную
        /// </summary>
        /// <param name="decNumber">Десятичное число</param>
        /// <returns>Двоичное число</returns>
        public static List<int> ConvertFromDecToBin(int decNumber)
        {
            List<int> binNumber = new List<int>();

            while (decNumber > 1)
            {
                var tempMod = decNumber % 2;
                decNumber /= 2;
                binNumber.Add(tempMod);
            }

            binNumber.Add(decNumber);
            binNumber.Reverse();

            return binNumber;
        }

        /// <summary>
        /// Перевод из Двоичной системы в Десятичную
        /// </summary>
        /// <param name="binNumber"></param>
        /// <returns></returns>
        public static int ConvertFromBinToDec(List<int> binNumber)
        {
            int decNumber = 0;

            binNumber.Reverse();

            for (int i = 0; i < binNumber.Count; i++)
            {
                if (binNumber[i] == 0)
                    continue;

                decNumber += Convert.ToInt32(Math.Pow(2, i));
            }

            return decNumber;
        }

        /// <summary>
        /// Перевод в строковое представление двоичного числа
        /// </summary>
        /// <param name="binNumber">Двоичное число</param>
        /// <returns>Строковое представление двоичного числа</returns>
        public static string ConvertBinToString(List<int> binNumber)
        {
            string strNumber = "";

            foreach (int i in binNumber)
            {
                strNumber += i.ToString();
            }

            return strNumber;
        }
    }
}
