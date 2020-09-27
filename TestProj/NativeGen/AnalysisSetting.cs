using System;
using System.Collections.Generic;

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
        /// Количество прогонов
        /// </summary>
        public int RunAmount { get; set; }

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

        public void SetAnalysisMethod()
        {
            switch (SelectMethod)
            {
                case SelectMethod.SelectParent:
                    Type = typeof(SelectParent);
                    break;
                case SelectMethod.SelectCross:
                    Type = typeof(SelectCross);
                    break;
                case SelectMethod.SelectMutate:
                    Type = typeof(SelectMutate);
                    break;
                case SelectMethod.SelectSelection:
                    Type = typeof(SelectSelection);
                    break;
            }
        }

        private SelectMethod selectMethod;

        public SelectMethod SelectMethod
        {
            get { return selectMethod; }
            set
            {
                selectMethod = value;
                SetAnalysisMethod();
                ClearList();
            }
        }

        public Type Type { get; set; }

        public List<dynamic> List { get; set; }


        private void ClearList()
        {
            List = new List<dynamic>();
        }

    }
}
