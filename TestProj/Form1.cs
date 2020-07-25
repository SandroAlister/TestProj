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

namespace TestProj
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public const double MutationProbability = 0.7; //0.3
        public const double MutationGeneProbability = 0.5;
        public const int PopulationSize = 4;
        public const int GenerationSize = 5;
        public const int TournamentSize = 4;

        Random random = new Random();

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
        /// Количество генов для мутирования
        /// </summary>
        public int MutateGeneCount { get; set; }

        /// <summary>
        /// Порог для отбора усечением
        /// </summary>
        private double SelectionTreshold { get; set; }

        /// <summary>
        /// Список функций
        /// </summary>
        List<string> funcList = new List<string>()
        {
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

        public List<Candidate> IntermediatePopulation { get; set; }

        public Form1()
        {
            InitializeComponent();

            FunctionStep = Convert.ToDouble(seFunctionStep.EditValue);
            FunctionStartValue = Convert.ToInt32(seFunctionStartValue.EditValue);
            FunctionFinishValue = Convert.ToInt32(seFunctionFinishValue.EditValue);

            cmboFunction.Properties.Items.AddRange(funcList);
            cmboFunction.EditValue = cmboFunction.Properties.Items[0];

            LoadConfig();

            seDevidePointCount.Enabled = SelectCross == SelectCross.CrossingoverNPoint ? true : false;

            seMutateGeneCount.Enabled = SelectMutate == SelectMutate.MutateNPoint ? true : false;

            SelectionTreshold = Convert.ToInt32(seSelectionTreshold.EditValue);
        }

        #region Загрузка значений в выпадающие списки конфигураций генетического алгоритма

        /// <summary>
        /// Загрузка значений конфигураций генетического алгоритма
        /// </summary>
        private void LoadConfig()
        {
            LoadSelectTarget();
            LoadSelectParent();
            LoadSelectCross();
            LoadSelectMutate();
            LoadSelectSelection();
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

            lueSelectParent.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo
            {
                FieldName = "value",

                Caption = ""
            });

            lueSelectCross.Properties.DisplayMember = "Description";
            lueSelectCross.Properties.ValueMember = "value";

            lueSelectCross.Properties.DataSource = enumList;

            lueSelectCross.EditValue = enumList[0].value;

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

            SelectSelection = (SelectSelection)enumList[0].value;
        }


        #endregion

        private void NativeGenAlgorithm()
        {
            Population = GenerateFirstPopulation();
            DisplayPopulation(Population);
        }
        private void DisplayPopulation(List<Candidate> population)
        {
            foreach (var item in population)
            {
                meOutPut.Text += "Число" + item.DecValue;
                meOutPut.Text += "\tДвоичный вид " + MathConvert.ConvertBinToString(item.Chromosome);
                meOutPut.Text += "\tФункция приспособленности " + item.Fitness;
                meOutPut.Text += Environment.NewLine;
            }
            meOutPut.Text += Environment.NewLine;
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
                    Chromosome = new Chromosome(MathConvert.ConvertFromDecToBin(list[index])),
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

        private void TournamentSelection()
        {
            //Группа особей, участвующих в турнире
            var tournamentGroup = new List<Candidate>();
            //Список индексов выбранных особей
            var indexList = new List<int>();

            int counter = 0;

            //Заполняем группу особей, которые участвуют в турнире
            while (counter < TournamentSize)
            {
                var index = random.Next(0, Population.Count - 1);

                if (indexList.Exists(g => g == index))
                    continue;

                indexList.Add(index);
                tournamentGroup.Add(Population[index]);

                counter++;
            }

            //var groupCount = Population.Count % TournamentSize == 0 ? Population.Count / TournamentSize : Population.Count / TournamentSize + 1;

            //for (int group = 0; group < TournamentSize; group++)
            //{

            //}

            //В зависимости от цели выбираем лучшую особь по функции принадлежности
            var bestCandidate = SelectTarget == SelectTarget.Maxinum ? tournamentGroup.Max(g => g.Fitness) : tournamentGroup.Min(g => g.Fitness);
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
                child.Add(mask[i] > 0 ? tempParent1[i] : tempParent2[i]);
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
                case SelectSelection.ExclusionSelection:
                    //Inversion(chromosome);
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
        
        //TODO
        private void ExclusionSelection()
        {
            var population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);


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
            var population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);


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

        private void sbStart_Click(object sender, EventArgs e)
        {
            try
            {
                meOutPut.Lines = null;

                Population = GenerateFirstPopulation();
                DisplayPopulation(Population);

                for (int generation = 1; generation <= GenerationSize; generation++)
                {
                    meOutPut.Text += $"Поколение №{generation}";
                    meOutPut.Text += Environment.NewLine;

                    IntermediatePopulation = new List<Candidate>();

                    //Скрещивание и мутация

                    for (int parent1_ID = 0; parent1_ID < PopulationSize; parent1_ID++)
                    {
                        meOutPut.Text += $"Скрещивание {MathConvert.ConvertBinToString(Population[parent1_ID].Chromosome)}";
                        meOutPut.Text += Environment.NewLine;

                        int parent2_ID = SelectParents(parent1_ID);

                        if (parent2_ID < 0)
                        {
                            meOutPut.Text += $"НЕ УДАЛОСЬ!" + Environment.NewLine;
                            continue;
                        }

                        //int parent2_ID = random.Next(0, population.Count - 1);

                        //if (parent2_ID == parent1_ID)
                        //{
                        //    meOutPut.Text += $"НЕ УДАЛОСЬ!" + Environment.NewLine;
                        //    continue;
                        //}

                        //Выбираем 1 Родителя
                        Chromosome parent1 = Population[parent1_ID].Chromosome;
                        Chromosome parent2 = Population[parent2_ID].Chromosome;

                        Candidate childCandidate = new Candidate();
                        Chromosome child = Crossover(parent1, parent2);

                        meOutPut.Text += $"Родитель №1: {MathConvert.ConvertBinToString(parent1)}" + Environment.NewLine;
                        meOutPut.Text += $"Родитель №2: {MathConvert.ConvertBinToString(parent2)}" + Environment.NewLine;
                        meOutPut.Text += $"Потомок: {MathConvert.ConvertBinToString(child)}" + Environment.NewLine;

                        var mutationProbability = random.NextDouble();

                        meOutPut.Text += $"Вероятность мутации у потомка: {mutationProbability};     ";

                        if (mutationProbability <= MutationProbability)
                        {
                            Mutate(child);
                            meOutPut.Text += $"Мутировавший потомок: {MathConvert.ConvertBinToString(child)}";
                        }
                        else
                        {
                            meOutPut.Text += "Мутация не удалась";
                        }

                        meOutPut.Text += Environment.NewLine;

                        ////С указанной вероятностью происходит мутация потомка
                        //if (random.NextDouble() <= MutationProbability)
                        //    Mutate(child);

                        childCandidate.Chromosome = child;
                        childCandidate.DecValue = MathConvert.ConvertFromBinToDec(child);
                        childCandidate.Fitness = CalcFunction(Convert.ToDouble(MathConvert.ConvertFromBinToDec(child)));

                        IntermediatePopulation.Add(childCandidate);
                    }

                    //Population.AddRange(IntermediatePopulation);

                    //meOutPut.Text += $"Промежуточная популяция {generation} поколения " + Environment.NewLine;
                    //foreach (var item in Population)
                    //{
                    //    meOutPut.Text += $"Число{item.DecValue}          ";
                    //    meOutPut.Text += $"Двоичный вид {MathConvert.ConvertBinToString(item.Chromosome)}        ";
                    //    meOutPut.Text += $"Функция приспособленности {item.Fitness}";
                    //    meOutPut.Text += Environment.NewLine;
                    //}
                    //meOutPut.Text += Environment.NewLine;

                    //Селекция
                    Selection();

                    meOutPut.Text += $"Итоговая популяция {generation} поколения " + Environment.NewLine;
                    foreach (var item in Population)
                    {
                        meOutPut.Text += $"Число{item.DecValue}          ";
                        meOutPut.Text += $"Двоичный вид {MathConvert.ConvertBinToString(item.Chromosome)}        ";
                        meOutPut.Text += $"Функция приспособленности {item.Fitness}";
                        meOutPut.Text += Environment.NewLine;
                    }

                    meOutPut.Text += Environment.NewLine;
                    meOutPut.Text += "___________________________";
                    meOutPut.Text += Environment.NewLine;
                }
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

                for (double i = FunctionStartValue; i <= FunctionFinishValue; i += FunctionStep)
                {
                    chFunction.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(i, CalcFunction(i)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        #region Событие изменения значений у выпадащих списков

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
                SelectionTreshold = Convert.ToInt32(seSelectionTreshold.EditValue);
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
                default:
                    return null;

            }
            return calcFunction;
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

        [Description("Отбор вытеснением")]
        ExclusionSelection,

        [Description("Метод Больцмана (метод отжига)")]
        BolzmanSelection
    }

    #endregion

}
