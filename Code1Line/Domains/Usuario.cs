using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Usuario")]
    public class Usuario
    {

        [Key]
        [Column("id_usuario")]
        public Guid IdUsuario { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("cargo")]
        public string Cargo { get; set; }

        [Column("status")]
        public bool Status { get; set; }
    }
}
