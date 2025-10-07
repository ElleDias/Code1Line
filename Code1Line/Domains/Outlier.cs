using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Outlier")]
    public class Outlier
    {
        [Key]
        [Column("id_outlier")]
        public Guid IdOutlier { get; set; }

        // FK
        [Column("id_usuario")]
        public Guid IdUsuario { get; set; }

        // Propriedade de navegação
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Column("periodo")]
        public string Periodo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }
    }
}
