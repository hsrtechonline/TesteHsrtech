using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Domain.Entities.ViewModel
{
    public class DashBoardFilterVM
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TypeFilterEnum Type { get; set; }

        public enum TypeFilterEnum
        {
            Day=1,
            Hour=2,
            Minute=3

        }
    }
}
