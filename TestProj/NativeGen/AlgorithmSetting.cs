﻿using System;

namespace TestProj.NativeGen
{
    /// <summary>
    /// Настройки генетического алгоритма
    /// </summary>
    public class AlgorithmSetting : ICloneable
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
        public int DevidePointCount { get; set; }

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
        public bool IsDisplaySelectionResult { get; set; }

        /// <summary>
        /// Отображать рещультаты мутации
        /// </summary>
        public bool IsDisplayMutateResult { get; set; }

        /// <summary>
        /// Отоборажать результаты скрещивания
        /// </summary>
        public bool IsDisplayCrossResult { get; set; }

        public bool IsCompareMethods { get; set; }

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

        /// <summary>
        /// Точность решения
        /// </summary>
        public int Accuracy { get; set; }

        /// <summary>
        /// Значение лучшего решения
        /// </summary>
        public double BestFitess { get; set; }

        /// <summary>
        /// Аргумент лучшего решения 
        /// </summary>
        public double BestSolution { get; set; }

        /// <summary>
        /// Теоретическое лучшее решение
        /// </summary>
        //public ExtSolution ExtSolution { get; set; }

        /// <summary>
        /// Копирование объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new AlgorithmSetting
            {
                GenerationSize = this.GenerationSize,
                PopulationSize = this.PopulationSize,
                FunctionStartValue = this.GenerationSize,
                FunctionFinishValue = this.FunctionFinishValue,
                DevidePointCount = this.DevidePointCount,
                MutationProbability = this.MutationProbability,
                MutateGeneCount = this.MutateGeneCount,
                MutationGeneProbability = this.MutationGeneProbability,
                SelectionTreshold = this.SelectionTreshold,
                GroupSize = this.GroupSize,
                IsDuplicate = this.IsDuplicate,
                IsDisplaySelectionResult = this.IsDisplaySelectionResult,
                IsDisplayMutateResult = this.IsDisplayMutateResult,
                IsDisplayCrossResult = this.IsDisplayCrossResult,
                IsCompareMethods = this.IsCompareMethods,
                CalcFunction = this.CalcFunction,
                SelectTarget = this.SelectTarget,
                SelectParent = this.SelectParent,
                SelectCross = this.SelectCross,
                SelectMutate = this.SelectMutate,
                SelectSelection = this.SelectSelection
            };
        }
    }

    public class ExtSolution
    {
        public int DecValue { get; set; }
        public double Fitness { get; set; }
        public ExtSolution(int decValue, double fitness)
        {
            DecValue = decValue;
            Fitness = fitness;
        }
        public ExtSolution()
        { }
    }
}
