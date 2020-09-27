using System.ComponentModel;

namespace TestProj.NativeGen
{
    /// <summary>
    /// Перечисление конфигураций Методов Скрещивания Родителей
    /// </summary>
    public enum SelectCross
    {
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
