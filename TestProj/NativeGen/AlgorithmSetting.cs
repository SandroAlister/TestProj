using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.NativeGen
{
    /// <summary>
    /// Настройки генетического алгоритма
    /// </summary>
    public class AlgorithmSetting
    {
        public AlgorithmSetting() { }

        /// <summary>
        /// Количество поколений
        /// </summary>
        public int GenerationSize { get; set; }

        /// <summary>
        /// Размер популяции
        /// </summary>
        public int PopulationSize { get; set; }

        /// <summary>
        /// Начальное значение X
        /// </summary>
        public int FunctionStartValue { get; set; }

        /// <summary>
        /// Конечное значение Х
        /// </summary>
        public int FunctionFinishValue { get; set; }

        /// <summary>
        /// Должны ли быть решения только положительными
        /// </summary>
        public bool IsOnlyPositive { get { return FunctionStartValue >= 0; } }

        /// <summary>
        /// Количество точек разделений для многототечного кроссинговера
        /// </summary>
        public int CrossDevidePointCount { get; set; }

        /// <summary>
        /// Вероятность мутации
        /// </summary>
        public double MutationProbability { get; set; }

        /// <summary>
        /// Количество генов для мутирования
        /// </summary>
        public int MutateGeneCount { get; set; }

        /// <summary>
        /// Вероятность мутации гена
        /// </summary>
        public double MutationGeneProbability { get; set; }

        /// <summary>
        /// Порог для отбора усечением
        /// </summary>
        public double SelectionTreshold { get; set; }

        /// <summary>
        /// Размер группы
        /// </summary>
        public int GroupSize { get; set; }

        /// <summary>
        /// Отбирать дубликаты в следующее поколение
        /// </summary>
        public bool IsDuplicate { get; set; }

        /// <summary>
        /// Отображать промежуточные данные для турнира
        /// </summary>
        public bool IsDisplay { get; set; }

        /// <summary>
        /// Выбранная функция
        /// </summary>
        public Function.CalcFunction CalcFunction { get; set; }

        /// <summary>
        /// Выбранная цель
        /// </summary>
        public SelectTarget SelectTarget { get; set; }

        /// <summary>
        /// Метод отбора родителей
        /// </summary>
        public SelectParent SelectParent { get; set; }

        /// <summary>
        /// Метод скрещивания родителей
        /// </summary>
        public SelectCross SelectCross { get; set; }

        /// <summary>
        /// Метод мутации потомка
        /// </summary>
        public SelectMutate SelectMutate { get; set; }

        /// <summary>
        /// Метод селекции пополения
        /// </summary>
        public SelectSelection SelectSelection { get; set; }


    }
}
