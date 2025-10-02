using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Outlier")]
    public class Outlier
    {
        [Key]
        public Guid IdOutlier { get; set; }

        // FK
        public Guid IdUsuario { get; set; }

        // Propriedade de navegação
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public string Periodo { get; set; }

        public string Descricao { get; set; }

        public string Tipo { get; set; }
    }
}
