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
            ResultDictionary = new Dictionary<SelectSelection, List<Candidate>>();
        }

        /// <summary>
        /// Настройки аналитики
        /// </summary>
        public AnalysisSetting AnalysisSetting { get; set; }

        //public List<Candidate> ResultCandidateList { get; set; }
        public Dictionary<SelectSelection, List<Candidate>> ResultDictionary { get; set; }

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
            var initSelection = AnalysisSetting.SelectSelection;

            //Получение первой популяции
            List<Candidate> firstCandidateList = GenerateFirstPopulation();

            foreach (var selectionMethod in AnalysisSetting.SelectionList)
            {
                var resultCandidateList = new List<Candidate>();

                AnalysisSetting.SelectSelection = selectionMethod;

                for (int run = 1; run <= AnalysisSetting.RunAmount; run++)
                {
                    ClearPopulation();
                    Population.AddRange(firstCandidateList);
                    Process();
                    resultCandidateList.Add(GetBestCandidate());
                }

                ResultDictionary.Add(selectionMethod, resultCandidateList);
            }

            AnalysisSetting.SelectSelection = initSelection;
        }

    }

}
