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
                cmboFunction.Properties.Items.AddRange(funcList);
                cmboFunction.EditValue = cmboFunction.Properties.Items[0];

                //Выставление параметров функции
                FunctionStep = Convert.ToDouble(seFunctionStep.EditValue);
                AlgorithmSetting.FunctionStartValue = Convert.ToInt32(seFunctionStartValue.EditValue);
                AlgorithmSetting.FunctionFinishValue = Convert.ToInt32(seFunctionFinishValue.EditValue);

                //Выставление настроек ГА
                AlgorithmSetting.GenerationSize = Convert.ToInt32(seGenerationSize.EditValue);
                AlgorithmSetting.PopulationSize = Convert.ToInt32(sePopulationSize.EditValue);
                AlgorithmSetting.SelectionTreshold = Convert.ToDouble(seSelectionTreshold.EditValue);
                AlgorithmSetting.MutationProbability = Convert.ToDouble(seMutationProbability.EditValue);
                AlgorithmSetting.MutationGeneProbability = Convert.ToDouble(seMutationGeneProbability.EditValue);
                AlgorithmSetting.CrossDevidePointCount = Convert.ToInt32(seDevidePointCount.EditValue);
                AlgorithmSetting.MutateGeneCount = Convert.ToInt32(seMutateGeneCount.EditValue);
                AlgorithmSetting.GroupSize = Convert.ToInt32(seGroupSize.EditValue);
                AlgorithmSetting.IsDuplicate = Convert.ToBoolean(ceIsDuplicate.EditValue);
                AlgorithmSetting.IsDisplay = Convert.ToBoolean(ceIsDisplay.EditValue);

                // Блокирование контролов в зависимости от настроек ГА
                seDevidePointCount.Enabled = AlgorithmSetting.SelectCross == SelectCross.CrossingoverNPoint ? true : false;
                seMutateGeneCount.Enabled = AlgorithmSetting.SelectMutate == SelectMutate.MutateNPoint ? true : false;
                seMutationGeneProbability.Enabled = AlgorithmSetting.SelectMutate == SelectMutate.DensityMutate ? true : false;
                seSelectionTreshold.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.TruncationSelection ? true : false;
                seGroupSize.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.ClassicTournament || AlgorithmSetting.SelectSelection == SelectSelection.EqualProbabilityTournament || AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament ? true : false;
                ceIsDuplicate.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.RouletteSelection || AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament ? true : false;
                ceIsDisplay.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.RouletteSelection || AlgorithmSetting.SelectSelection == SelectSelection.ClassicTournament || AlgorithmSetting.SelectSelection == SelectSelection.EqualProbabilityTournament || AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament ? true : false;

                sbStart.Enabled = false;

                ChangeRangeTrack();

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

        private void sbStart_Click(object sender, EventArgs e)
        {
            try
            {
                GenAlgorithm = new GenAlgorithm(meOutPut, AlgorithmSetting);

                GenAlgorithm.Process();

                lcCalcTimer.Text = $"Время расчета {GenAlgorithm.FinishTimeAlgorithm}";

                rngPopulationTrack.Value = rngPopulationTrack.Properties.Maximum;
                GenAlgorithm.GetBestCandidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                chFunction.Series[0].Points.Clear();

                for (double i = AlgorithmSetting.FunctionStartValue; i <= AlgorithmSetting.FunctionFinishValue; i += FunctionStep)
                {
                    chFunction.Series[0].Points.Add(new SeriesPoint(i, AlgorithmSetting.CalcFunction(i)));
                }

                GetGlobalExtremumPoint();

                sbStart.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetGlobalExtremumPoint()
        {
            var pointList = chFunction.Series[0].Points.ToList();

            var extremumGlobalPoint = AlgorithmSetting.SelectTarget == SelectTarget.Maxinum ? GetMaxPoint(pointList) : GetMinPoint(pointList);

            DisplayExtremumPoint(extremumGlobalPoint);
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
        /// Изменение количества делений для trackBar'а
        /// </summary>
        private void ChangeRangeTrack()
        {
            var oldMaxValue = rngPopulationTrack.Properties.Maximum;

            rngPopulationTrack.Properties.Maximum = AlgorithmSetting.GenerationSize;

            if (oldMaxValue == AlgorithmSetting.GenerationSize)
                return;

            if (oldMaxValue < AlgorithmSetting.GenerationSize)
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
       
        /// <summary>
        /// Отобразить точку глобального экстремума на графике
        /// </summary>
        /// <param name="_extremumGlobalPoint">Точкаглобального экстремума</param>
        private void DisplayExtremumPoint(SeriesPoint _extremumGlobalPoint)
        {
            if (chFunction.Series[1].Points.Count > 0)
                chFunction.Series[1].Points.Clear();

            Series series1 = chFunction.Series[1];

            ((LineSeriesView)series1.View).MarkerVisibility = DefaultBoolean.True;
            ((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Circle;
            ((LineSeriesView)series1.View).LineMarkerOptions.Size = 10;
            ((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash;

            chFunction.Series[1].Points.Add(_extremumGlobalPoint);
        }

        private void ConvertCandidateToSeries()
        {
            if (chFunction.Series[2].Points.Count > 0)
                chFunction.Series[2].Points.Clear();
            
            var candidateList = GenAlgorithm.AllBestCandidates[PopulationTrack];

            Series series2 = chFunction.Series[2];

            ((LineSeriesView)series2.View).MarkerVisibility = DefaultBoolean.True;
            ((LineSeriesView)series2.View).LineMarkerOptions.Kind = MarkerKind.Circle;
            ((LineSeriesView)series2.View).LineMarkerOptions.Size = 10;
            ((LineSeriesView)series2.View).LineStyle.DashStyle = DashStyle.Dash;

            foreach (var item in candidateList)
            {
                SeriesPoint seriesPoint = new SeriesPoint(item.DecValue, item.Fitness);
                series2.Points.Add(seriesPoint);
            }
        }

        private void seFunctionStep_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
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

        private void seDevidePointCount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AlgorithmSetting.CrossDevidePointCount = Convert.ToInt32(seDevidePointCount.EditValue);
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

                ceIsDisplay.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.RouletteSelection ||
                                      AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament ||
                                      AlgorithmSetting.SelectSelection == SelectSelection.ClassicTournament ||
                                      AlgorithmSetting.SelectSelection == SelectSelection.EqualProbabilityTournament ? true : false;

                ceIsDuplicate.Enabled = AlgorithmSetting.SelectSelection == SelectSelection.RouletteTournament ||
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

                ChangeRangeTrack();
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
                AlgorithmSetting.IsDisplay = Convert.ToBoolean(ceIsDisplay.EditValue);
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
                ConvertCandidateToSeries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

    }

    #region Function

    public static class Function
    {
        public delegate double CalcFunction(double x);

        /// <summary>
        /// Выбор функции
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static CalcFunction SetFunc(int num)
        {
            CalcFunction calcFunction;

            switch (++num)
            {
                case 1:
                    calcFunction = Func1;
                    break;
                case 2:
                    calcFunction = Func2;
                    break;
                case 3:
                    calcFunction = Func3;
                    break;
                case 4:
                    calcFunction = Func4;
                    break;
                case 5:
                    calcFunction = Func5;
                    break;
                default:
                    return null;

            }
            return calcFunction;
        }

        static double Func1(double x)
        {
            return x;
        }
        static double Func2(double x)
        {
            return x * x;
        }
        static double Func3(double x)
        {
            return x + 2;
        }
        static double Func4(double x)
        {
            return x * x + 2 * x + 10;
        }
        static double Func5(double x)
        {
            double Y = 5 - (24 * x) + (17 * Math.Pow(x, 2)) - (Convert.ToDouble(11.0 / 3.0) * Math.Pow(x, 3)) + (0.25 * Math.Pow(x, 4));
            return Y;
        }
    }

    #endregion

}
