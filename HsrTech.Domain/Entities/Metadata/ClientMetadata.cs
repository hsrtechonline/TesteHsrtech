using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HsrTech.Domain.Entities.Metadata
{
    [MetadataType(typeof(ClientMetadata))]
    public partial class Client { }
    public class ClientMetadata
    {
        [DisplayName("Login")]
        [Required(ErrorMessage = "Favor informar o {0}")]
        public string Login { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Favor informar a {0}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
