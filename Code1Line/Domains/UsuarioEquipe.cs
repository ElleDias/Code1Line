using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("UsuarioEquipe")]
    public class UsuarioEquipe
    {
        // FK para Usuario
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        // FK para equipe
        public Guid IdEquipe { get; set; }
        [ForeignKey("IdEquipe")]
        public Equipe Equipe { get; set; }
    }
}
