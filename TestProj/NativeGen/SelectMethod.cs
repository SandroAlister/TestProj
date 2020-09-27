using System.ComponentModel;

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
