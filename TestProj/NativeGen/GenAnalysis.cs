using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
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
        }

        /// <summary>
        /// Настройки аналитики
        /// </summary>
        public AnalysisSetting AnalysisSetting { get; set; }

        //public List<Candidate> ResultCandidateList { get; set; }
        public Dictionary<dynamic, List<Candidate>> ResultDictionary { get; set; }

        /// <summary>
        /// Получение средней особи для метода селекции
        /// </summary>
        /// <returns>Средняя особь</returns>
        public Candidate GetAvgBestCandidate(List<Candidate> candidateList)
        {
            var avgBestCandidate = new Candidate();
            var avgDecValue = Convert.ToInt32(candidateList.Average(c => c.DecValue));

            avgBestCandidate.DecValue = avgDecValue;
            avgBestCandidate.Chromosome = (Chromosome)MathConvert.ConvertFromDecToBin(avgDecValue, AlgorithmSetting.IsOnlyPositive);
            avgBestCandidate.Fitness = AlgorithmSetting.CalcFunction(Convert.ToDouble(avgDecValue));

            return avgBestCandidate;
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

                propertyInfo.SetValue(AnalysisSetting, selectionMethod);
                //DisplayResult.DisplayText();

                for (int run = 1; run <= AnalysisSetting.RunAmount; run++)
                {
                    ClearPopulation();
                    //DisplayResult.ClearText();
                    Population.AddRange(firstCandidateList);
                    Process();
                    DisplayResult.DisplayText($"Прогон №{run}\tВремя расчета: {this.FinishTimeAlgorithm}\tЛучшее решение: {this.GetBestCandidate().DecValue}");
                    resultCandidateList.Add(GetBestCandidate());
                }

                DisplayResult.AddNewLine();
                ResultDictionary.Add(selectionMethod, resultCandidateList);
            }

            propertyInfo.SetValue(AnalysisSetting, propertyValue);
        }

    }

}
