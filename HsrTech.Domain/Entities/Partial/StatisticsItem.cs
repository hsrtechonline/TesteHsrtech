﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Domain.Entities.Partial
{
    public class StatisticsItem
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public int Count { get; set; }

        public StatisticsItem(int year, int month, int day, int hour, int minute, int second, int count)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Count = count;
        }
    }

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