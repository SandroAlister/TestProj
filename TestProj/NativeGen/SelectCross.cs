using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.NativeGen
{
    /// <summary>
    /// Перечисление конфигураций Методов Скрещивания Родителей
    /// </summary>
    public enum SelectCross
    {
        ////[Description("Дискретная рекомбинация")]
        ////DiscreteRecombination,

        [Description("Одноточечный кроссинговер")]
        CrossingoverSinglePoint,

        [Description("Двухточечный кроссинговер")]
        CrossingoverDoublePoint,

        [Description("Многоточечный кроссинговер")]
        CrossingoverNPoint,

        [Description("Однородный кроссинговер")]
        UniformCrossingOver
    }
}
