using System.Collections.Generic;

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
