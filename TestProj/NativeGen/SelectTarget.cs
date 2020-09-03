using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.NativeGen
{
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
}
