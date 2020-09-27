using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProj.MathFeatures;

namespace TestProj.NativeGen
{
    /// <summary>
    /// Генетический алгоритм
    /// </summary>
    public class GenAlgorithm
    {
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        Random random = new Random();

        public GenAlgorithm() { }
        public GenAlgorithm(MemoEdit memoEdit, AlgorithmSetting algorithmSetting)
        {
            DisplayResult = new DisplayResult(memoEdit);
            AlgorithmSetting = algorithmSetting;
        }
        public GenAlgorithm(MemoEdit memoEdit, AlgorithmSetting algorithmSetting, List<Candidate> firstPopulation)
        {
            DisplayResult = new DisplayResult(memoEdit);
            AlgorithmSetting = algorithmSetting;
            Population = new List<Candidate>();
            Population.AddRange(firstPopulation);
        }

        /// <summary>
        /// Отображение результатов 
        /// </summary>
        public DisplayResult DisplayResult { get; set; }

        /// <summary>
        /// Настройки алгоритма
        /// </summary>
        public AlgorithmSetting AlgorithmSetting { get; set; }

        /// <summary>
        /// Популяция
        /// </summary>
        public List<Candidate> Population { get; set; }

        /// <summary>
        /// Промежуточная популяция, которая хранит только потомков
        /// </summary>
        public List<Candidate> IntermediatePopulation { get; set; }

        /// <summary>
        /// Список популяций каждого поколения
        /// </summary>
        public List<List<Candidate>> AllBestCandidates { get; set; }

        /// <summary>
        /// Время окончания работы генетического алгоритма
        /// </summary>
        public string FinishTimeAlgorithm { get; set; }

        public List<Candidate> FirstCandidateList { get; set; }

        public void ClearPopulation()
        {
            Population = new List<Candidate>();
        }

        /// <summary>
        /// Запуск работы генетического алгоритма
        /// </summary>
        public void Process()
        {
            try
            {
                DateTime startAlgorithm = DateTime.Now;

                AllBestCandidates = new List<List<Candidate>>();

                if(!AlgorithmSetting.IsCompareMethods || Population.Count == 0)
                    Population = GenerateFirstPopulation();

                AllBestCandidates.Add(Population);

                if(!AlgorithmSetting.IsCompareMethods)
                    DisplayResult.DisplayPopulation("Начальная популяция", Population);

                for (int generation = 1; generation <= AlgorithmSetting.GenerationSize; generation++)
                {
                    DateTime startGeneration = DateTime.Now;

                    if(!AlgorithmSetting.IsCompareMethods)
                        DisplayResult.DisplayText($"Поколение №{generation}");

                    IntermediatePopulation = new List<Candidate>();

                    // Скрещивание и мутация
                    for (int parent1_ID = 0; parent1_ID < AlgorithmSetting.PopulationSize; parent1_ID++)
                    {
                        if (!AlgorithmSetting.IsCompareMethods && AlgorithmSetting.IsDisplayCrossResult)
                            DisplayResult.DisplayText($"Скрещивание {MathConvert.ConvertBinToString(Population[parent1_ID].Chromosome)}");

                        // Выбираем 2 Родителя
                        int parent2_ID = SelectParents(parent1_ID);

                        if (parent2_ID < 0)
                        {
                            if (!AlgorithmSetting.IsCompareMethods && AlgorithmSetting.IsDisplayCrossResult)
                            {
                                DisplayResult.DisplayText($"СКРЕЩИВАНИЕ НЕ УДАЛОСЬ!");
                                DisplayResult.AddNewLine();
                            }

                            continue;
                        }

                        Chromosome parent1 = Population[parent1_ID].Chromosome;
                        Chromosome parent2 = Population[parent2_ID].Chromosome;

                        Candidate childCandidate = new Candidate();
                        Chromosome child = Crossover(parent1, parent2);

                        if(!AlgorithmSetting.IsCompareMethods && AlgorithmSetting.IsDisplayCrossResult)
                        {
                            DisplayResult.DisplayText($"Родитель №1: {MathConvert.ConvertBinToString(parent1)}");
                            DisplayResult.DisplayText($"Родитель №2: {MathConvert.ConvertBinToString(parent2)}");
                            DisplayResult.DisplayText($"Потомок: {MathConvert.ConvertBinToString(child)}");
                            DisplayResult.AddNewLine();
                        }

                        var mutationProbability = random.NextDouble();

                        if (!AlgorithmSetting.IsCompareMethods && AlgorithmSetting.IsDisplayMutateResult)
                        {
                            DisplayResult.DisplayText($"Вероятность мутации у потомка: {mutationProbability}");
                        }

                        if (mutationProbability <= AlgorithmSetting.MutationProbability)
                        {
                            Mutate(child);
                            if(!AlgorithmSetting.IsCompareMethods && AlgorithmSetting.IsDisplayMutateResult)
                            {
                                DisplayResult.DisplayText($"Мутировавший потомок: {MathConvert.ConvertBinToString(child)}");
                                DisplayResult.AddNewLine();
                            }
                        }
                        else
                        {
                            if (!AlgorithmSetting.IsCompareMethods && AlgorithmSetting.IsDisplayMutateResult)
                            {
                                DisplayResult.DisplayText($"МУТАЦИЯ НЕ УДАЛАСЬ!");
                                DisplayResult.AddNewLine();
                            }
                        }

                        childCandidate.Chromosome = child;
                        childCandidate.DecValue = MathConvert.ConvertFromBinToDec(child, AlgorithmSetting.IsOnlyPositive);
                        childCandidate.Fitness = AlgorithmSetting.CalcFunction(Convert.ToDouble(MathConvert.ConvertFromBinToDec(child, AlgorithmSetting.IsOnlyPositive)));

                        IntermediatePopulation.Add(childCandidate);
                    }

                    //Селекция
                    Selection();

                    if(!AlgorithmSetting.IsCompareMethods)
                        DisplayResult.DisplayPopulation($"Итоговая популяция {generation} поколения", Population);


                    var finishGeneration = StopTimer(startGeneration);

                    if(!AlgorithmSetting.IsCompareMethods)
                    {
                        DisplayResult.DisplayText($"Время расчета {generation} поколения = {finishGeneration}");
                        DisplayResult.SeparateText();
                    }

                    AllBestCandidates.Add(Population);
                }

                if (AlgorithmSetting.IsCompareMethods)
                {
                    Thread.Sleep(random.Next(35,45));
                }

                FinishTimeAlgorithm = StopTimer(startAlgorithm);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Получение наилучней особи
        /// </summary>
        /// <returns></returns>
        public Candidate GetBestCandidate()
        {
            var population = new List<Candidate>();
            population.AddRange(Population);
            
            var bestCandidate = AlgorithmSetting.SelectTarget == SelectTarget.Maxinum ? population.FirstOrDefault(g => g.Fitness == population.Max(y => y.Fitness)) : population.FirstOrDefault(g => g.Fitness == population.Min(y => y.Fitness));

            return bestCandidate;
        }

        /// <summary>
        /// Получение времени окончания
        /// </summary>
        /// <param name="startTime">Начальное время</param>
        /// <returns>Время окончания</returns>
        private string StopTimer(DateTime startTime)
        {
            DateTime finishTime = DateTime.Now;

            var spendTime = finishTime - startTime;

            string spendTimeStr = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    spendTime.Hours, spendTime.Minutes, spendTime.Seconds,
                    spendTime.Milliseconds);

            return spendTimeStr;
        }

        /// <summary>
        /// Генерация первого поколения
        /// </summary>
        /// <returns></returns>
        public List<Candidate> GenerateFirstPopulation()
        {
            //Случайным образом выбираем неповторяющиеся десятичные числа 
            List<int> list = new List<int>();

            int count = 0;
            while (count < AlgorithmSetting.PopulationSize)
            {
                int item = random.Next(AlgorithmSetting.FunctionStartValue, AlgorithmSetting.FunctionFinishValue);

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
                    Chromosome = new Chromosome(MathConvert.ConvertFromDecToBin(list[index], AlgorithmSetting.IsOnlyPositive)),
                    Fitness = AlgorithmSetting.CalcFunction(Convert.ToDouble(list[index]))
                });
            }

            FirstCandidateList = new List<Candidate>();
            FirstCandidateList.AddRange(population);

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

            switch (AlgorithmSetting.SelectParent)
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
        /// Расчет расстояния Хэмминга
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

            switch (AlgorithmSetting.SelectCross)
            {
                //case SelectCross.DiscreteRecombination:
                //    child = DiscreteRecombination(parent1, parent2);
                //    break;
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

            Chromosome child = new Chromosome();

            for (int i = 0; i < tempParent1.Count; i++)
            {
                child.Add(random.NextDouble() < 0.5 ? tempParent1[i] : tempParent2[i]);
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

            Chromosome child = new Chromosome();

            int splitPoint = tempParent1.Count == 1 ? 1 : random.Next(1, tempParent1.Count - 1);

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

            // Если хромосома недостаточна большого размера, то запускается кроссинговер по одной точке
            if(tempParent1.Count == 1)
            {
                return CrossingoverSinglePoint(parent1, parent2);
            }

            Chromosome child = new Chromosome();

            //Генерируем первую точку разреза
            int firstSplitPoint = random.Next(1, tempParent1.Count - 1);

            int secondSplitPoint = firstSplitPoint;

            //Генерируем вторую точку разреза, которая не равна первой
            while (firstSplitPoint == secondSplitPoint)
            {
                secondSplitPoint = random.Next(1, tempParent1.Count - 1);
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
            var devidePointCount = AlgorithmSetting.DevidePointCount;

            //Если количество точек разделения оказывается больше, чем размер хромосом у родителей
            if (AlgorithmSetting.DevidePointCount > parent1.Count - 1 && AlgorithmSetting.DevidePointCount > parent2.Count - 1)
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
                    var tempIndexDevidePoint = random.Next(0, availableDevidePointList.Count - 1);

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

            Chromosome child = new Chromosome();

            List<int> mask = new List<int>();

            //Генерируем маску из 0 и 1
            for (int i = 0; i < tempParent1.Count; i++)
            {
                mask.Add(random.Next(2));
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
            switch (AlgorithmSetting.SelectMutate)
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
            int splitPoint = chromosome.Count == 1 ? 0 : random.Next(0, chromosome.Count - 1);

            chromosome[splitPoint] = chromosome[splitPoint] == 1 ? 0 : 1;
        }

        /// <summary>
        /// Традиционная мутация с N количеством точек разделения
        /// </summary>
        /// <param name="chromosome">Хромосома</param>
        private void MutateNPoint(Chromosome chromosome)
        {
            var mutateGeneCount = AlgorithmSetting.MutateGeneCount;

            // Если количество генов для мутирования оказывается больше, чем размер хромосомы,
            // то уменьшаем для этой хромосомы количество генов для мутирования
            if (AlgorithmSetting.MutateGeneCount > chromosome.Count)
            {
                mutateGeneCount = chromosome.Count;
            }

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
                    var tempIndexMutateGene = random.Next(0, availableMutateGeneList.Count - 1);

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
            for (int i = 0; i < chromosome.Count; i++)
            {
                var mutationGeneProbability = random.NextDouble();

                if (mutationGeneProbability <= AlgorithmSetting.MutationGeneProbability)
                    chromosome[i] = chromosome[i] == 1 ? 0 : 1;
            }
        }

        /// <summary>
        /// Мутация, которой у выбранного гена соседние гены меняются местами
        /// </summary>
        /// <param name="chromosome">Хромосома</param>
        private void GeneExchangeMutate(Chromosome chromosome)
        {
            //Если хромосома состоит из 2 генов, то эти 2 гена меняются между собой
            if (chromosome.Count < 3)
            {
                SwapGenes(chromosome, 0, 1);
                return;
            }
            else
            {
                //Выбранный ген хромосомы
                int devideGene = random.Next(0, chromosome.Count - 1);

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
            switch (AlgorithmSetting.SelectSelection)
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
            var population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < AlgorithmSetting.FunctionStartValue || a.DecValue > AlgorithmSetting.FunctionFinishValue);

            // Сортировка популяции родителей и потомков по максимальному значению функции принадлежности
            population.Sort((a, b) => b.Fitness.CompareTo(a.Fitness));

            // Разворот в обратную сторону отсортированного списка, если необходимо отыскать глобальный минимум
            if (AlgorithmSetting.SelectTarget == SelectTarget.Minimum)
            {
                population.Reverse();
            }

            // Нахождение количества популяций, которые будут участвовать в отборе
            int countOfCandidateForSelection = Convert.ToInt32(Math.Round(population.Count * AlgorithmSetting.SelectionTreshold, MidpointRounding.AwayFromZero));

            // Создание списка особей на основе общей популяции, куда попали особи удовлетворяющие значению порога.
            // Данные особи будут участвовать в отборе
            var truncationPopulation = population.GetRange(0, countOfCandidateForSelection).ToList();

            // Создание итоговой популяции
            var totalPopulation = new List<Candidate>();

            // Добавление в итоговую популяцию особей, участвующих в отборе при помощи генератора случайных чисел
            // В итоговую популяцию могут попасть повторяющиеся особи
            for (int i = 0; i < AlgorithmSetting.PopulationSize; i++)
            {
                totalPopulation.Add(truncationPopulation[random.Next(0, countOfCandidateForSelection)]);
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
            population.RemoveAll(a => a.DecValue < AlgorithmSetting.FunctionStartValue || a.DecValue > AlgorithmSetting.FunctionFinishValue);

            // Сортировка популяции родителей и потомков по максимальному значению функции принадлежности
            population.Sort((a, b) => b.Fitness.CompareTo(a.Fitness));

            // Разворот в обратную сторону отсортированного списка, если необходимо отыскать глобальный минимум
            if (AlgorithmSetting.SelectTarget == SelectTarget.Minimum)
            {
                population.Reverse();
            }

            //Отбор в итоговую популяцию лучших особей
            var totalPopulation = population.GetRange(0, AlgorithmSetting.PopulationSize).ToList();

            Population = totalPopulation;
        }

        /// <summary>
        /// Отбор методом колеса рулетки
        /// </summary>
        private void RouletteSelection()
        {
            var population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < AlgorithmSetting.FunctionStartValue || a.DecValue > AlgorithmSetting.FunctionFinishValue);

            // Итоговая популяция
            List<Candidate> totalPopulation = AlgorithmSetting.IsDuplicate ? Roulette(AlgorithmSetting.PopulationSize, population) : RouletteWithoutDuplicate(AlgorithmSetting.PopulationSize, population);

            Population = totalPopulation;
        }

        /// <summary>
        /// Равновероятностная турнирная селекция (без повторений)
        /// </summary>
        private void EqualProbabilityTournament()
        {
            List<Candidate> population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < AlgorithmSetting.FunctionStartValue || a.DecValue > AlgorithmSetting.FunctionFinishValue);

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
            List<Candidate> population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < AlgorithmSetting.FunctionStartValue || a.DecValue > AlgorithmSetting.FunctionFinishValue);

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
            List<Candidate> population = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            // Удаляем из популяции особи, которые выходят за границы допустимого интервала
            population.RemoveAll(a => a.DecValue < AlgorithmSetting.FunctionStartValue || a.DecValue > AlgorithmSetting.FunctionFinishValue);

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
            var avgPassItemCount = AlgorithmSetting.PopulationSize / _groupList.Count;

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
            if (calcListSize < AlgorithmSetting.PopulationSize)
            {
                // Разница
                var differ = AlgorithmSetting.PopulationSize - calcListSize;

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

            if (AlgorithmSetting.IsDisplaySelectionResult)
            {
                DisplayResult.DisplayText($"Среднее количество особей выходящих из группы: {avgPassItemCount}");
                DisplayResult.DisplayList(passList, "Список особей выходящих из группы");
                DisplayResult.DisplayText($"Рассчитанное количество особей, которые будут в новой популяции: {calcListSize}");
                DisplayResult.AddNewLine();
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
            var groupCount = _candidateList.Count / AlgorithmSetting.GroupSize;
            var modul = _candidateList.Count % AlgorithmSetting.GroupSize;

            if (modul > 0)
                groupCount++;

            if (AlgorithmSetting.IsDisplaySelectionResult)
            {
                DisplayResult.DisplayText($"Размер популяции: {_candidateList.Count}");
                DisplayResult.DisplayText($"Размер группы: {AlgorithmSetting.GroupSize}");
                DisplayResult.DisplayText($"Количество групп: {groupCount} ");
                DisplayResult.DisplayText($"Остаток: {modul}");
                DisplayResult.DisplayText($"Расчитанное количество групп: {groupCount}");
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

                for (int item = 0; item < AlgorithmSetting.GroupSize; item++)
                {
                    if (availableList.Count == 0)
                        break;

                    var tempCandidateId = random.Next(0, availableList.Count);
                    var tempCandidate = availableList[tempCandidateId];

                    // Добавляем особь в популяцию
                    tempGroup.Add(tempCandidate);

                    // Удаляем значение из списка доступных особей
                    availableList.RemoveAt(tempCandidateId);
                }

                if (AlgorithmSetting.IsDisplaySelectionResult)
                    DisplayResult.DisplayList(tempGroup, $"Группа №{group}");

                groupList.Add(tempGroup);
            }

            if (AlgorithmSetting.IsDisplaySelectionResult)
            {
                DisplayResult.DisplayText($"Количество групп: {groupList.Count}");
                DisplayResult.AddNewLine();
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

            for (int i = 0; i < _groupList.Count; i++)
            {
                var tempList = new List<Candidate>();

                tempList = AlgorithmSetting.IsDuplicate ? EqualProb(_passList[i], _groupList[i]) : EqualProbWithoutDublicates(_passList[i], _groupList[i]);

                newPopulation.AddRange(tempList);
            }

            if (AlgorithmSetting.IsDisplaySelectionResult)
            {
                DisplayResult.DisplayList(newPopulation, "Новая популяция");
                DisplayResult.AddNewLine();
            }

            return newPopulation;
        }

        /// <summary>
        /// Отбор наилучших особей с равной вероятностью (без дубликатов)
        /// </summary>
        /// <param name="_passItemCount">Количество особей, которые выйдут из группы</param>
        /// <param name="_candidateList">Группа особей</param>
        /// <returns>Список отобранных особей</returns>
        private List<Candidate> EqualProbWithoutDublicates(int _passItemCount, List<Candidate> _candidateList)
        {
            // Итоговая популяция
            List<Candidate> totalPopulation = new List<Candidate>();

            var availableList = new List<Candidate>();
            availableList.AddRange(_candidateList);

            while (totalPopulation.Count < _passItemCount)
            {
                if (availableList.Count == 0)
                    break;

                var tempCandidateId = random.Next(0, availableList.Count);
                var tempCandidate = availableList[tempCandidateId];

                // Добавляем особь в популяцию
                totalPopulation.Add(tempCandidate);

                // Удаляем значение из списка доступных особей
                availableList.RemoveAt(tempCandidateId);
            }

            return totalPopulation;
        }

        /// <summary>
        /// Отбор наилучших особей с равной вероятностью
        /// </summary>
        /// <param name="_passItemCount">Количество особей, которые выйдут из группы</param>
        /// <param name="_candidateList">Группа особей</param>
        /// <returns>Список отобранных особей</returns>
        private List<Candidate> EqualProb(int _passItemCount, List<Candidate> _candidateList)
        {
            // Итоговая популяция
            List<Candidate> totalPopulation = new List<Candidate>();

            while (totalPopulation.Count < _passItemCount)
            {
                var index = random.Next(0, _candidateList.Count);

                totalPopulation.Add(_candidateList[index]);
            }

            return totalPopulation;
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

            for (int i = 0; i < _groupList.Count; i++)
            {
                var tempList = new List<Candidate>();
                tempList.AddRange(_groupList[i]);

                tempList.Sort((a, b) => b.Fitness.CompareTo(a.Fitness));

                if (AlgorithmSetting.SelectTarget == SelectTarget.Minimum)
                {
                    tempList.Reverse();
                }

                var totalTempList = tempList.Take(_passList[i]).ToList();

                newPopulation.AddRange(totalTempList);
            }

            if (AlgorithmSetting.IsDisplaySelectionResult)
            {
                DisplayResult.DisplayList(newPopulation, "Новая популяция");
                DisplayResult.AddNewLine();
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

                tempList = AlgorithmSetting.IsDuplicate ? Roulette(_passList[i], _groupList[i]) : RouletteWithoutDuplicate(_passList[i], _groupList[i]);

                newPopulation.AddRange(tempList);
            }

            if (AlgorithmSetting.IsDisplaySelectionResult)
            {
                DisplayResult.DisplayList(newPopulation, "Новая популяция");
                DisplayResult.AddNewLine();
            }

            return newPopulation;
        }

        /// <summary>
        /// Отбор наилучших особей методом рулетки
        /// </summary>
        /// <param name="_passItemCount">Количество особей, которые выйдут из группы</param>
        /// <param name="_candidateList">Группа особей</param>
        /// <returns></returns>
        private List<Candidate> Roulette(int _passItemCount, List<Candidate> _candidateList)
        {
            var probabilityList = CalcProbability(_candidateList);

            // Итоговая популяция
            List<Candidate> totalPopulation = new List<Candidate>();

            while (totalPopulation.Count < _passItemCount)
            {
                var probability = random.NextDouble();

                var index = probabilityList.FindIndex(g => probability < g);

                totalPopulation.Add(_candidateList[index]);
            }

            return totalPopulation;
        }

        /// <summary>
        ///  Выбор наилучших особей методом рулетки (без дубликатов)
        /// </summary>
        /// <param name="_passItemCount">Количество особей, которые выйдут из группы</param>
        /// <param name="_candidateList">Группа особей</param>
        /// <returns>Список отобранных особей</returns>
        private List<Candidate> RouletteWithoutDuplicate(int _passItemCount, List<Candidate> _candidateList)
        {
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
                    int index = -1;

                    do{
                        var probability = random.NextDouble();
                        index = probabilityList.FindIndex(g => probability < g);
                    }
                    while(index < 0);

                    totalPopulation.Add(availableList[index]);

                    availableList.RemoveAt(index);
                }
            }

            return totalPopulation;
        }

        /// <summary>
        /// Расчет вероятности
        /// </summary>
        /// <param name="list">Список особей</param>
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
            var population = new List<Candidate>();
            var totalPopulation = new List<Candidate>();

            // Добавление популяции родителей к созданной популяции
            population.AddRange(Population);
            // Добавление популяции потомков к созданной популяции
            population.AddRange(IntermediatePopulation);

            for (int i = 0; i < AlgorithmSetting.PopulationSize; i++)
            {
                int firstCandidate = random.Next(0, population.Count);
                int secondCandidate = 0;

                do
                {
                    secondCandidate = random.Next(0, population.Count);
                }
                while (secondCandidate == firstCandidate);

                double probability = 1 / (1 + Math.Exp((population[firstCandidate].Fitness - population[secondCandidate].Fitness) / Temperature));

                double randomValue = random.NextDouble();

                if (probability > randomValue)
                    totalPopulation.Add(population[firstCandidate]);
                else
                    totalPopulation.Add(population[secondCandidate]);
            }
        }

        #endregion
    }
}