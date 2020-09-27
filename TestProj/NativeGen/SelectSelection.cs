using System.ComponentModel;

namespace TestProj.NativeGen
{
    /// <summary>
    /// Перечисление конфигураций Методов Селекции
    /// </summary>
    public enum SelectSelection
    {
        [Description("Отбор усечением")]
        TruncationSelection,

        [Description("Элитарный отбор")]
        EliteSelection,

        [Description("Колесо рулетки")]
        RouletteSelection,

        [Description("Равновероятностная турнирная селекция")]
        EqualProbabilityTournament,

        [Description("Классическая турнирная селекция")]
        ClassicTournament,

        [Description("Турнирная селекция с использованием колеса рулетки")]
        RouletteTournament,

        [Description("Метод Больцмана (метод отжига)")]
        BolzmanSelection
    }
}
