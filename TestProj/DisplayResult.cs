using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj.MathFeatures;
using TestProj.NativeGen;

namespace TestProj
{
    /// <summary>
    /// Отображение результатов на экранной форме
    /// </summary>
    public class DisplayResult
    {
        public DisplayResult() { }

        public DisplayResult(MemoEdit memoEdit)
        {
            MemoEdit = memoEdit;
        }

        public MemoEdit MemoEdit { get; set; }

        public void DisplayText(string text, bool isNewLine = true)
        {
            MemoEdit.Text += text;

            if (isNewLine)
                AddNewLine();
        }
        public void ClearText()
        {
            MemoEdit.Lines = null;
        }
        public void DisplayPopulation(string text, List<Candidate> population)
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
        public void DisplayList(List<int> list, string text = null)
        {
            if (text != null)
                DisplayText($"{text}: ", false);

            foreach (var item in list)
            {
                DisplayText($"{item} ", false);
            }

            AddNewLine();
        }

        public void DisplayList(List<Candidate> list, string text = null)
        {
            if (text != null)
                DisplayText($"{text}: ", false);

            foreach (var item in list)
            {
                DisplayText($"{item} ", false);
            }

            AddNewLine();
        }

        public void AddNewLine()
        {
            MemoEdit.Text += Environment.NewLine;
        }
        public void AddSpaces(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                MemoEdit.Text += " ";
            }
        }
        public void SeparateText()
        {
            MemoEdit.Text += "___________________________";
            MemoEdit.Text += Environment.NewLine;
        }
    }
}
