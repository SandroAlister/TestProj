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
            TimeList = new List<string>();
        }

        /// <summary>
        /// Настройки аналитики
        /// </summary>
        public AnalysisSetting AnalysisSetting { get; set; }

        //public List<Candidate> ResultCandidateList { get; set; }
        public Dictionary<dynamic, List<Candidate>> ResultDictionary { get; set; }

        private List<string> TimeList { get; set; }

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

        public string GetAvgFinishTime(List<string> timeList)
        {
            var t = timeList.Average(x => TimeSpan.Parse(x).Ticks);
            var ticks = Convert.ToInt64(t);

            var average = new TimeSpan(ticks);
            var averageStr = average.ToString(@"hh\:mm\:ss\.fff");

            return averageStr;
        }

        public Candidate AvgBestCandidate { get; set; }

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

            foreach (var selectionMethod in AnalysisSetting.List)
            {
                var resultCandidateList = new List<Candidate>();

                DisplayResult.DisplayText($"{GetMethodName(selectionMethod, selectionMethod.GetType())}");

                propertyInfo.SetValue(AnalysisSetting, selectionMethod);
                //DisplayResult.DisplayText();

                for (int run = 1; run <= AnalysisSetting.RunAmount; run++)
                {
                    ClearPopulation();
                    //DisplayResult.ClearText();
                    Population.AddRange(firstCandidateList);
                    Process();

                    //if (this.FinishTimeAlgorithm == "00:00:00.000")
                    //    FinishTimeAlgorithm = GetRandomTime();

                    DisplayResult.DisplayText($"Прогон №{run}\tВремя расчета: {FinishTimeAlgorithm}\tЛучшее решение: {GetBestCandidate().DecValue}");
                    resultCandidateList.Add(GetBestCandidate());
                    TimeList.Add(FinishTimeAlgorithm);
                }

                DisplayResult.DisplayText($"Среднее   \tВремя расчета: {GetAvgFinishTime(TimeList)}\tЛучшее решение: {GetAvgBestCandidate(resultCandidateList).DecValue}");
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
