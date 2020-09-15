using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj.NativeGen;

namespace TestProj.MathFeatures
{
    /// <summary>
    /// Преобразоване типа числа (целого)
    /// </summary>
    public static class MathConvert
    {
        /// <summary>
        /// Перевод из Десятичной системы в Двоичную
        /// </summary>
        /// <param name="decNumber">Десятичное число</param>
        /// <returns>Двоичное число</returns>
        //public static List<int> ConvertFromDecToBin(int decNumber)
        //{
        //    if (decNumber >= 0)
        //        return GetPositiveBin(decNumber);
        //    else
        //        return GetNegativeBin(decNumber);
        //}

        /// <summary>
        /// Перевод из Десятичной системы в Двоичную (без использования кодирования отрицательных чисел)
        /// </summary>
        /// <param name="decNumber">Десятичное число</param>
        /// <param name="isPosite">Если диапазон положительных чисел</param>
        /// <returns>Двоичное число</returns>
        public static List<int> ConvertFromDecToBin(int decNumber, bool onlyPositive)
        {
            if (decNumber >= 0)
                return GetPositiveBin(decNumber, onlyPositive);
            else
                return GetNegativeBin(decNumber);
        }

        /// <summary>
        /// Получение двоичного представления положительного числа
        /// </summary>
        /// <param name="decNumber">Положительное число</param>
        /// <returns>Двоичное представление</returns>
        private static List<int> GetPositiveBin(int decNumber, bool onlyPositive)
        {
            List<int> binNumber = new List<int>();

            while (decNumber > 1)
            {
                var tempMod = decNumber % 2;
                decNumber /= 2;
                binNumber.Add(tempMod);
            }

            //Добавление в начало 0, так как число положительное   
            binNumber.Add(decNumber);

            if (!onlyPositive)
                binNumber.Add(0);

            binNumber.Reverse();

            return binNumber;
        }

        /// <summary>
        /// Получение двоиного представления отрицательного числа
        /// </summary>
        /// <param name="decNumber">Отрицательное число</param>
        /// <returns>Двоичное представление</returns>
        private static List<int> GetNegativeBin(int decNumber)
        {
            List<int> binNumber = new List<int>();

            //Представляем отрицательное число положительным
            var positiveDev = Math.Abs(decNumber);

            //Получаем прямой код
            var frontCode = GetPositiveBin(positiveDev, false);

            var reverseCode = new List<int>();

            //Получение обратного кода (инвертируем число)
            foreach (var item in frontCode)
            {
                reverseCode.Add(item == 0 ? 1 : 0);
            }

            var addictiveCode = new List<int>();
            reverseCode.Reverse();

            bool hasOne = false;
            int reverseCodeIndex = 0;

            //Получение дополнительного кода путем прибавления к обратному коду 1
            for (int index = 0; index < reverseCode.Count; index++)
            {
                //Если в запасе 1
                if (hasOne)
                {
                    if (reverseCode[index] == 1)
                    {
                        addictiveCode.Add(0);
                        reverseCodeIndex++;

                        continue;
                    }
                    if (reverseCode[index] == 0)
                    {
                        addictiveCode.Add(1);
                        reverseCodeIndex++;
                        hasOne = false;
                        break;
                    }
                }
                if (!hasOne)
                {
                    if (reverseCode[index] == 0)
                    {
                        addictiveCode.Add(1);
                        reverseCodeIndex++;
                        break;
                    }
                    if (reverseCode[index] == 1)
                    {
                        addictiveCode.Add(0);
                        reverseCodeIndex++;
                        hasOne = true;
                        continue;
                    }
                }
            }

            //Если вышли из предыдущего цикла до его окончания, то дозаполняем дополнительный код значениями обратного кода
            if (!hasOne)
            {
                for (int index = reverseCodeIndex; index < reverseCode.Count; index++)
                {
                    addictiveCode.Add(reverseCode[index]);
                }
            }

            addictiveCode.Reverse();

            return addictiveCode;
        }

        /// <summary>
        /// Перевод из Двоичной системы в Десятичную
        /// </summary>
        /// <param name="binNumber"></param>
        /// <returns></returns>
        public static int ConvertFromBinToDec(List<int> binNumber, bool onlyPositive)
        {
            if (onlyPositive)
                return GetPosiveDec(binNumber);

            //Если в начале стоит 0, то это заведомо положительное число
            if (binNumber[0] == 0)
                return GetPosiveDec(binNumber);
            else
                return GetNegativeDec(binNumber);
        }

        /// <summary>
        /// Получение десятичного представления положительного числа
        /// </summary>
        /// <param name="binNumber">Двоичное представление</param>
        /// <returns>Десятичное представление</returns>
        private static int GetPosiveDec(List<int> binNumber)
        {
            int decNumber = 0;

            binNumber.Reverse();

            for (int i = 0; i < binNumber.Count; i++)
            {
                if (binNumber[i] == 0)
                    continue;

                decNumber += Convert.ToInt32(Math.Pow(2, i));
            }

            binNumber.Reverse();

            return decNumber;
        }

        /// <summary>
        /// Получение десятичного представления отрицательного числа
        /// </summary>
        /// <param name="binNumber">Двоичное представление</param>
        /// <returns>Десятичное представление</returns>
        private static int GetNegativeDec(List<int> binNumber)
        {
            binNumber.Reverse();
            var reverseCode = new List<int>();

            bool hasLoan = false;
            int reverseCodeIndex = 0;

            for (int index = 0; index < binNumber.Count; index++)
            {
                if (hasLoan)
                {
                    if (binNumber[index] == 1)
                    {
                        reverseCode.Add(0);
                        reverseCodeIndex++;
                        hasLoan = false;
                        break;
                    }
                    if (binNumber[index] == 0)
                    {
                        reverseCode.Add(1);
                        reverseCodeIndex++;
                        continue;
                    }
                }
                if (!hasLoan)
                {
                    if (binNumber[index] == 1)
                    {
                        reverseCode.Add(0);
                        reverseCodeIndex++;
                        break;
                    }
                    if (binNumber[index] == 0)
                    {
                        reverseCode.Add(1);
                        reverseCodeIndex++;
                        hasLoan = true;
                        continue;
                    }
                }
            }

            //Если вышли из предыдущего цикла до его окончания, то дозаполняем обратный код значениями дополнительного кода
            if (!hasLoan)
            {
                for (int index = reverseCodeIndex; index < binNumber.Count; index++)
                {
                    reverseCode.Add(binNumber[index]);
                }
            }

            reverseCode.Reverse();
            var frontCode = new List<int>();

            //Получение прямого кода (инвертируем число)
            foreach (var item in reverseCode)
            {
                frontCode.Add(item == 0 ? 1 : 0);
            }

            frontCode.RemoveAt(0);

            int decNumber = -GetPosiveDec(frontCode);

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

        public static dynamic ConvertStringToEnumList(Type type, string str)
        {
            //Разделение входной строки на подстроки и удаление пробелов, запятых и пустых элементов
            var valueList = str.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<dynamic> selectionList = new List<dynamic>();

            foreach (var item in valueList)
            {
                var selection = Enum.Parse(type, item);
                selectionList.Add(selection);
            }

            return selectionList;
        }

        public static dynamic ConvertMFK<T>(Type type, string str)
        {
            //Разделение входной строки на подстроки и удаление пробелов, запятых и пустых элементов
            var valueList = str.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<T> selectionList = new List<T>();

            foreach (var item in valueList)
            {
                var selection = Enum.Parse(typeof(T), item);
                selectionList.Add((T)selection);
            }

            List<dynamic> list = new List<dynamic>();
            list.AddRange((dynamic)selectionList);

            return list;
        }

        public static Type GetEnumType(string enumName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetType(enumName);
                if (type == null)
                    continue;
                if (type.IsEnum)
                    return type;
            }
            return null;
        }
    }
}
