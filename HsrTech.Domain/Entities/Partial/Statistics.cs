using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Domain.Entities.Partial
{
    public class Statistics
    {
        public StatisticsOptions Options { get; set; }
        public IList<StatisticsItem> Items { get; set; }

        public Statistics(StatisticsOptions options, List<StatisticsItem> items)
        {
            Options = options;
            Items = items;
        }
    }
}
