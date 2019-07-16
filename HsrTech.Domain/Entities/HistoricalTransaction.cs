using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Domain.Entities
{
    public class HistoricalTransaction
    {
        [Key]
        public int HistoricalTransactionId { get; set; }
        public int NumberAccount { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public bool FlagTransaction{ get; set; }
    }
}
