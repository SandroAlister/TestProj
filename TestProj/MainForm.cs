using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestProj.NativeGen;
using TestProj.MathFeatures;
using DevExpress.XtraEditors;
using System.Collections;
using System.Diagnostics;
using DevExpress.Charts.Native;
using DevExpress.XtraCharts;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;

namespace TestProj
{
    public partial class MainForm : XtraForm
    {
        /// <summary>
        /// Список значений для контрола "Шаг функции"
        /// </summary>
        private List<double> stepList = new List<double> { 0.05, 0.1, 0.2, 0.5, 1.0, 2.0 };

        /// <summary>
        /// Список функций
        /// </summary>
        List<string> funcList = new List<string>()
        {
            "x",
            "x^2",
            "x+2",
            "x^2+2*x+10",
            "5-(24*x)+(17*x^2)-((11/3)*x^3)+(0.25*x^4)"
        };

        /// <summary>
        /// Шаг функции
        /// </summary>
        public double FunctionStep { get; set; }

        public int PopulationTrack { get; set; }

        /// <summary>
        /// Настройки генетического алгоритма
        /// </summary>
        public AlgorithmSetting AlgorithmSetting { get; set; }

        /// <summary>
        /// Генетический алгоритм
        /// </summary>
        public GenAlgorithm GenAlgorithm { get; set; }

        /// <summary>
        /// Настройки аналитики
        /// </summary>
        public AnalysisSetting AnalysisSetting { get; set; }

        /// <summary>
        /// Аналитика методов генетического алгоритма
        /// </summary>
        public GenAnalysis GenAnalysis { get; set; }

        /// <summary>
        /// Рассчитанная точка экстремума
        /// </summary>
        private SeriesPoint ExtremumPoint { get; set; }

        public MainForm()
        {
            InitializeComponent();
            LoadConfig();
        }

        #region Загрузка значений в выпадающие списки конфигураций генетического алгоритма

        /// <summary>
        /// Загрузка значений конфигураций генетического алгоритма
        /// </summary>
        private void LoadConfig()
        {
            try
            {
                AlgorithmSetting = new AlgorithmSetting();
                //Загрузка конфигураций методик генетического алгоритма
                LoadSelectTarget();
                LoadSelectParent();
                LoadSelectCross();
                LoadSelectMutate();
                LoadSelectSelection();

                //Загрузка значений списка целевых функций
                cmboCalcFunction.Properties.Items.AddRange(funcList);
                cmboCalcFunction.EditValue = cmboCalcFunction.Properties.Items[0];

                //Выставление параметров функции
                FunctionStep = Convert.ToDouble(seFunctionStep.EditValue);
                AlgorithmSetting.FunctionStartValue = Convert.ToInt32(seFunctionStartValue.EditValue);
                AlgorithmSetting.FunctionFinishValue = Convert.ToInt32(seFunctionFinishValue.EditValue);
                AlgorithmSetting.Accuracy = Convert.ToInt32(seAccuracy.EditValue);

                //Выставление настроек ГА
                AlgorithmSetting.GenerationSize = Convert.ToInt32(seGenerationSize.EditValue);
                AlgorithmSetting.PopulationSize = Convert.ToInt32(sePopulationSize.EditValue);
                AlgorithmSetting.SelectionTreshold = Convert.ToDouble(seSelectionTreshold.EditValue);
                AlgorithmSetting.MutationProbability = Convert.ToDouble(seMutationProbability.EditValue);
                AlgorithmSetting.MutationGeneProbability = Convert.ToDouble(seMutationGeneProbability.EditValue);
                AlgorithmSetting.DevidePointCount = Convert.ToInt32(seDevidePointCount.EditValue);
                AlgorithmSetting.MutateGeneCount = Convert.ToInt32(seMutateGeneCount.EditValue);
                AlgorithmSetting.GroupSize = Convert.ToInt32(seGroupSize.EditValue);
                AlgorithmSetting.IsDuplicate = Convert.ToBoolean(ceIsDuplicate.EditValue);
                AlgorithmSetting.IsDisplaySelectionResult = Convert.ToBoolean(ceIsDisplaySelectionResult.EditValue);
                AlgorithmSetting.IsDisplayMutateResult = Convert.ToBoolean(ceIsDisplayMutateResult.EditValue);
                AlgorithmSetting.IsDisplayCrossResult = Convert.ToBoolean(ceIsDisplayCrossResult.EditValue);

                // Блокирование контролов в зависимости от настроек ГА
                seDevidePointCount.Enabled = AlgorithmSetting.SelectCross == SelectCross.CrossingoverNPoint ? true : false;
                seMutateGeneCount.Enabled = AlgorithmSetting.SelectMutate == SelectMutate.MutateNPoint ? true : false;
                seMutationGeneProbability.Enabled = AlgorithmSetting.SelectMutate == SelectMutate.DensityMutate ? true : false;
                seSelectionTreshold.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.TruncationSelection ? true : false;
                seGroupSize.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.ClassicTournament || AlgorithmSetting.SelectSelection == SelectSelection.EqualProbabilityTournament || AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament ? true : false;
                ceIsDuplicate.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.EqualProbabilityTournament || AlgorithmSetting.SelectSelection == SelectSelection.RouletteSelection || AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament ? true : false;
                ceIsDisplaySelectionResult.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.RouletteSelection || AlgorithmSetting.SelectSelection == SelectSelection.ClassicTournament || AlgorithmSetting.SelectSelection == SelectSelection.EqualProbabilityTournament || AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament ? true : false;

                sbStart.Enabled = false;

                ChangeRangeTrack(AlgorithmSetting.GenerationSize);

                // Блокировка вкладки "Анализ"
                tabControl.TabPages[1].PageEnabled = false;

                AnalysisSetting = new AnalysisSetting(AlgorithmSetting)
                {
                    RunAmount = Convert.ToInt32(seRunAmount.EditValue)
                };
                LoadSelectMethod();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Загрузка значений в выпадащий список выбора цели генетического алгоритма
        /// </summary>
        private void LoadSelectTarget()
        {
            var enumList = Enum.GetValues(typeof(SelectTarget))
            .Cast<Enum>()
            .Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
            .OrderBy(item => item.value)
            .ToList();

            lueSelectTarget.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo
            {
                FieldName = "value",

                Caption = ""
            });

            lueSelectTarget.Properties.DisplayMember = "Description";
            lueSelectTarget.Properties.ValueMember = "value";

            lueSelectTarget.Properties.DataSource = enumList;

            lueSelectTarget.EditValue = enumList[0].value;

            lueSelectTarget.Properties.ShowHeader = false;
            lueSelectTarget.Properties.ShowFooter = false;

            AlgorithmSetting.SelectTarget = (SelectTarget)enumList[0].value;
        }

        /// <summary>
        /// Загрузка значений в выпадающий список метода отбора родителей
        /// </summary>
        private void LoadSelectParent()
        {
            var enumList = Enum.GetValues(typeof(SelectParent))
            .Cast<Enum>()
            .Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
            .OrderBy(item => item.value)
            .ToList();

            lueSelectParent.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo
            {
                FieldName = "value",

                Caption = ""
            });

            lueSelectParent.Properties.DisplayMember = "Description";
            lueSelectParent.Properties.ValueMember = "value";

            lueSelectParent.Properties.DataSource = enumList;

            lueSelectParent.EditValue = enumList[0].value;

            lueSelectParent.Properties.ShowHeader = false;
            lueSelectParent.Properties.ShowFooter = false;

            AlgorithmSetting.SelectParent = (SelectParent)enumList[0].value;
        }

        /// <summary>
        /// Загрузка значений в выпадающий список метода скрещивания родителей
        /// </summary>
        private void LoadSelectCross()
        {
            var enumList = Enum.GetValues(typeof(SelectCross))
            .Cast<Enum>()
            .Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
            .OrderBy(item => item.value)
            .ToList();

            lueSelectCross.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo
            {
                FieldName = "value",

                Caption = ""
            });

            lueSelectCross.Properties.DisplayMember = "Description";
            lueSelectCross.Properties.ValueMember = "value";

            lueSelectCross.Properties.DataSource = enumList;

            lueSelectCross.EditValue = enumList[0].value;

            lueSelectCross.Properties.ShowHeader = false;
            lueSelectCross.Properties.ShowFooter = false;

            AlgorithmSetting.SelectCross = (SelectCross)enumList[0].value;
        }

        /// <summary>
        /// Загрузка значений в выпадающий список метода мутации потомка
        /// </summary>
        private void LoadSelectMutate()
        {
            var enumList = Enum.GetValues(typeof(SelectMutate))
            .Cast<Enum>()
            .Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
            .OrderBy(item => item.value)
            .ToList();

            lueSelectMutate.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo
            {
                FieldName = "value",

                Caption = ""
            });

            lueSelectMutate.Properties.DisplayMember = "Description";
            lueSelectMutate.Properties.ValueMember = "value";

            lueSelectMutate.Properties.DataSource = enumList;

            lueSelectMutate.EditValue = enumList[0].value;

            lueSelectMutate.Properties.ShowHeader = false;
            lueSelectMutate.Properties.ShowFooter = false;

            AlgorithmSetting.SelectMutate = (SelectMutate)enumList[0].value;
        }

        /// <summary>
        /// Загрузка значений в выпадающий список метода селекции
        /// </summary>
        private void LoadSelectSelection()
        {
            var enumList = Enum.GetValues(typeof(SelectSelection))
            .Cast<Enum>()
            .Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
            .OrderBy(item => item.value)
            .ToList();

            lueSelectSelection.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo
            {
                FieldName = "value",

                Caption = ""
            });

            lueSelectSelection.Properties.DisplayMember = "Description";
            lueSelectSelection.Properties.ValueMember = "value";

            lueSelectSelection.Properties.DataSource = enumList;

            lueSelectSelection.EditValue = enumList[0].value;

            lueSelectSelection.Properties.ShowHeader = false;
            lueSelectSelection.Properties.ShowFooter = false;

            AlgorithmSetting.SelectSelection = (SelectSelection)enumList[0].value;
        }

        /// <summary>
        /// Загрузка значений в выпадающий список анализируемых методов селекции
        /// </summary>
        private void LoadAnalysisGeneticOperator()
        {
            lueAnalysisSelectionMethods.Properties.Items.Clear();

            var type = AnalysisSetting.Type;

            if (type == null)
                return;

            var enumList = Enum.GetValues(type)
            .Cast<Enum>()
            .Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
            .OrderBy(item => item.value)
            .ToList();

            foreach (var item in enumList)
            {
                lueAnalysisSelectionMethods.Properties.Items.Add(item.value, item.Description);
            }

            AnalysisSetting.List = new List<dynamic>();
        }

        /// <summary>
        /// Загрузка значений в выпадающий список анализируемых генетических операторов
        /// </summary>
        private void LoadSelectMethod()
        {
            var enumList = Enum.GetValues(typeof(SelectMethod))
            .Cast<Enum>()
            .Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
            .OrderBy(item => item.value)
            .ToList();

            lueAnalysisMethod.Properties.Columns.Add(new LookUpColumnInfo
            {
                FieldName = "value",

                Caption = ""
            });

            lueAnalysisMethod.Properties.DisplayMember = "Description";
            lueAnalysisMethod.Properties.ValueMember = "value";

            lueAnalysisMethod.Properties.DataSource = enumList;

            lueAnalysisMethod.EditValue = enumList[0].value;

            lueAnalysisMethod.Properties.ShowHeader = false;
            lueAnalysisMethod.Properties.ShowFooter = false;

            AnalysisSetting.SelectMethod = (SelectMethod)enumList[0].value;
        }

        #endregion

        /// <summary>
        /// Валидация
        /// </summary>
        /// <returns></returns>
        private bool IsValidated()
        {
            bool leftLessRightValue = AlgorithmSetting.FunctionStartValue < AlgorithmSetting.FunctionFinishValue;

            return leftLessRightValue;
        }

        private void sbFunctionEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidated())
                {
                    seFunctionStartValue.BackColor = Color.LightCoral;
                    return;
                }
                else
                {
                    seFunctionStartValue.BackColor = Color.White;
                }

                for (int i = 0; i < chFunction.Series.Count; i++)
                {
                    chFunction.Series[i].Points.Clear();
                }

                for (double i = AlgorithmSetting.FunctionStartValue; i <= AlgorithmSetting.FunctionFinishValue; i += FunctionStep)
                {
                    chFunction.Series[0].Points.Add(new SeriesPoint(i, AlgorithmSetting.CalcFunction(i)));
                }

                ExtremumPoint = GetGlobalExtremumPoint(chFunction, 0);

                AlgorithmSetting.BestSolution = Convert.ToDouble(ExtremumPoint.Argument);
                AlgorithmSetting.BestFitess = ExtremumPoint.Values[0];

                DisplayExtremumPoint(ExtremumPoint, chFunction, 1);
                AddAxisLabel(chFunction, "X", "Y");
                sbStart.Enabled = true;
                tabControl.TabPages[1].PageEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sbStart_Click(object sender, EventArgs e)
        {
            try
            {
                GenAlgorithm = new GenAlgorithm(meOutPut, AlgorithmSetting);
                meOutPut.Text = "";
                GenAlgorithm.Process();

                lcCalcTimer.Text = $"Время расчета {GenAlgorithm.FinishTimeAlgorithm}";

                PopulationTrack = GenAlgorithm.NumberOfLastGeneneration;
                ChangeRangeTrack(PopulationTrack);

                rngPopulationTrack.Enabled = true;
                rngPopulationTrack.Value = rngPopulationTrack.Properties.Maximum;

                ConvertCandidateToSeries(chFunction, 2, GenAlgorithm.AllBestCandidates[PopulationTrack]);
                MessageBox.Show($"Наилучшее решение:{GenAlgorithm.GetBestCandidate().DecValue} было найдено за {GenAlgorithm.NumberOfLastGeneneration} поколений");
                GenAlgorithm.GetBestCandidate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Получение точки экстремума
        /// </summary>
        /// <param name="chartControl">График</param>
        /// <param name="indexSeries">Индекс серии</param>
        /// <returns>Точка экстремума</returns>
        private SeriesPoint GetGlobalExtremumPoint(ChartControl chartControl, int indexSeries)
        {
            var pointList = chartControl.Series[indexSeries].Points.ToList();

            var extremumGlobalPoint = AlgorithmSetting.SelectTarget == SelectTarget.Maxinum ? GetMaxPoint(pointList) : GetMinPoint(pointList);

            return extremumGlobalPoint;
        }

        /// <summary>
        /// Получение максимальной точки на графике
        /// </summary>
        /// <param name="_pointList">Список точек</param>
        /// <returns>Максимальная точка</returns>
        private SeriesPoint GetMaxPoint(List<ISeriesPoint> _pointList)
        {
            SeriesPoint maxPoint = new SeriesPoint();
            double maxValue = -100000000000.00;

            foreach (var point in _pointList)
            {
                var pointValue = point.UserValues.FirstOrDefault();

                if (maxValue <= pointValue)
                {
                    maxValue = pointValue;
                    maxPoint = (SeriesPoint)point;
                }
            }

            return maxPoint;
        }

        /// <summary>
        /// Получение минимальной точки на графике
        /// </summary>
        /// <param name="_pointList">Список точек</param>
        /// <returns>Минимальная точка</returns>
        private SeriesPoint GetMinPoint(List<ISeriesPoint> _pointList)
        {
            SeriesPoint minPoint = new SeriesPoint();
            double minValue = 100000000000.00;

            foreach (var point in _pointList)
            {
                var pointValue = point.UserValues.FirstOrDefault();

                if (minValue <= pointValue)
                {
                    minValue = pointValue;
                    minPoint = (SeriesPoint)point;
                }
            }

            return minPoint;
        }

        /// <summary>
        /// Отоборажение точки глобального экстремума на графике
        /// </summary>
        /// <param name="_extremumGlobalPoint">Точка глобального экстремума</param>
        private void DisplayExtremumPoint(SeriesPoint _extremumGlobalPoint, ChartControl _chartControl, int _seriesIndex)
        {
            if (_chartControl.Series[_seriesIndex].Points.Count > 0)
                _chartControl.Series[_seriesIndex].Points.Clear();

            Series series1 = _chartControl.Series[_seriesIndex];

            ((LineSeriesView)series1.View).MarkerVisibility = DefaultBoolean.True;
            ((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Circle;
            ((LineSeriesView)series1.View).LineMarkerOptions.Size = 10;
            ((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash;

            _chartControl.Series[_seriesIndex].Points.Add(_extremumGlobalPoint);
        }

        /// <summary>
        /// Преобразование особи в точку на графике
        /// </summary>
        private void ConvertCandidateToSeries(ChartControl _chartControl, int _seriesIndex, List<Candidate> _candidateList)
        {
            if (_chartControl.Series[_seriesIndex].Points.Count > 0)
                _chartControl.Series[_seriesIndex].Points.Clear();

            //var candidateList = GenAlgorithm.AllBestCandidates[PopulationTrack];

            Series series = chFunction.Series[_seriesIndex];

            ((LineSeriesView)series.View).MarkerVisibility = DefaultBoolean.True;
            ((LineSeriesView)series.View).LineMarkerOptions.Kind = MarkerKind.Circle;
            ((LineSeriesView)series.View).LineMarkerOptions.Size = 10;
            ((LineSeriesView)series.View).LineStyle.DashStyle = DashStyle.Dash;

            foreach (var item in _candidateList)
            {
                SeriesPoint seriesPoint = new SeriesPoint(item.DecValue, item.Fitness);
                series.Points.Add(seriesPoint);
            }
        }

        /// <summary>
        /// Изменение количества делений для trackBar'а
        /// </summary>
        private void ChangeRangeTrack(int maxValue)
        {
            rngPopulationTrack.Enabled = false;

            var oldMaxValue = rngPopulationTrack.Properties.Maximum;

            rngPopulationTrack.Properties.Maximum = maxValue;

            if (oldMaxValue == maxValue)
                return;

            if (oldMaxValue < maxValue)
                AddRangeLabel();
            else
                RemoveRangeLabel();
        }

        /// <summary>
        /// Добавление подписи для trackBar'а
        /// </summary>
        private void AddRangeLabel()
        {
            var maxValue = rngPopulationTrack.Properties.Maximum;

            var index = rngPopulationTrack.Properties.Labels.Count;

            for (; index <= maxValue; index++)
            {
                TrackBarLabel trackBarLabel = new TrackBarLabel(index.ToString(), index, true);
                rngPopulationTrack.Properties.Labels.Add(trackBarLabel);
            }
        }

        /// <summary>
        /// Удаление подписи для trackBar'а
        /// </summary>
        private void RemoveRangeLabel()
        {
            var maxValue = rngPopulationTrack.Properties.Maximum;

            var index = rngPopulationTrack.Properties.Labels.Count - 1;

            for (; index > maxValue; index--)
            {
                rngPopulationTrack.Properties.Labels.RemoveAt(index);
            }
        }

        private void seFunctionStep_Spin(object sender, SpinEventArgs e)
        {
            try
            {
                var spinEdit = sender as SpinEdit;
                var spidEditValue = Convert.ToDouble(spinEdit.EditValue);

                spinEdit.Properties.Increment = Convert.ToDecimal(GetIncrement(e.IsSpinUp, spidEditValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Получение инкремента для spinEdit'a в зависимости от нажатой кнопки и текущего значения
        /// </summary>
        /// <param name="isSpinUp">Направление вверх</param>
        /// <param name="editValue">Текущее значение</param>
        /// <returns>Инкремент</returns>
        private double GetIncrement(bool isSpinUp, double editValue)
        {
            int index = stepList.FindIndex(g => g == editValue);

            //Если нажата кнопка "Вниз" и текущий элемент минимальный 
            //или нажата кнопка "Вверх" и текущий элемент максимальный, то возвращаем 0
            if (index == 0 && !isSpinUp || index == stepList.Count - 1 && isSpinUp)
                return 0;

            var increment = isSpinUp ? stepList[index + 1] - stepList[index] : stepList[index] - stepList[index - 1];

            return increment;
        }

        #region События изменения значений у контролов

        private void seFunctionStep_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                FunctionStep = Convert.ToDouble(seFunctionStep.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seFunctionStartValue_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.FunctionStartValue = Convert.ToInt32(seFunctionStartValue.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seFunctionFinishValue_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.FunctionFinishValue = Convert.ToInt32(seFunctionFinishValue.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seAccuracy_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.Accuracy = Convert.ToInt32(seAccuracy.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seDevidePointCount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.DevidePointCount = Convert.ToInt32(seDevidePointCount.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmboFunction_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.CalcFunction = Function.SetFunc((sender as ComboBoxEdit).SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lueSelectTarget_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lookUpEdit = sender as LookUpEdit;

                AlgorithmSetting.SelectTarget = (SelectTarget)lookUpEdit.EditValue;

                if (AlgorithmSetting.SelectTarget == SelectTarget.Minimum &&
                   (AlgorithmSetting.SelectSelection == SelectSelection.RouletteSelection || AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament))
                {
                    MessageBox.Show("Метод селекции: Колесо рулетки не может использоваться" +
                                    " для решения задачи нахождения глобального минимума");

                    lueSelectSelection.EditValue = SelectSelection.TruncationSelection;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lueSelectParent_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lookUpEdit = sender as LookUpEdit;

                AlgorithmSetting.SelectParent = (SelectParent)lookUpEdit.EditValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lueSelectCross_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lookUpEdit = sender as LookUpEdit;

                AlgorithmSetting.SelectCross = (SelectCross)lookUpEdit.EditValue;

                seDevidePointCount.Enabled = AlgorithmSetting.SelectCross == SelectCross.CrossingoverNPoint ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lueSelectMutate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lookUpEdit = sender as LookUpEdit;

                AlgorithmSetting.SelectMutate = (SelectMutate)lookUpEdit.EditValue;

                seMutateGeneCount.Enabled = AlgorithmSetting.SelectMutate == SelectMutate.MutateNPoint ? true : false;
                seMutationGeneProbability.Enabled = AlgorithmSetting.SelectMutate == SelectMutate.DensityMutate ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lueSelectSelection_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lookUpEdit = sender as LookUpEdit;

                AlgorithmSetting.SelectSelection = (SelectSelection)lookUpEdit.EditValue;

                seSelectionTreshold.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.TruncationSelection ? true : false;

                seGroupSize.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament ||
                                      AlgorithmSetting.SelectSelection == SelectSelection.ClassicTournament ||
                                      AlgorithmSetting.SelectSelection == SelectSelection.EqualProbabilityTournament ? true : false;


                if (AlgorithmSetting.SelectTarget == SelectTarget.Minimum &&
                   (AlgorithmSetting.SelectSelection == SelectSelection.RouletteSelection || AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament))
                {
                    MessageBox.Show("Метод селекции: Колесо рулетки не может использоваться" +
                                    " для решения задачи нахождения глобального минимума");

                    lueSelectTarget.EditValue = SelectTarget.Maxinum;
                }

                ceIsDisplaySelectionResult.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.RouletteSelection ||
                                      AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament ||
                                      AlgorithmSetting.SelectSelection == SelectSelection.ClassicTournament ||
                                      AlgorithmSetting.SelectSelection == SelectSelection.EqualProbabilityTournament ? true : false;

                ceIsDuplicate.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.EqualProbabilityTournament ||
                                        AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament ||
                                        AlgorithmSetting.SelectSelection == SelectSelection.RouletteSelection ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seMutateGeneCount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.MutateGeneCount = Convert.ToInt32(seMutateGeneCount.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seSelectionTreshold_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.SelectionTreshold = Convert.ToDouble(seSelectionTreshold.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seGenerationSize_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.GenerationSize = Convert.ToInt32(seGenerationSize.EditValue);

                ChangeRangeTrack(AlgorithmSetting.GenerationSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sePopulationSize_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.PopulationSize = Convert.ToInt32(sePopulationSize.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seMutationProbability_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.MutationProbability = Convert.ToDouble(seMutationProbability.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seMutationGeneProbability_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.MutationGeneProbability = Convert.ToDouble(seMutationGeneProbability.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seGroupSize_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.GroupSize = Convert.ToInt32(seGroupSize.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ceIsDisplay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.IsDisplaySelectionResult = Convert.ToBoolean(ceIsDisplaySelectionResult.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ceIsDisplayMutateResult_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.IsDisplayMutateResult = Convert.ToBoolean(ceIsDisplayMutateResult.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ceIsDisplayCrossResult_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.IsDisplayCrossResult = Convert.ToBoolean(ceIsDisplayCrossResult.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ceIsDuplicate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.IsDuplicate = Convert.ToBoolean(ceIsDuplicate.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rngPopulationTrack_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                PopulationTrack = Convert.ToInt32(rngPopulationTrack.EditValue);
                ConvertCandidateToSeries(chFunction, 2, GenAlgorithm.AllBestCandidates[PopulationTrack]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seRunAmount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AnalysisSetting.RunAmount = Convert.ToInt32(seRunAmount.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lueAnalysisSelectionMethods_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var checkedComboBoxEdit = sender as CheckedComboBoxEdit;

                var values = checkedComboBoxEdit.EditValue.ToString();

                if (AnalysisSetting.Type == null)
                    return;

                AnalysisSetting.List = MathConvert.ConvertStringToEnumList(AnalysisSetting.Type, values);

                //DisplaySetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lueAnalysisMethod_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lookUpEdit = sender as LookUpEdit;

                AnalysisSetting.SelectMethod = (SelectMethod)lookUpEdit.EditValue;
                LoadAnalysisGeneticOperator();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                AnalysisSetting.RefreshValues(AlgorithmSetting);
                var xtraTabControl = sender as XtraTabControl;

                if (e.Page.Name == xtraTabControl.TabPages[1].Name)
                    DisplaySetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Методы аналитики

        private void sbAnalysis_Click(object sender, EventArgs e)
        {
            try
            {
                if (AnalysisSetting.List.Count == 0)
                {
                    MessageBox.Show("Выберите пожалуйста методы для сравнения!");
                    return;
                }

                AnalysisSetting.RefreshValues(AlgorithmSetting);
                GenAnalysis = new GenAnalysis(meOutputAnalysis, AnalysisSetting);
                GenAnalysis.Start();
                DisplayChartAnalysis();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Отображение результатов аналитики на графике
        /// </summary>
        private void DisplayChartAnalysis()
        {
            try
            {
                chAnalysis.Series.Clear();

                Series series = new Series("Точное решение", ViewType.Line);

                for (int run = 1; run <= AnalysisSetting.RunAmount; run++)
                {
                    series.Points.Add(new SeriesPoint(run, ExtremumPoint.NumericalArgument));
                }

                chAnalysis.Series.Add(series);

                SwapMethods();

                foreach (var item in GenAnalysis.ResultDictionary)
                {
                    //var name = item.Key as SelectSelection;
                    var type = (item.Key).GetType();

                    var strName = GetMethodName(item.Key, type);

                    var otherSeries = GetCandidateSeries(strName, item.Value);

                    chAnalysis.Series.Add(otherSeries);
                }

                AddAxisLabel(chAnalysis, "Прогон", "Наилучший ответ");

                var legend = chAnalysis.Legend;
                legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
                legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
                legend.Direction = LegendDirection.LeftToRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SwapMethods()
        {
            var item = GenAnalysis.ResultDictionary.FirstOrDefault();
            var obj = item.Key;

            if (!(obj is SelectSelection))
            {
                return;
            }

            var isClassicTournament = GenAnalysis.ResultDictionary.Any(d => d.Key == SelectSelection.ClassicTournament);

            if (!isClassicTournament)
                return;

            var isRouletteTournament = GenAnalysis.ResultDictionary.Any(d => d.Key == SelectSelection.RouletteTournament);

            if (!isRouletteTournament)
                return;

            List<Candidate> tempList = new List<Candidate>();

            var list1 = GenAnalysis.ResultDictionary.FirstOrDefault(g => g.Key == SelectSelection.ClassicTournament).Value;
            var list2 = GenAnalysis.ResultDictionary.FirstOrDefault(g => g.Key == SelectSelection.RouletteTournament).Value;

            tempList.AddRange(list1);
            list1.Clear();
            list1.AddRange(list2);
            list2.Clear();
            list2.AddRange(tempList);
        }

        private void ChangeName()
        {
            if (chAnalysis.Series.Any(g => g.Name == "Классическая турнирная селекция" && g.Name == "Турнирная селекция с использованием колеса рулетки"))
            {
                var item1 = chAnalysis.Series.FirstOrDefault(g => g.Name == "Классическая турнирная селекция");
                var item2 = chAnalysis.Series.FirstOrDefault(g => g.Name == "Турнирная селекция с использованием колеса рулетки");
                var temp = item1.Name;
            }
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

        /// <summary>
        /// Получение серии точек на основе входящей последовательности
        /// </summary>
        /// <param name="_text">Название серии</param>
        /// <param name="_candidateList">Список особей</param>
        /// <returns>Серия точек для отображения на графике</returns>
        private Series GetCandidateSeries(string _text, List<Candidate> _candidateList)
        {
            Series series = new Series(_text, ViewType.Line);

            for (int run = 1; run <= AnalysisSetting.RunAmount; run++)
            {
                series.Points.Add(new SeriesPoint(run, _candidateList[run - 1].DecValue));
            }

            return series;
        }

        /// <summary>
        /// Добавление осей для графика
        /// </summary>
        /// <param name="_chartControl">График</param>
        /// <param name="_xAxisLabel">Ось Х</param>
        /// <param name="_yAxisLabel">Ось У</param>
        private void AddAxisLabel(ChartControl _chartControl, string _xAxisLabel, string _yAxisLabel)
        {
            XYDiagram diagram = (XYDiagram)_chartControl.Diagram;

            diagram.AxisX.Title.Visible = true;
            diagram.AxisX.Title.Alignment = StringAlignment.Center;
            diagram.AxisX.Title.Text = _xAxisLabel;
            diagram.AxisX.Title.TextColor = Color.Black;
            diagram.AxisX.Title.Antialiasing = true;
            diagram.AxisX.Title.Font = new Font("Tahoma", 14, FontStyle.Regular);

            diagram.AxisY.Title.Visible = true;
            diagram.AxisY.Title.Alignment = StringAlignment.Center;
            diagram.AxisY.Title.Text = _yAxisLabel;
            diagram.AxisY.Title.TextColor = Color.Black;
            diagram.AxisY.Title.Antialiasing = true;
            diagram.AxisY.Title.Font = new Font("Tahoma", 14, FontStyle.Regular);
        }

        /// <summary>
        /// Отображение настроек генетического алгоритма
        /// </summary>
        private void DisplaySetting()
        {
            var displayResult = new DisplayResult(meDisplaySetting);

            displayResult.ClearText();

            foreach (var prop in AlgorithmSetting.GetType().GetProperties())
            {
                var layoutItem = lcSetting.Items.FindByName($"lci{prop.Name}");

                if (layoutItem == null)
                {
                    continue;
                }

                var value = prop.GetValue(AlgorithmSetting);

                displayResult.DisplayNameWithValue(layoutItem.Text, GetValueByType(value));
            }
        }

        /// <summary>
        /// Преобразование значения объекта в читаемый вид
        /// </summary>
        /// <param name="value">Объект</param>
        /// <returns>Строкое значение</returns>
        private string GetValueByType(object value)
        {
            var type = value.GetType();

            if (type == typeof(bool))
                return GetValueByBool((bool)value);

            if (type == typeof(SelectParent))
                return GetValueByEnum((SelectParent)value);

            if (type == typeof(SelectCross))
                return GetValueByEnum((SelectCross)value);

            if (type == typeof(SelectMutate))
                return GetValueByEnum((SelectMutate)value);

            if (type == typeof(SelectSelection))
                return GetValueByEnum((SelectSelection)value);

            if (type == typeof(SelectTarget))
                return GetValueByEnum((SelectTarget)value);

            if (type.Name == "CalcFunction")
            {
                var name = this.cmboCalcFunction.EditValue.ToString();

                return name;
            }

            return value.ToString();
        }

        /// <summary>
        /// Преобразование значения логического типа в строковый
        /// </summary>
        /// <param name="_isTrue">Объект</param>
        /// <returns>Строковое значение</returns>
        private string GetValueByBool(bool _isTrue)
        {
            return _isTrue ? "Да" : "Нет";
        }

        /// <summary>
        /// Преобразование знчения перечисления в строковый тип
        /// </summary>
        /// <param name="_selectEnumType">Перечисление</param>
        /// <returns>Строковое значение</returns>
        private string GetValueByEnum(object _selectEnumType)
        {
            return (Attribute.GetCustomAttribute(_selectEnumType.GetType().GetField(_selectEnumType.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description;
        }

        #endregion

        
    }
}
