using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Acessos")]
    public class Acessos
    {
        [Key]
        [Column("id_acesso")]
        public Guid IdAcessos { get; set; }

        // FK
        [Column("id_usuario")]
        public Guid IdUsuario { get; set; }

        // Propriedade de navegação
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Column("ultimo_acesso")]
        public string UltimoAcesso { get; set; }
    }
}
