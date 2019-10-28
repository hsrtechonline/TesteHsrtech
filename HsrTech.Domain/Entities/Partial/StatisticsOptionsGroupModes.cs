using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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