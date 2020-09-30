using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj.MathFeatures;

namespace TestProj.NativeGen
{
    public class GenAnalysis : GenAlgorithm
    {
        public GenAnalysis() : base() { }

        public GenAnalysis(MemoEdit memoEdit, AnalysisSetting analysisSetting) : base(memoEdit, analysisSetting)
        {
            DisplayResult = new DisplayResult(memoEdit);
            AnalysisSetting = analysisSetting;
            AnalysisSetting.IsCompareMethods = true;
            ResultDictionary = new Dictionary<dynamic, List<Candidate>>();
            NumberOfLastGenerationList = new List<int>();
        }

        /// <summary>
        /// Настройки аналитики
        /// </summary>
        public AnalysisSetting AnalysisSetting { get; set; }

        /// <summary>
        /// Результаты анализа для каждой стратегии
        /// </summary>
        public Dictionary<dynamic, List<Candidate>> ResultDictionary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private List<int> NumberOfLastGenerationList { get; set; }

        /// <summary>
        /// Получение средней особи для метода селекции
        /// </summary>
        /// <returns>Средняя особь</returns>
        public Candidate GetAvgBestCandidate(List<Candidate> candidateList)
        {
            var avgBestCandidate = new Candidate();
            var avgDecValue = Convert.ToInt32(candidateList.Average(c => c.DecValue));

            avgBestCandidate.DecValue = avgDecValue;
            avgBestCandidate.Chromosome = new Chromosome(MathConvert.ConvertFromDecToBin(avgDecValue, AlgorithmSetting.IsOnlyPositive));
            avgBestCandidate.Fitness = AlgorithmSetting.CalcFunction(Convert.ToDouble(avgDecValue));

            return avgBestCandidate;
        }

        /// <summary>
        /// Запуск работы анализа выбранных методов
        /// </summary>
        public void Start()
        {
            DisplayResult.ClearText();

            ResultDictionary = new Dictionary<dynamic, List<Candidate>>();

            var propertyInfo = typeof(AnalysisSetting).GetProperty(AnalysisSetting.SelectMethod.ToString());
            var propertyValue = propertyInfo.GetValue(AnalysisSetting);

            //Получение первой популяции
            List<Candidate> firstCandidateList = GenerateFirstPopulation();
            DisplayResult.DisplayPopulation("Начальная популяция:",firstCandidateList);

            foreach (var selectionMethod in AnalysisSetting.List)
            {
                var resultCandidateList = new List<Candidate>();

                DisplayResult.DisplayText($"{GetMethodName(selectionMethod, selectionMethod.GetType())}");

                propertyInfo.SetValue(AnalysisSetting, selectionMethod);

                for (int run = 1; run <= AnalysisSetting.RunAmount; run++)
                {
                    ClearPopulation();
                    //DisplayResult.ClearText();
                    Population.AddRange(firstCandidateList);
                    Process();

                    var bestCandidate = GetBestCandidate();

                    DisplayResult.DisplayText($"Прогон №{run}\tЛучшее решение: {bestCandidate.DecValue}\tНайдено за {NumberOfLastGeneneration} итераций");
                    resultCandidateList.Add(bestCandidate);
                    NumberOfLastGenerationList.Add(NumberOfLastGeneneration);
                }

                DisplayResult.DisplayText($"Среднее   \tЛучшее решение: {GetAvgBestCandidate(resultCandidateList).DecValue}\tНайдено за {Math.Round(NumberOfLastGenerationList.Average(), MidpointRounding.AwayFromZero)} итераций");
                DisplayResult.AddNewLine();
                ResultDictionary.Add(selectionMethod, resultCandidateList);
            }

            propertyInfo.SetValue(AnalysisSetting, propertyValue);
        }

        /// <summary>
        /// Получение локализованного названия метода селекции
        /// </summary>
        /// <param name="selectSelection">Метод селекции</param>
        /// <returns>Локализованное название метода селекции</returns>
        private string GetMethodName(object _selectSelection, Type _type)
        {
            // Получение списка всех элементов перечисления методов селекции
            var enumList = Enum.GetValues(_type)
           .Cast<Enum>()
           .Select(value => new
           {
               (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
               value
           })
           .OrderBy(item => item.value)
           .ToList();

            var selectItem = enumList.Find(g => g.value.ToString() == _selectSelection.ToString());
            string methodName = selectItem.Description;

            return methodName;
        }

    }

}
