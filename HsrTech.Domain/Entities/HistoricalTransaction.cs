using System;

namespace HsrTech.Domain.Entities
{
    public class HistoricalTransaction
    {
        public int HistoricalTransactionId { get; set; }
        public int NumberAccount { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public bool FlagTransaction{ get; set; }
    }
}