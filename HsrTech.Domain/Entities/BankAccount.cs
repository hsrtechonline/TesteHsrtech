using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Domain.Entities
{
    public class BankAccount
    {
        public int NumberAccount { get; set; }
        public DateTime OpenDate { get; set; }
        public decimal Balance{ get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int Limit { get; set; } 

        public IList<HistoricalTransaction> HistoricalTransactions { get; set; }
    }
}
