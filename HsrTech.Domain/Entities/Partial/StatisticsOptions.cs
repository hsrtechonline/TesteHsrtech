using System.ComponentModel;

namespace HsrTech.Domain.Entities.Partial
{
    public class StatisticsOptions
    {
        [DisplayName("Agrupar por:")]
        public StatisticsOptionsGroupModes GroupMode { get; set; } = StatisticsOptionsGroupModes.DAYS;
    }
}