using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Domain.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public IList<BankAccount> BankAccounts { get; set; }

        public Client()
        {
            BankAccounts = new List<BankAccount>();
        }
    }
}
