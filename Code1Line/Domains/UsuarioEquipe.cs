using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("UsuarioEquipe")]
    public class UsuarioEquipe
    {
        // FK para Usuario
        [Key]
        [Column("id_usuario")]
        public Guid IdUsuario { get; set; }

        // FK para equipe
        [Column("id_equipe")]
        public Guid IdEquipe { get; set; }
        [ForeignKey("IdEquipe")]
        public Equipe Equipe { get; set; }
    }
}
