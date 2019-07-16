using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Domain.Entities
{
    public class BankAccount
    {
        [Key]
        public int NumberAccount { get; set; }
        public DateTime OpenDate { get; set; }
        public decimal Balance{ get; set; }
        public int ClientId { get; set; }
        public int Limit { get; set; }

        public virtual IList<HistoricalTransaction> HistoricalTransactions { get; set; }
    }
}
