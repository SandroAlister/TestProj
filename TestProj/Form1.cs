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

namespace TestProj
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public const double MutationProbability = 0.3;
        public const int PopulationSize = 4;
        public const int GenerationSize = 5;

        public double FunctionStep { get; set; }

        private void NativeGenAlgorithm()
        {

        }

        public Form1()
        {
            InitializeComponent();
            FunctionStep = Convert.ToDouble(seFunctionStep.EditValue);
        }


        private void sbStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Начальная популяция
                List<int> decList = new List<int>() { 2, 3, 5, 4 };

                List<Chromosome> chromosomeList = new List<Chromosome>();

                //Приводим ее в двоичную форму 
                foreach (var item in decList)
                {
                    chromosomeList.Add(new Chromosome(MathConvert.ConvertFromDecToBin(item)));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public
        private double Function(double X)
        {
            //double Y = 5 - (24 * X) + (17 * Math.Pow(X, 2)) - (Convert.ToDouble(11 / 3) * Math.Pow(X, 3)) + (0.25 * Math.Pow(X, 4));
            double Y = 5 - (24 * X) + (17 * X * X) - (Convert.ToDouble(11.0 / 3.0) * X * X * X) + (0.25 * X * X * X * X);
            return Y;
        }

        Random random = new Random();
        private Chromosome Crossingover(Chromosome parent1, Chromosome parent2)
        {
            Chromosome child = new Chromosome();
            int splitPoint = random.Next(1, parent1.Count - 1);

            for (int i = 0; i < parent1.Count; i++)
            {
                child.Add(i < splitPoint ? parent1[i] : parent2[i]);
            }

            return child;
        }

        private void sbFunctionEnter_Click(object sender, EventArgs e)
        {
            try
            {
                ////Введенная функция
                //string function = teFuncionInput.Text;

                ////Разделяем функцию на Y'ковую часть и Х'совую часть
                //string[] agrumentsOfFunction = function.Split(new char[] { '=' });

                //string yArgument = agrumentsOfFunction[0];
                //string xArgument = agrumentsOfFunction[1];

                chFunction.Series[0].Points.Clear();

                for (double i = 0.0; i <= 7.0; i += FunctionStep)
                {
                    chFunction.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(i, Function(i)));
                }

                //for (int i = 0; i <= 10; i++)
                //{
                //    chFunction.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(2, 2 * i));
                //}
                //chFunction.DataSource =
                //Вывод на график
                //chFunction.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static class Setting
        {


        }
        private List<double> stepList = new List<double> { 0.05, 0.1, 0.2, 0.5, 1.0, 2.0 };

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
    }
}
