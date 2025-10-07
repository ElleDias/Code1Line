using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Mensagens")]
    public class Mensagens
    {
        [Key]
        [Column("id_mensagem")]
        public Guid IdMensagens { get; set; }

        [Column("conteudo")]
        public string Conteudo { get; set; }

        [Column("data_envio")]
        public DateTime DataEnvio { get; set; }

        [Column("lida")]
        public bool Lida { get; set; }
       


    }
}
