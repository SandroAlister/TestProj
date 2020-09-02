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
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Stopwatch CalcTimer { get; set; }

        Random random = new Random();

        /// <summary>
        /// Количество поколений
        /// </summary>
        public int GenerationSize { get; set; }

        /// <summary>
        /// Размер популяции
        /// </summary>
        public int PopulationSize { get; set; }

        /// <summary>
        /// Список значений для контрола "Шаг функции"
        /// </summary>
        private List<double> stepList = new List<double> { 0.05, 0.1, 0.2, 0.5, 1.0, 2.0 };

        /// <summary>
        /// Шаг функции
        /// </summary>
        public double FunctionStep { get; set; }

        /// <summary>
        /// Начальное значение X
        /// </summary>
        public int FunctionStartValue { get; set; }

        /// <summary>
        /// Конечное значение Х
        /// </summary>
        public int FunctionFinishValue { get; set; }

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
        /// Популяция
        /// </summary>
        public List<Candidate> Population { get; set; }

        /// <summary>
        /// Промежуточная популяция, которая хранит только потомков
        /// </summary>
        public List<Candidate> IntermediatePopulation { get; set; }

        public bool IsOnlyPositive { get { return FunctionStartValue >= 0; } }

        public int PopulationTrack { get; set; }

        public Form1()
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
                FunctionStartValue = Convert.ToInt32(seFunctionStartValue.EditValue);
                FunctionFinishValue = Convert.ToInt32(seFunctionFinishValue.EditValue);

                //Выставление настроек ГА
                GenerationSize = Convert.ToInt32(seGenerationSize.EditValue);
                PopulationSize = Convert.ToInt32(sePopulationSize.EditValue);
                SelectionTreshold = Convert.ToDouble(seSelectionTreshold.EditValue);
                MutationProbability = Convert.ToDouble(seMutationProbability.EditValue);
                MutationGeneProbability = Convert.ToDouble(seMutationGeneProbability.EditValue);
                CrossDevidePointCount = Convert.ToInt32(seDevidePointCount.EditValue);
                MutateGeneCount = Convert.ToInt32(seMutateGeneCount.EditValue);
                GroupSize = Convert.ToInt32(seGroupSize.EditValue);
                IsDuplicate = Convert.ToBoolean(ceIsDuplicate.EditValue);
                IsDisplay = Convert.ToBoolean(ceIsDisplay.EditValue);

                // Блокирование контролов в зависимости от настроек ГА
                seDevidePointCount.Enabled = SelectCross == SelectCross.CrossingoverNPoint ? true : false;
                seMutateGeneCount.Enabled = SelectMutate == SelectMutate.MutateNPoint ? true : false;
                seMutationGeneProbability.Enabled = SelectMutate == SelectMutate.DensityMutate ? true : false;
                seSelectionTreshold.Enabled = SelectSelection == SelectSelection.TruncationSelection ? true : false;
                seGroupSize.Enabled = SelectSelection == SelectSelection.ClassicTournament || SelectSelection == SelectSelection.EqualProbabilityTournament || SelectSelection == SelectSelection.RouletteTournament ? true : false;
                ceIsDuplicate.Enabled = SelectSelection == SelectSelection.RouletteSelection || SelectSelection == SelectSelection.RouletteTournament ? true : false;
                ceIsDisplay.Enabled = SelectSelection == SelectSelection.RouletteSelection || SelectSelection == SelectSelection.ClassicTournament || SelectSelection == SelectSelection.EqualProbabilityTournament || SelectSelection == SelectSelection.RouletteTournament ? true : false;

                ChangeRangeTrack();

                CalcTimer = new Stopwatch();
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

            SelectTarget = (SelectTarget)enumList[0].value;
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

            SelectParent = (SelectParent)enumList[0].value;
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

            SelectCross = (SelectCross)enumList[0].value;
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

            SelectMutate = (SelectMutate)enumList[0].value;
        }

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

            SelectSelection = (SelectSelection)enumList[0].value;
        }

        #endregion

        private void NativeGenAlgorithm()
        {
            Population = GenerateFirstPopulation();
            DisplayPopulation("Начальная популяция", Population);
        }


        /// <summary>
        /// Генерация первого поколения
        /// </summary>
        /// <returns></returns>
        private List<Candidate> GenerateFirstPopulation()
        {
            //Случайным образом выбираем неповторяющиеся десятичные числа 
            List<int> list = new List<int>();

            int count = 0;
            while (count < PopulationSize)
            {
                int item = random.Next(FunctionStartValue, FunctionFinishValue);

                if (list.Exists(g => g == item))
                    continue;

                list.Add(item);

                count++;
            }

            List<Candidate> population = new List<Candidate>();

            //Создаем популяцию на основе выбранных случайных десятичных чисел
            for (int index = 0; index < list.Count; index++)
            {
                population.Add(new Candidate
                {
                    DecValue = list[index],
                    Chromosome = new Chromosome(MathConvert.ConvertFromDecToBin(list[index], IsOnlyPositive)),
                    Fitness = CalcFunction(Convert.ToDouble(list[index]))
                });
            }

            return population;
        }

        #region Методы отбора родителей

        /// <summary>
        /// В зависимости от выбранной конфигурации запускается определенный метод выбора родителей
        /// </summary>
        /// <param name="_parent1_ID">Идентификатор 1 родителя</param>
        /// <returns>Идентификатор 2 родителя</returns>
        private int SelectParents(int _parent1_ID)
        {
            int parent1_ID = _parent1_ID;
            int parent2_ID = -1;

            switch (SelectParent)
            {
                case SelectParent.Panmixia:
                    parent2_ID = Panmixia(parent1_ID);
                    break;
                case SelectParent.InBreeding:
                    parent2_ID = InBreeding(parent1_ID);
                    break;
                case SelectParent.OutBreeding:
                    parent2_ID = OutBreeding(parent1_ID);
                    break;
            }
            return parent2_ID;
        }

        /// <summary>
        /// Панмиксия (оператор выбора родителей)
        /// </summary>
        /// <param name="parent1_ID">Идентификатор 1 Родителя</param>
        /// <returns>Идентификатор 2 Родителя</returns>
        private int Panmixia(int parent1_ID)
        {
            var parent2_ID = random.Next(1, Population.Count);

            if (parent2_ID == parent1_ID)
                return -1;

            return parent2_ID;
        }

        /// <summary>
        /// Инбридинг (оператор выбора родителей)
        /// </summary>
        /// <param name="parent1_ID">Идентификатор 1 Родителя</param>
        /// <returns>Идентификатор 2 Родителя</returns>
        private int InBreeding(int parent1_ID)
        {
            int minHammingDistance = 10000;
            int temp;
            int parent2_ID = 0;

            for (int index = 0; index < Population.Count; index++)
            {
                if (parent1_ID == index)
                    continue;

                temp = CalcHammingDistance(Population[parent1_ID].Chromosome, Population[index].Chromosome);

                if (temp < minHammingDistance)
                {
                    minHammingDistance = temp;
                    parent2_ID = index;
                }
            }

            return parent2_ID;
        }

        /// <summary>
        /// Аутбридинг (оператор выбора родителей)
        /// </summary>
        /// <param name="parent1_ID">Идентификатор 1 Родителя</param>
        /// <returns>Идентификатор 2 Родителя</returns>
        private int OutBreeding(int parent1_ID)
        {
            int maxHammingDistance = 0;
            int temp;
            int parent2_ID = 0;

            for (int index = 0; index < Population.Count; index++)
            {
                if (parent1_ID == index)
                    continue;

                temp = CalcHammingDistance(Population[parent1_ID].Chromosome, Population[index].Chromosome);

                if (temp > maxHammingDistance)
                {
                    maxHammingDistance = temp;
                    parent2_ID = index;
                }
            }

            return parent2_ID;
        }

        /// <summary>
        /// Рассчет расстояния Хэмминга
        /// </summary>
        /// <param name="parent1">Последовательность №1</param>
        /// <param name="probablyParent">Последовательность №2</param>
        /// <returns>Расстояние Хэмминга</returns>
        private int CalcHammingDistance(Chromosome parent1, Chromosome probablyParent)
        {
            var count = 0;

            List<int> tempParent1 = new List<int>();
            List<int> tempProbablyParent = new List<int>();

            tempParent1.AddRange(parent1);
            tempProbablyParent.AddRange(probablyParent);

            CompareParents(tempParent1, tempProbablyParent);

            for (int index = 0; index < tempParent1.Count; index++)
            {
                if (tempParent1[index] != tempProbablyParent[index])
                    count++;
            }

            return count;
        }



        #endregion

        #region Методы скрещивания родителей

        /// <summary>
        /// В зависимости от выбранной конфигурации запускается определенный метод скрещивания родителей 
        /// </summary>
        /// <param name="parent1">Родитель №1</param>
        /// <param name="parent2">Родитель №2</param>
        /// <returns>Потомок</returns>
        private Chromosome Crossover(Chromosome parent1, Chromosome parent2)
        {
            Chromosome child = new Chromosome();

            switch (SelectCross)
            {
                case SelectCross.DiscreteRecombination:
                    child = DiscreteRecombination(parent1, parent2);
                    break;
                case SelectCross.CrossingoverSinglePoint:
                    child = CrossingoverSinglePoint(parent1, parent2);
                    break;
                case SelectCross.CrossingoverDoublePoint:
                    child = CrossingoverDoublePoint(parent1, parent2);
                    break;
                case SelectCross.CrossingoverNPoint:
                    child = CrossingoverNPoint(parent1, parent2);
                    break;
                case SelectCross.UniformCrossingOver:
                    child = UniformCrossingOver(parent1, parent2);
                    break;
            }
            return child;
        }

        /// <summary>
        /// Дискретная рекомбинация
        /// Для создания потомка с равной вероятностью случайно выбирается ген родительской особи
        /// </summary>
        /// <param name="parent1">Родитель 1</param>
        /// <param name="parent2">Родитель 2</param>
        /// <returns>Потомок</returns>
        private Chromosome DiscreteRecombination(Chromosome parent1, Chromosome parent2)
        {
            List<int> tempParent1 = new List<int>();
            List<int> tempParent2 = new List<int>();

            tempParent1.AddRange(parent1);
            tempParent2.AddRange(parent2);

            CompareParents(tempParent1, tempParent2);

            Random rnd = new Random();

            Chromosome child = new Chromosome();

            for (int i = 0; i < tempParent1.Count; i++)
            {
                child.Add(rnd.NextDouble() < 0.5 ? tempParent1[i] : tempParent2[i]);
            }

            return child;
        }

        /// <summary>
        /// Традиционое скрещивание с одной точной разделения 
        /// </summary>
        /// <param name="parent1">Родитель 1</param>
        /// <param name="parent2">Родитель 2</param>
        /// <returns>Потомок</returns>
        private Chromosome CrossingoverSinglePoint(Chromosome parent1, Chromosome parent2)
        {
            List<int> tempParent1 = new List<int>();
            List<int> tempParent2 = new List<int>();

            tempParent1.AddRange(parent1);
            tempParent2.AddRange(parent2);

            CompareParents(tempParent1, tempParent2);

            Random rnd = new Random();

            Chromosome child = new Chromosome();

            int splitPoint = rnd.Next(1, tempParent1.Count - 1);

            for (int i = 0; i < tempParent1.Count; i++)
            {
                child.Add(i < splitPoint ? tempParent1[i] : tempParent2[i]);
            }

            return child;
        }

        /// <summary>
        /// Традиционное скрещивание с 2 точками разделения
        /// </summary>
        /// <param name="parent1">Родитель 1</param>
        /// <param name="parent2">Родитель 2</param>
        /// <returns>Потомок</returns>
        private Chromosome CrossingoverDoublePoint(Chromosome parent1, Chromosome parent2)
        {
            List<int> tempParent1 = new List<int>();
            List<int> tempParent2 = new List<int>();

            tempParent1.AddRange(parent1);
            tempParent2.AddRange(parent2);

            CompareParents(tempParent1, tempParent2);

            Random rnd = new Random();

            Chromosome child = new Chromosome();

            //Генерируем первую точку разреза
            int firstSplitPoint = rnd.Next(1, tempParent1.Count - 1);

            int secondSplitPoint = firstSplitPoint;

            //Генерируем вторую точку разреза, которая не равна первой
            while (firstSplitPoint == secondSplitPoint)
            {
                secondSplitPoint = rnd.Next(1, tempParent1.Count - 1);
            }

            //Меняем местами их, если вторая точка оказывается меньше первой
            if (secondSplitPoint < firstSplitPoint)
            {
                int temp = firstSplitPoint;
                firstSplitPoint = secondSplitPoint;
                secondSplitPoint = temp;
            }

            for (int i = 0; i < tempParent1.Count; i++)
            {
                child.Add(i < firstSplitPoint || i >= secondSplitPoint ? tempParent1[i] : tempParent2[i]);
            }

            return child;
        }

        /// <summary>
        /// Традиционное скрещивание с множеством точек разделения
        /// </summary>
        /// <param name="parent1">Родитель 1</param>
        /// <param name="parent2">Родитель 2</param>
        /// <returns>Потомок</returns>
        private Chromosome CrossingoverNPoint(Chromosome parent1, Chromosome parent2)
        {
            var devidePointCount = CrossDevidePointCount;

            //Если количество точек разделения оказывается больше, чем размер хромосом у родителей
            if (CrossDevidePointCount > parent1.Count - 1 && CrossDevidePointCount > parent2.Count - 1)
            {
                //Если хромосома 1 родителя оказывается больше хромосомы 2 родителя, 
                //то переменная количества точек разделения становится равной размеру хромосомы 1 родителя
                if (parent1.Count > parent2.Count)
                    devidePointCount = parent1.Count - 1;
                //иначе переменная количества точек разделения становится развной размеру хромосомы 2 родителя
                else
                    devidePointCount = parent2.Count - 1;
            }

            List<int> tempParent1 = new List<int>();
            List<int> tempParent2 = new List<int>();

            tempParent1.AddRange(parent1);
            tempParent2.AddRange(parent2);

            CompareParents(tempParent1, tempParent2);

            Random rnd = new Random();
            Chromosome child = new Chromosome();

            // Задаем список доступных точек разделения
            List<int> availableDevidePointList = Enumerable.Range(1, tempParent1.Count - 1).ToList();

            // Инициализируем список выбранных точек разделения
            var devidePointList = new List<int>();

            if (devidePointCount == availableDevidePointList.Count)
            {
                devidePointList.AddRange(availableDevidePointList);
            }
            else
            {
                // Генерация точек разделения 
                while (devidePointList.Count < devidePointCount)
                {
                    if (availableDevidePointList.Count == 0)
                        break;

                    // Получаем индекс из списка индексов родителя
                    var tempIndexDevidePoint = rnd.Next(0, availableDevidePointList.Count - 1);

                    // Получаем точку разделения на основе индекса
                    var tempDevidePoint = availableDevidePointList[tempIndexDevidePoint];

                    if (devidePointList.Count != 0 && devidePointList.Exists(i => i == tempDevidePoint))
                        continue;

                    // Добавляем точку в список точек разделения
                    devidePointList.Add(tempDevidePoint);
                    // Удаляем значение из списка индесов родителя 
                    availableDevidePointList.RemoveAt(tempIndexDevidePoint);
                }

                devidePointList.Sort();
            }

            bool IsInheritFromFirstParent = true;

            // Проходим по размеру родителя и добавляем потомку ген в зависимости от флага переключения 
            for (int i = 0; i < tempParent1.Count; i++)
            {
                // Если номер гена равен точке разделения, то делаем переключение флага и удаляем из списка точку разделения
                if (devidePointList.Count != 0 && i == devidePointList.FirstOrDefault())
                {
                    IsInheritFromFirstParent = !IsInheritFromFirstParent;
                    devidePointList.Remove(i);
                }

                child.Add(IsInheritFromFirstParent ? tempParent1[i] : tempParent2[i]);
            }

            return child;
        }

        /// <summary>
        /// Равномерный кроссинговер (с использованием маски)
        /// </summary>
        /// <param name="parent1">Родитель 1</param>
        /// <param name="parent2">Родитель 2</param>
        /// <returns>Потомок</returns>
        private Chromosome UniformCrossingOver(Chromosome parent1, Chromosome parent2)
        {
            List<int> tempParent1 = new List<int>();
            List<int> tempParent2 = new List<int>();

            tempParent1.AddRange(parent1);
            tempParent2.AddRange(parent2);

            CompareParents(tempParent1, tempParent2);

            Random rnd = new Random();

            Chromosome child = new Chromosome();

            List<int> mask = new List<int>();

            //Генерируем маску из 0 и 1
            for (int i = 0; i < tempParent1.Count; i++)
            {
                mask.Add(rnd.Next(2));
            }

            // В зависимости от значения элемента маски выбираем ген того или иного родителя
            for (int i = 0; i < tempParent1.Count; i++)
            {
                child.Add(mask[i] == 0 ? tempParent1[i] : tempParent2[i]);
            }

            return child;
        }

        /// <summary>
        /// Сравнение размеров родителей. 
        /// В случае разных размеров дозаполнение нулями вначале меньшего до размеров большего
        /// </summary>
        /// <param name="parent1">Первый родитель</param>
        /// <param name="parent2">Второй родитель</param>
        private void CompareParents(List<int> parent1, List<int> parent2)
        {
            if (parent1.Count == parent2.Count)
                return;

            if (parent1.Count > parent2.Count)
            {
                int differSize = parent1.Count - parent2.Count;

                parent2.Reverse();
                var parentSize = parent2.Count;
                for (int i = 0; i < differSize; i++)
                {
                    parent2.Add(parent2[parentSize - 1]);
                }

                parent2.Reverse();
            }
            else
            {
                int differSize = parent2.Count - parent1.Count;

                parent1.Reverse();
                var parentSize = parent1.Count;
                for (int i = 0; i < differSize; i++)
                {
                    parent1.Add(parent1[parentSize - 1]);
                }

                parent1.Reverse();
            }
        }

        #endregion

        #region Методы мутации

        /// <summary>
        /// В зависимости от выбранной конфигурации запускается определенный метод мутации потомка
        /// </summary>
        /// <param name="chromosome">Хромосома</param>
        private void Mutate(Chromosome chromosome)
        {
            switch (SelectMutate)
            {
                case SelectMutate.MutateOnePoint:
                    MutateOnePoint(chromosome);
                    break;
                case SelectMutate.MutateNPoint:
                    MutateNPoint(chromosome);
                    break;
                case SelectMutate.Inversion:
                    Inversion(chromosome);
                    break;
                case SelectMutate.DensityMutate:
                    DensityMutate(chromosome);
                    break;
                case SelectMutate.GeneExchangeMutate:
                    GeneExchangeMutate(chromosome);
                    break;
            }
        }

        /// <summary>
        /// Традиционная мутация с одной точкой разделения
        /// </summary>
        /// <param name="chromosome">Хромосома</param>
        private void MutateOnePoint(Chromosome chromosome)
        {
            Random rnd = new Random();

            int splitPoint = rnd.Next(0, chromosome.Count - 1);

            chromosome[splitPoint] = chromosome[splitPoint] == 1 ? 0 : 1;
        }

        /// <summary>
        /// Традиционная мутация с N количеством точек разделения
        /// </summary>
        /// <param name="chromosome">Хромосома</param>
        private void MutateNPoint(Chromosome chromosome)
        {
            var mutateGeneCount = MutateGeneCount;

            // Если количество генов для мутирования оказывается больше, чем размер хромосомы,
            // то уменьшаем для этой хромосомы количество генов для мутирования
            if (MutateGeneCount > chromosome.Count)
            {
                mutateGeneCount = chromosome.Count;
            }

            Random rnd = new Random();

            // Задаем список доступных генов для мутирования
            List<int> availableMutateGeneList = Enumerable.Range(0, chromosome.Count).ToList();

            // Инициализируем список выбранных генов для мутирования
            var mutateGeneList = new List<int>();

            if (mutateGeneCount == availableMutateGeneList.Count)
            {
                mutateGeneList.AddRange(availableMutateGeneList);
            }
            else
            {
                // Генерация генов, которые будут в дальнейшем мутированы 
                while (mutateGeneList.Count < mutateGeneCount)
                {
                    if (availableMutateGeneList.Count == 0)
                        break;

                    // Получаем индекс из списка доступных генов для мутирования
                    var tempIndexMutateGene = rnd.Next(0, availableMutateGeneList.Count - 1);

                    // Получаем на основе индекса ген, который в дальнейшем мутирует
                    var tempMutateGene = availableMutateGeneList[tempIndexMutateGene];

                    if (mutateGeneList.Count != 0 && mutateGeneList.Exists(i => i == tempMutateGene))
                        continue;

                    // Добавляем точку в список мутируемых генов
                    mutateGeneList.Add(tempMutateGene);

                    // Удаляем значение из списка индесов доступных генов 
                    availableMutateGeneList.RemoveAt(tempIndexMutateGene);
                }

                mutateGeneList.Sort();
            }

            // Проходим по хромосоме и инвертируем значение гена
            for (int i = 0; i < chromosome.Count; i++)
            {
                if (mutateGeneList.Count == 0)
                    break;

                // Если номер гена равен значению из списка мутируемых генов, то делаем инвертируем значение гена и удаляем из списка мутируемый ген
                if (i == mutateGeneList.FirstOrDefault())
                {
                    chromosome[i] = chromosome[i] == 1 ? 0 : 1;

                    mutateGeneList.Remove(i);
                }
            }
        }

        /// <summary>
        /// Инверсия генов 
        /// </summary>
        /// <param name="chromosome">Хромосома</param>
        private void Inversion(Chromosome chromosome)
        {
            for (int i = 0; i < chromosome.Count; i++)
            {
                chromosome[i] = chromosome[i] == 1 ? 0 : 1;
            }
        }

        /// <summary>
        /// Плотность мутации
        /// </summary>
        /// <param name="chromosome">Хромосома</param>
        private void DensityMutate(Chromosome chromosome)
        {
            Random rnd = new Random();

            for (int i = 0; i < chromosome.Count; i++)
            {
                var mutationGeneProbability = random.NextDouble();

                if (mutationGeneProbability <= MutationGeneProbability)
                    chromosome[i] = chromosome[i] == 1 ? 0 : 1;
            }
        }

        /// <summary>
        /// Мутация, которой у выбранного гена соседние гены меняются местами
        /// </summary>
        /// <param name="chromosome">Хромосома</param>
        private void GeneExchangeMutate(Chromosome chromosome)
        {
            Random rnd = new Random();

            //Если хромосома состоит из 2 генов, то эти 2 гена меняются между собой
            if (chromosome.Count < 3)
            {
                SwapGenes(chromosome, 0, 1);
                return;
            }
            else
            {
                //Выбранный ген хромосомы
                int devideGene = rnd.Next(0, chromosome.Count - 1);

                //Если выбран 1 ген, то он меняется местами со 2 геном
                if (devideGene == 0)
                {
                    SwapGenes(chromosome, devideGene, devideGene + 1);
                    return;
                }

                //Если выбран последний ген, то он меняется местами с предпоследним геном
                if (devideGene == chromosome.Count - 1)
                {
                    SwapGenes(chromosome, devideGene, devideGene - 1);
                    return;
                }

                //Обмен соседними генами
                SwapGenes(chromosome, devideGene - 1, devideGene + 1);
            }
        }

        /// <summary>
        /// Смена местами генов
        /// </summary>
        /// <param name="chromosome">Хромосома</param>
        /// <param name="firstIndex">Первый ген</param>
        /// <param name="secondIndex">Второй ген</param>
        private void SwapGenes(Chromosome chromosome, int firstIndex, int secondIndex)
        {
            var temp = chromosome[firstIndex];
            chromosome[firstIndex] = chromosome[secondIndex];
            chromosome[secondIndex] = temp;
        }

        #endregion

        #region Методы селекции

        /// <summary>
        /// В зависимости от выбранной конфигурации запускается определенный метод селекции
        /// </summary>
        private void Selection()
        {
            switch (SelectSelection)
            {
                case SelectSelection.TruncationSelection:
                    TruncationSelection();
                    break;
                case SelectSelection.EliteSelection:
                    EliteSelection();
                    break;
                case SelectSelection.RouletteSelection:
                    RouletteSelection();
                    break;
                case SelectSelection.EqualProbabilityTournament:
                    EqualProbabilityTournament();
                    break;
                case SelectSelection.ClassicTournament:
                    ClassicTournament();
                    break;
                case SelectSelection.RouletteTournament:
                    RouletteTournament();
                    break;
                case SelectSelection.BolzmanSelection:
                    BolzmanSelection();
                    break;
            }
        }

        /// <summary>
        /// Отбор усечением
        /// </summary>
        private void TruncationSelection()
        {
            Random rnd = new Random();

            var population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < FunctionStartValue || a.DecValue > FunctionFinishValue);

            // Сортировка популяции родителей и потомков по максимальному значению функции принадлежности
            population.Sort((a, b) => b.Fitness.CompareTo(a.Fitness));

            // Разворот в обратную сторону отсортированного списка, если необходимо отыскать глобальный минимум
            if (SelectTarget == SelectTarget.Minimum)
            {
                population.Reverse();
            }

            // Нахождение количества популяций, которые будут участвовать в отборе
            int countOfCandidateForSelection = Convert.ToInt32(Math.Round(population.Count * SelectionTreshold, MidpointRounding.AwayFromZero));

            // Создание списка особей на основе общей популяции, куда попали особи удовлетворяющие значению порога.
            // Данные особи будут участвовать в отборе
            var truncationPopulation = population.GetRange(0, countOfCandidateForSelection).ToList();

            // Создание итоговой популяции
            var totalPopulation = new List<Candidate>();

            // Добавление в итоговую популяцию особей, участвующих в отборе при помощи генератора случайных чисел
            // В итоговую популяцию могут попасть повторяющиеся особи
            for (int i = 0; i < PopulationSize; i++)
            {
                totalPopulation.Add(truncationPopulation[rnd.Next(0, countOfCandidateForSelection)]);
            }

            Population = totalPopulation;
        }

        /// <summary>
        /// Элитарный отбор
        /// </summary>
        private void EliteSelection()
        {
            var population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < FunctionStartValue || a.DecValue > FunctionFinishValue);

            // Сортировка популяции родителей и потомков по максимальному значению функции принадлежности
            population.Sort((a, b) => b.Fitness.CompareTo(a.Fitness));

            // Разворот в обратную сторону отсортированного списка, если необходимо отыскать глобальный минимум
            if (SelectTarget == SelectTarget.Minimum)
            {
                population.Reverse();
            }

            //Отбор в итоговую популяцию лучших особей
            var totalPopulation = population.GetRange(0, PopulationSize).ToList();

            Population = totalPopulation;
        }

        /// <summary>
        /// Отбор методом колеса рулетки
        /// </summary>
        private void RouletteSelection()
        {
            Random rnd = new Random();

            var population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < FunctionStartValue || a.DecValue > FunctionFinishValue);

            // Итоговая популяция
            List<Candidate> totalPopulation = IsDuplicate ? Roulette(PopulationSize, population) : RouletteWithoutDuplicate(PopulationSize, population);

            Population = totalPopulation;
        }

        /*private void TournamentSelection()
        {
            Random rnd = new Random();

            var population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < FunctionStartValue || a.DecValue > FunctionFinishValue);

            var groupCount = population.Count / GroupSize;

            var modul = population.Count % GroupSize;

            if (modul > 0)
                groupCount++;

            //Список доступных элементов
            List<Candidate> availableList = new List<Candidate>();
            availableList.AddRange(population);

            //Популяция разбитая на группы
            List<List<Candidate>> groupList = new List<List<Candidate>>();

            // Разбиение особей на группы
            for (int group = 0; group < groupCount; group++)
            {
                // Инициализация группы особей
                List<Candidate> tempGroup = new List<Candidate>();

                // Заполнение группы доступными особями
                for (int item = 0; item < GroupSize; item++)
                {
                    // Выход из цикла, если не осталось доступных особей
                    if (availableList.Count == 0)
                        break;

                    var tempCandidateId = rnd.Next(0, availableList.Count);
                    var tempCandidate = availableList[tempCandidateId];

                    // Добавление особи в группу
                    tempGroup.Add(tempCandidate);

                    // Удаление особи из списка доступных особей
                    availableList.RemoveAt(tempCandidateId);
                }

                // Добавление группы особей к остальным группам
                groupList.Add(tempGroup);


            }

            //  Количество особей во всех группах
            var allCount = groupList.Sum(i => i.Count());

            // Итоговая популяция
            var totalList = new List<Candidate>();

            if (allCount % PopulationSize == 0)
            {
                var passCandidateCount = GroupSize / 2;

                foreach (var group in groupList)
                {
                    availableList = new List<Candidate>();
                    availableList.AddRange(group);

                    for (int item = 0; item < passCandidateCount; item++)
                    {
                        var tempCandidateId = rnd.Next(0, availableList.Count);
                        var tempCandidate = availableList[tempCandidateId];

                        // Добавление особи в группу
                        totalList.Add(tempCandidate);

                        // Удаление особи из списка доступных особей
                        availableList.RemoveAt(tempCandidateId);
                    }
                }
            }
            else
            {
                for (int group = groupList.Count - 1; group > 0; group--)
                {
                    availableList = new List<Candidate>();
                    availableList.AddRange(groupList[group]);
                    var passCandidateCount = groupList[group].Count / 2;

                    for (int item = 0; item < passCandidateCount; item++)
                    {
                        var tempCandidateId = rnd.Next(0, availableList.Count);
                        var tempCandidate = availableList[tempCandidateId];

                        // Добавление особи в группу
                        totalList.Add(tempCandidate);

                        // Удаление особи из списка доступных особей
                        availableList.RemoveAt(tempCandidateId);
                    }
                }
            }
        }*/

        /// <summary>
        /// Равновероятностная турнирная селекция (без повторений)
        /// </summary>
        private void EqualProbabilityTournament()
        {
            Random rnd = new Random();

            List<Candidate> population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < FunctionStartValue || a.DecValue > FunctionFinishValue);

            List<List<Candidate>> groupList = GenerateGroups(population);

            List<int> passList = GetPassList(groupList);

            List<Candidate> totalPopulation = GroupSelectionEqualProb(groupList, passList);

            Population = totalPopulation;
        }

        /// <summary>
        /// Класическая турнирная селекция
        /// </summary>
        private void ClassicTournament()
        {
            Random rnd = new Random();

            List<Candidate> population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < FunctionStartValue || a.DecValue > FunctionFinishValue);

            List<List<Candidate>> groupList = GenerateGroups(population);

            List<int> passList = GetPassList(groupList);

            List<Candidate> totalPopulation = GroupSelectionClassic(groupList, passList);

            Population = totalPopulation;
        }

        /// <summary>
        /// Разновероятностная турнирная селекция
        /// </summary>
        private void RouletteTournament()
        {
            Random rnd = new Random();

            List<Candidate> population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < FunctionStartValue || a.DecValue > FunctionFinishValue);

            // Разбиение популяции на группы
            List<List<Candidate>> groupList = GenerateGroups(population);

            //  Получение списка количества особей, которые будут выходить из каждой группы
            List<int> passList = GetPassList(groupList);

            // Получение итоговой популяции
            List<Candidate> totalPopulation = GroupSelectionRoullete(groupList, passList);

            Population = totalPopulation;
        }

        /// <summary>
        /// Получение массива количества особей, которые выходят из группы
        /// </summary>
        /// <param name="_groupList">Список групп особей</param>
        /// <returns>Список особей выходящих из групп</returns>
        private List<int> GetPassList(List<List<Candidate>> _groupList)
        {
            // Среднее количество особей, которые должны выйти из группы
            var avgPassItemCount = PopulationSize / _groupList.Count;

            // Заполняем массив особей, которые выходят из группы средним пропускным количеством
            var passList = new List<int>();
            for (int i = 0; i < _groupList.Count; i++)
            {
                passList.Add(avgPassItemCount);
            }

            // Берем последнюю группу особей
            var lastGroup = _groupList.LastOrDefault();

            // Если ее размер меньше или равен 2, то из группы может выйти только 1 особь
            if (lastGroup.Count <= 2)
                passList[passList.Count - 1] = 1;

            // Рассчитанное количество проходящих особей
            var calcListSize = passList.Sum();

            // Подравнять значения, если рассчитанное количество проходящих особей меньше размера популяции
            if (calcListSize < PopulationSize)
            {
                // Разница
                var differ = PopulationSize - calcListSize;

                for (int counter = 0, index = 0; counter < differ;)
                {
                    // Если дошли до последнего элемента, обнунялем значение индекса и переходим на следующую итерацию
                    if (index == _groupList.Count - 1)
                    {
                        index = 0;
                        continue;
                    }

                    // Увеличиваем для группы количество проходящих особей
                    passList[index] += 1;

                    // Увеличиваем значения счетчика и индекса
                    index++;
                    counter++;
                }

                calcListSize += differ;
            }

            if (IsDisplay)
            {
                DisplayText($"Среднее количество особей выходящих из группы: {avgPassItemCount}");
                DisplayList(passList, "Список особей выходящих из группы");
                DisplayText($"Рассчитанное количество особей, которые будут в новой популяции: {calcListSize}");
                AddNewLine();
            }

            return passList;
        }

        /// <summary>
        ///  Генерация групп (Разбиение популяции на группы)
        /// </summary>
        /// <param name="_candidateList">Популяция (список особей)</param>
        /// <returns>Список групп особей</returns>
        private List<List<Candidate>> GenerateGroups(List<Candidate> _candidateList)
        {
            Random rnd = new Random();

            var groupCount = _candidateList.Count / GroupSize;
            var modul = _candidateList.Count % GroupSize;

            if (modul > 0)
                groupCount++;

            if (IsDisplay)
            {
                DisplayText($"Размер популяции: {_candidateList.Count}");
                DisplayText($"Размер группы: {GroupSize}");
                DisplayText($"Количество групп: {groupCount} ");
                DisplayText($"Остаток: {modul}");
                DisplayText($"Расчитанное количество групп: {groupCount}");
            }

            //Список доступных элементов
            List<Candidate> availableList = new List<Candidate>();
            availableList.AddRange(_candidateList);

            //Популяция разбитая на группы
            List<List<Candidate>> groupList = new List<List<Candidate>>();

            for (int group = 0; group < groupCount; group++)
            {
                // Группа
                List<Candidate> tempGroup = new List<Candidate>();

                for (int item = 0; item < GroupSize; item++)
                {
                    if (availableList.Count == 0)
                        break;

                    var tempCandidateId = rnd.Next(0, availableList.Count);
                    var tempCandidate = availableList[tempCandidateId];

                    // Добавляем особь в популяцию
                    tempGroup.Add(tempCandidate);

                    // Удаляем значение из списка доступных особей
                    availableList.RemoveAt(tempCandidateId);
                }

                if (IsDisplay)
                    DisplayList(tempGroup, $"Группа №{group}");

                groupList.Add(tempGroup);
            }

            if (IsDisplay)
            {
                DisplayText($"Количество групп: {groupList.Count}");
                AddNewLine();
            }

            return groupList;
        }

        /// <summary>
        /// Равновероятностный турнир
        /// </summary>
        /// <param name="_groupList">Список групп особей</param>
        /// <param name="_passList">Список выходящих из группы особей</param>
        /// <returns>Список отобранных особей</returns>
        private List<Candidate> GroupSelectionEqualProb(List<List<Candidate>> _groupList, List<int> _passList)
        {
            var newPopulation = new List<Candidate>();

            Random rnd = new Random();

            for (int i = 0; i < _groupList.Count; i++)
            {
                var availableList = new List<Candidate>();
                availableList.AddRange(_groupList[i]);

                // Группа
                List<Candidate> tempGroup = new List<Candidate>();

                for (int item = 0; item < _passList[i]; item++)
                {
                    if (availableList.Count == 0)
                        break;

                    var tempCandidateId = rnd.Next(0, availableList.Count);
                    var tempCandidate = availableList[tempCandidateId];

                    // Добавляем особь в популяцию
                    tempGroup.Add(tempCandidate);

                    // Удаляем значение из списка доступных особей
                    availableList.RemoveAt(tempCandidateId);
                }

                newPopulation.AddRange(tempGroup);
            }

            if (IsDisplay)
            {
                DisplayList(newPopulation, "Новая популяция");
                AddNewLine();
            }

            return newPopulation;
        }

        /// <summary>
        /// Классический турнир
        /// </summary>
        /// <param name="_groupList">Список групп особей</param>
        /// <param name="_passList">Список выходящих из группы особей</param>
        /// <returns>Список отобранных особей</returns>
        private List<Candidate> GroupSelectionClassic(List<List<Candidate>> _groupList, List<int> _passList)
        {
            var newPopulation = new List<Candidate>();

            Random rnd = new Random();

            for (int i = 0; i < _groupList.Count; i++)
            {
                var tempList = new List<Candidate>();
                tempList.AddRange(_groupList[i]);

                tempList.Sort((a, b) => b.Fitness.CompareTo(a.Fitness));

                if (SelectTarget == SelectTarget.Minimum)
                {
                    tempList.Reverse();
                }

                var totalTempList = tempList.Take(2).ToList();

                newPopulation.AddRange(totalTempList);
            }

            if (IsDisplay)
            {
                DisplayList(newPopulation, "Новая популяция");
                AddNewLine();
            }

            return newPopulation;
        }

        /// <summary>
        /// Разновероятностный турнир
        /// </summary>
        /// <param name="_groupList">Список групп особей</param>
        /// <param name="_passList">Список выходящих из группы особей</param>
        /// <returns>Список отобранных особей</returns>
        private List<Candidate> GroupSelectionRoullete(List<List<Candidate>> _groupList, List<int> _passList)
        {
            var newPopulation = new List<Candidate>();

            for (int i = 0; i < _groupList.Count; i++)
            {
                var tempList = new List<Candidate>();

                tempList = IsDuplicate ? Roulette(_passList[i], _groupList[i]) : RouletteWithoutDuplicate(_passList[i], _groupList[i]);

                newPopulation.AddRange(tempList);
            }

            if (IsDisplay)
            {
                DisplayList(newPopulation, "Новая популяция");
                AddNewLine();
            }

            return newPopulation;
        }

        /// <summary>
        /// Отбор наилучших особей методом рулетки
        /// </summary>
        /// <param name="_passItemCount"></param>
        /// <param name="_candidateList"></param>
        /// <returns></returns>
        private List<Candidate> Roulette(int _passItemCount, List<Candidate> _candidateList)
        {
            Random rnd = new Random();

            var probabilityList = CalcProbability(_candidateList);

            //Общее значение функции приспособленности
            var allFitness = _candidateList.Sum(g => g.Fitness);

            // Итоговая популяция
            List<Candidate> totalPopulation = new List<Candidate>();

            while (totalPopulation.Count < _passItemCount)
            {
                var probability = rnd.NextDouble();

                var index = probabilityList.FindIndex(g => probability < g);

                totalPopulation.Add(_candidateList[index]);
            }

            return totalPopulation;
        }

        /// <summary>
        ///  Выбор наилучших особей методом рулетки (без дубликатов)
        /// </summary>
        /// <param name="_passItemCount">Количество проходящих особей</param>
        /// <param name="_candidateList">Популяция</param>
        /// <returns>Отообранная популяция</returns>
        private List<Candidate> RouletteWithoutDuplicate(int _passItemCount, List<Candidate> _candidateList)
        {
            Random rnd = new Random();

            var population = new List<Candidate>();

            population.AddRange(_candidateList);

            // Итоговая популяция
            List<Candidate> totalPopulation = new List<Candidate>();

            var availableList = new List<Candidate>();
            availableList.AddRange(population);

            if (availableList.Count == _passItemCount)
            {
                totalPopulation.AddRange(availableList);
            }
            else
            {
                while (totalPopulation.Count < _passItemCount)
                {
                    var probabilityList = CalcProbability(availableList);

                    var probability = rnd.NextDouble();
                    var index = probabilityList.FindIndex(g => probability < g);

                    totalPopulation.Add(availableList[index]);

                    availableList.RemoveAt(index);
                }
            }

            return totalPopulation;
        }

        /// <summary>
        /// Расчет вероятности
        /// </summary>
        /// <param name="list">Список</param>
        /// <returns>Список вероятности</returns>
        static List<double> CalcProbability(List<Candidate> _candidateList)
        {
            var probabilityList = new List<double>();

            //Общее значение функции приспособленности
            var allFitness = _candidateList.Sum(g => g.Fitness);

            for (int i = 0; i < _candidateList.Count; i++)
            {
                // Функция приспособленности особи относительно общему значению функции приспособленности
                var probability = _candidateList[i].Fitness / allFitness;

                if (probabilityList.Count == 0)
                    probabilityList.Add(probability);
                else
                    probabilityList.Add(probabilityList[i - 1] + probability);
            }

            return probabilityList;
        }

        /// <summary>
        /// Температура для метода Больцмана
        /// </summary>
        private const int Temperature = 1;

        /// <summary>
        /// Метод Больцмана, или метод отжига
        /// </summary>
        private void BolzmanSelection()
        {
            Random rnd = new Random();

            var population = new List<Candidate>();
            var totalPopulation = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            for (int i = 0; i < PopulationSize; i++)
            {
                int firstCandidate = rnd.Next(0, population.Count);
                int secondCandidate = 0;

                do
                {
                    secondCandidate = rnd.Next(0, population.Count);
                }
                while (secondCandidate == firstCandidate);

                double probability = 1 / (1 + Math.Exp((population[firstCandidate].Fitness - population[secondCandidate].Fitness) / Temperature));

                double randomValue = rnd.NextDouble();

                if (probability > randomValue)
                    totalPopulation.Add(population[firstCandidate]);
                else
                    totalPopulation.Add(population[secondCandidate]);
            }
        }

        /// <summary>
        /// Традиционная селекция
        /// </summary>
        /// <param name="population">Популяция</param>
        /// <param name="selectEnum">Цель поиска</param>
        private void Selection1(List<Candidate> population)
        {
            population.Sort((a, b) => b.Fitness.CompareTo(a.Fitness));
            population.RemoveAll(a => a.DecValue < FunctionStartValue || a.DecValue > FunctionFinishValue);
            switch (SelectTarget)
            {
                case SelectTarget.Maxinum:
                    while (population.Count > PopulationSize)
                    {
                        population.RemoveAt(population.Count - 1);
                    }
                    break;
                case SelectTarget.Minimum:
                    population.Reverse();
                    while (population.Count > PopulationSize)
                    {
                        population.RemoveAt(population.Count - 1);
                    }
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Валидация
        /// </summary>
        /// <returns></returns>
        private bool IsValidated()
        {
            bool leftLessRightValue = FunctionStartValue < FunctionFinishValue;

            return leftLessRightValue;
        }

        private void DisplayText(string text, bool isNewLine = true)
        {
            meOutPut.Text += text;

            if (isNewLine)
                AddNewLine();
        }

        private void DisplayPopulation(string text, List<Candidate> population)
        {
            DisplayText(text);

            foreach (var item in population)
            {
                DisplayText($"Число {item.DecValue}\t", false);
                DisplayText($"Двоичный вид {MathConvert.ConvertBinToString(item.Chromosome)}\t", false);
                DisplayText($"Функция приспособленности {item.Fitness}", false);
                AddNewLine();
            }

            AddNewLine();
        }

        /// <summary>
        /// Отображение элементов списка
        /// </summary>
        /// <param name="list">Список</param>
        /// <param name="text">Название (опционально)</param>
        private void DisplayList(List<int> list, string text = null)
        {
            if (text != null)
                DisplayText($"{text}: ", false);

            foreach (var item in list)
            {
                DisplayText($"{item} ", false);
            }

            AddNewLine();
        }

        private void DisplayList(List<Candidate> list, string text = null)
        {
            if (text != null)
                DisplayText($"{text}: ", false);

            foreach (var item in list)
            {
                DisplayText($"{item} ", false);
            }

            AddNewLine();
        }

        private void AddNewLine()
        {
            meOutPut.Text += Environment.NewLine;
        }
        private void AddSpaces(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                meOutPut.Text += " ";
            }
        }
        private void SeparateText()
        {
            meOutPut.Text += "___________________________";
            meOutPut.Text += Environment.NewLine;
        }

        private void sbStart_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startAlgorithm = DateTime.Now;
                allBestCandidates = new List<List<Candidate>>();
                meOutPut.Lines = null;

                Population = GenerateFirstPopulation();
                allBestCandidates.Add(Population);

                DisplayPopulation("Начальная популяция", Population);

                for (int generation = 1; generation <= GenerationSize; generation++)
                {
                    DateTime startGeneration = DateTime.Now;

                    DisplayText($"Поколение №{generation}");

                    IntermediatePopulation = new List<Candidate>();

                    // Скрещивание и мутация
                    for (int parent1_ID = 0; parent1_ID < PopulationSize; parent1_ID++)
                    {
                        DisplayText($"Скрещивание {MathConvert.ConvertBinToString(Population[parent1_ID].Chromosome)}");

                        // Выбираем 2 Родителя
                        int parent2_ID = SelectParents(parent1_ID);

                        if (parent2_ID < 0)
                        {
                            DisplayText($"СКРЕЩИВАНИЕ НЕ УДАЛОСЬ!");
                            continue;
                        }

                        Chromosome parent1 = Population[parent1_ID].Chromosome;
                        Chromosome parent2 = Population[parent2_ID].Chromosome;

                        Candidate childCandidate = new Candidate();
                        Chromosome child = Crossover(parent1, parent2);

                        DisplayText($"Родитель №1: {MathConvert.ConvertBinToString(parent1)}");
                        DisplayText($"Родитель №2: {MathConvert.ConvertBinToString(parent2)}");
                        DisplayText($"Потомок: {MathConvert.ConvertBinToString(child)}");

                        var mutationProbability = random.NextDouble();
                        AddNewLine();

                        DisplayText($"Вероятность мутации у потомка: {mutationProbability}");

                        if (mutationProbability <= MutationProbability)
                        {
                            Mutate(child);
                            DisplayText($"Мутировавший потомок: {MathConvert.ConvertBinToString(child)}");
                        }
                        else
                        {
                            DisplayText($"МУТАЦИЯ НЕ УДАЛАСЬ!");
                        }

                        AddNewLine();

                        childCandidate.Chromosome = child;
                        childCandidate.DecValue = MathConvert.ConvertFromBinToDec(child, IsOnlyPositive);
                        childCandidate.Fitness = CalcFunction(Convert.ToDouble(MathConvert.ConvertFromBinToDec(child, IsOnlyPositive)));

                        IntermediatePopulation.Add(childCandidate);
                    }

                    //Селекция
                    Selection();

                    DisplayPopulation($"Итоговая популяция {generation} поколения", Population);


                    var finishGeneration = StopTimer(startGeneration);

                    DisplayText($"Время расчета {generation} поколения = {finishGeneration}");
                    SeparateText();
                    allBestCandidates.Add(Population);
                }

                var finishAlgorithm = StopTimer(startAlgorithm);
                lcCalcTimer.Text = $"Время расчета {finishAlgorithm}";
                rngPopulationTrack.Value = rngPopulationTrack.Properties.Maximum;
                var bestCandidate = GetBestCandidate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string StopTimer(DateTime startTime)
        {
            DateTime finishTime = DateTime.Now;

            var spendTime = finishTime - startTime;

            string spendTimeStr = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    spendTime.Hours, spendTime.Minutes, spendTime.Seconds,
                    spendTime.Milliseconds / 10);

            return spendTimeStr;
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

                for (double i = FunctionStartValue; i <= FunctionFinishValue; i += FunctionStep)
                {
                    chFunction.Series[0].Points.Add(new SeriesPoint(i, CalcFunction(i)));
                }

                GetGlobalExtremumPoint();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetGlobalExtremumPoint()
        {
            var pointList = chFunction.Series[0].Points.ToList();

            var extremumGlobalPoint = SelectTarget == SelectTarget.Maxinum ? GetMaxPoint(pointList) : GetMinPoint(pointList);

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

            rngPopulationTrack.Properties.Maximum = GenerationSize;

            if (oldMaxValue == GenerationSize)
                return;

            if (oldMaxValue < GenerationSize)
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

        public List<List<Candidate>> allBestCandidates { get; set; }

        private Candidate GetBestCandidate()
        {
            var population = new List<Candidate>();
            population.AddRange(Population);

            var bestCandidate = population.FirstOrDefault(g=> g.Fitness == population.Max(y => y.Fitness));

            return bestCandidate;
        }
        private void ConvertCandidateToSeries()
        {
            if (chFunction.Series[2].Points.Count > 0)
                chFunction.Series[2].Points.Clear();

            var candidateList = allBestCandidates[PopulationTrack];

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
                FunctionStartValue = Convert.ToInt32(seFunctionStartValue.EditValue);
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
                FunctionFinishValue = Convert.ToInt32(seFunctionFinishValue.EditValue);
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
                CrossDevidePointCount = Convert.ToInt32(seDevidePointCount.EditValue);
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
                CalcFunction = Function.SetFunc((sender as ComboBoxEdit).SelectedIndex);
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

                SelectTarget = (SelectTarget)lookUpEdit.EditValue;

                if (SelectTarget == SelectTarget.Minimum && 
                   (SelectSelection == SelectSelection.RouletteSelection || SelectSelection == SelectSelection.RouletteTournament))
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

                SelectParent = (SelectParent)lookUpEdit.EditValue;
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

                SelectCross = (SelectCross)lookUpEdit.EditValue;

                seDevidePointCount.Enabled = SelectCross == SelectCross.CrossingoverNPoint ? true : false;
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

                SelectMutate = (SelectMutate)lookUpEdit.EditValue;

                seMutateGeneCount.Enabled = SelectMutate == SelectMutate.MutateNPoint ? true : false;
                seMutationGeneProbability.Enabled = SelectMutate == SelectMutate.DensityMutate ? true : false;
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

                SelectSelection = (SelectSelection)lookUpEdit.EditValue;

                seSelectionTreshold.Enabled = SelectSelection == SelectSelection.TruncationSelection ? true : false;

                seGroupSize.Enabled = SelectSelection == SelectSelection.RouletteTournament ||
                                      SelectSelection == SelectSelection.ClassicTournament ||
                                      SelectSelection == SelectSelection.EqualProbabilityTournament ? true : false;


                if (SelectTarget == SelectTarget.Minimum && 
                   (SelectSelection == SelectSelection.RouletteSelection || SelectSelection == SelectSelection.RouletteTournament))
                {
                    MessageBox.Show("Метод селекции: Колесо рулетки не может использоваться" +
                                    " для решения задачи нахождения глобального минимума");

                    lueSelectTarget.EditValue = SelectTarget.Maxinum;
                }

                ceIsDisplay.Enabled = SelectSelection == SelectSelection.RouletteSelection ||
                                      SelectSelection == SelectSelection.RouletteTournament ||
                                      SelectSelection == SelectSelection.ClassicTournament ||
                                      SelectSelection == SelectSelection.EqualProbabilityTournament ? true : false;

                ceIsDuplicate.Enabled = SelectSelection == SelectSelection.RouletteTournament ||
                                        SelectSelection == SelectSelection.RouletteSelection ? true : false;
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
                MutateGeneCount = Convert.ToInt32(seMutateGeneCount.EditValue);
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
                SelectionTreshold = Convert.ToDouble(seSelectionTreshold.EditValue);
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
                GenerationSize = Convert.ToInt32(seGenerationSize.EditValue);

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
                PopulationSize = Convert.ToInt32(sePopulationSize.EditValue);
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
                MutationProbability = Convert.ToDouble(seMutationProbability.EditValue);
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
                MutationGeneProbability = Convert.ToDouble(seMutationGeneProbability.EditValue);
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
                GroupSize = Convert.ToInt32(seGroupSize.EditValue);
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
                IsDisplay = Convert.ToBoolean(ceIsDisplay.EditValue);
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
                IsDuplicate = Convert.ToBoolean(ceIsDuplicate.EditValue);
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
                    calcFunction = Func0;
                    break;
                case 2:
                    calcFunction = Func1;
                    break;
                case 3:
                    calcFunction = Func2;
                    break;
                case 4:
                    calcFunction = Func3;
                    break;
                case 5:
                    calcFunction = Func4;
                    break;
                default:
                    return null;

            }
            return calcFunction;
        }

        static double Func0(double x)
        {
            return x;
        }
        static double Func1(double x)
        {
            return x * x;
        }
        static double Func2(double x)
        {
            return x + 2;
        }
        static double Func3(double x)
        {
            return x * x + 2 * x + 10;
        }
        static double Func4(double x)
        {
            double Y = 5 - (24 * x) + (17 * Math.Pow(x, 2)) - (Convert.ToDouble(11.0 / 3.0) * Math.Pow(x, 3)) + (0.25 * Math.Pow(x, 4));
            return Y;
        }
    }

    #endregion

    #region Перечисления конфигураций для выпадающих списков

    /// <summary>
    /// Перечисление конфигураций Выбора Цели
    /// </summary>
    public enum SelectTarget
    {
        [Description("Максимум")]
        Maxinum,

        [Description("Минимум")]
        Minimum
    }

    /// <summary>
    /// Перечисление конфигураций Выбора Родителей
    /// </summary>
    public enum SelectParent
    {
        [Description("Панмиксия")]
        Panmixia,

        [Description("Инбридинг")]
        InBreeding,

        [Description("Аутбридинг")]
        OutBreeding
    }

    /// <summary>
    /// Перечисление конфигураций Методов Скрещивания Родителей
    /// </summary>
    public enum SelectCross
    {
        [Description("Дискретная рекомбинация")]
        DiscreteRecombination,

        [Description("Одноточечный кроссинговер")]
        CrossingoverSinglePoint,

        [Description("Двухточечный кроссинговер")]
        CrossingoverDoublePoint,

        [Description("Многоточечный кроссинговер")]
        CrossingoverNPoint,

        [Description("Однородный кроссинговер")]
        UniformCrossingOver
    }

    /// <summary>
    /// Перечисление конфигураций Методов Мутации Потомка
    /// </summary>
    public enum SelectMutate
    {
        [Description("Мутация одного гена")]
        MutateOnePoint,

        [Description("Мутация множества генов")]
        MutateNPoint,

        [Description("Инверсия генов")]
        Inversion,

        [Description("Плотность мутации")]
        DensityMutate,

        [Description("Обмен соседними генами")]
        GeneExchangeMutate
    }

    public enum SelectSelection
    {
        [Description("Отбор усечением")]
        TruncationSelection,

        [Description("Элитарный отбор")]
        EliteSelection,

        [Description("Колесо рулетки")]
        RouletteSelection,

        [Description("Равновероятностная турнирная селекция")]
        EqualProbabilityTournament,

        [Description("Классическая турнирная селекция")]
        ClassicTournament,

        [Description("Турнирная селекция с использованием колеса рулетки")]
        RouletteTournament,

        [Description("Метод Больцмана (метод отжига)")]
        BolzmanSelection
    }

    #endregion

}
