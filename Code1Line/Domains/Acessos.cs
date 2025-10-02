using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Acessos")]
    public class Acessos
    {
        [Key]
        public Guid IdAcessos { get; set; }

        // FK
        public Guid IdUsuario { get; set; }

        // Propriedade de navegação
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public string UltimoAcesso { get; set; }
    }
}
