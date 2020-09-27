using System.ComponentModel;

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
