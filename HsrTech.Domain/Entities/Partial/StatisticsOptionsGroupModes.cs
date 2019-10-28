using System.ComponentModel.DataAnnotations;

namespace HsrTech.Domain.Entities.Partial
{
    public enum StatisticsOptionsGroupModes
    {
        [Display(Name = "Dias")]
        DAYS,
        [Display(Name = "Horas")]
        HOURS,
        [Display(Name = "Minutos")]
        MINUTES
    }
}