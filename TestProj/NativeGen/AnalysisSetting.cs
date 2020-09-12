using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.NativeGen
{
    public class AnalysisSetting : AlgorithmSetting
    {
        public AnalysisSetting() : base() { }

        public AnalysisSetting(AlgorithmSetting _algorithmSetting) : base()
        {
            RefreshValues(_algorithmSetting);
        }

        /// <summary>
        /// Копирование значений объекта родительского класса 
        /// </summary>
        /// <param name="_algorithmSetting">Объект родительского класса</param>
        public void RefreshValues(AlgorithmSetting _algorithmSetting)
        {
            foreach (var prop in _algorithmSetting.GetType().GetProperties())
            {
                if (this.GetType().GetProperty(prop.Name).Name != "IsOnlyPositive")
                    this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(_algorithmSetting, null), null);
            }
        }

        /// <summary>
        /// Количество прогонов
        /// </summary>
        public int RunAmount { get; set; }

        /// <summary>
        /// Список методов, которые следует проанализировать
        /// </summary>
        public List<SelectSelection> SelectionList { get; set; }


    }
}
