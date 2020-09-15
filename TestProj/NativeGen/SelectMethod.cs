using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.NativeGen
{
    public enum SelectMethod
    {
        [Description("выбора родительской особи")]
        SelectParent,

        [Description("скрещивания родительских особей")]
        SelectCross,

        [Description("мутации особи потомка")]
        SelectMutate,

        [Description("селекции")]
        SelectSelection
    }
}
