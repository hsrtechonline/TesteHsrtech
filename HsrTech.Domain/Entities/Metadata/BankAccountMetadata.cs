using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HsrTech.Domain.Entities.Metadata
{
    [MetadataType(typeof(BankAccountMetadata))]
    public partial class BankAccount { }
    public class BankAccountMetadata
    {
        public int NumberAccount { get; set; }
        public DateTime? OpenDate { get; set; }
        [DisplayName("Saldo inicial")]
        [Required(ErrorMessage = "Favor informar o {0}")]
        public decimal Balance { get; set; }
        public int ClientId { get; set; }

        [DisplayName("Limite inicial")]
        [Required(ErrorMessage = "Favor informar o {0}")]
        public int Limit { get; set; }
    }
}
