using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Domain.Entities.ViewModel
{
    public class DashBoardFilterVM
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public enum FilterTypeEnum
        {
            Day,
            Hour,
            Minute
        }
    }
}
