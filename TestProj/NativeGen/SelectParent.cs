using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.NativeGen
{
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
}
