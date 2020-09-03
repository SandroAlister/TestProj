using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.NativeGen
{
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
}
