using System;

namespace TestProj.NativeGen
{
    /// <summary>
    /// Особь
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// Значение функции приспособленности
        /// </summary>
        public double Fitness { get; set; }

        /// <summary>
        /// Десятичное представление числа
        /// </summary>
        public int DecValue { get; set; }

        public double DoubleValue { get { return Convert.ToDouble(DecValue); } }
        
        /// <summary>
        /// Положительное число
        /// </summary>
        public bool IsPositive { get { return DecValue >= 0; } }

        /// <summary>
        /// Хромосома (двоичное представление числа)
        /// </summary>
        public Chromosome Chromosome { get; set; }
    }
}
