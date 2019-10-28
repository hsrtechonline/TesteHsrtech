using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Domain.Entities.Partial
{
    public enum StatisticsOptionsGroupModes {
        DAYS,
        HOURS,
        MINUTES
    }
    public class StatisticsOptions
    {
        public StatisticsOptionsGroupModes GroupMode { get; set; }
    }
}