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

        /// <summary>
        /// Объект отображения
        /// </summary>
        public MemoEdit MemoEdit { get; set; }

        /// <summary>
        ///  Отображение текста
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="isNewLine">Перевод на следующую страницу(по умолчанию - да)</param>
        public void DisplayText(string text, bool isNewLine = true)
        {
            MemoEdit.Text += text;

            if (isNewLine)
                AddNewLine();
        }

        /// <summary>
        /// Очистка обхекта отображения
        /// </summary>
        public void ClearText()
        {
            MemoEdit.Lines = null;
        }

        /// <summary>
        /// Отображение популяции
        /// </summary>
        /// <param name="text">Подпись</param>
        /// <param name="population">Популяция</param>
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

        /// <summary>
        /// Отображение элементов популяции
        /// </summary>
        /// <param name="list">Популяция</param>
        /// <param name="text">Подпись</param>
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

        /// <summary>
        /// Перевод на новую строку
        /// </summary>
        public void AddNewLine()
        {
            MemoEdit.Text += Environment.NewLine;
        }

        /// <summary>
        /// Добавление пробелов
        /// </summary>
        /// <param name="count"></param>
        public void AddSpaces(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                MemoEdit.Text += " ";
            }
        }

        /// <summary>
        /// Добавление черты разделения
        /// </summary>
        public void SeparateText()
        {
            MemoEdit.Text += "___________________________";
            MemoEdit.Text += Environment.NewLine;
        }
    }
}
