using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Mensagens")]
    public class Mensagens
    {
        [Key]
        public Guid IdMensagens { get; set; }

        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Lida { get; set; }
       


    }
}
