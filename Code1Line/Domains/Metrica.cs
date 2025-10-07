using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Metrica")]
    public class Metrica
    {
        [Key]
        [Column("id_metrica")]
        public Guid IdMetrica { get; set; }

        // FK
        [Column("id_usuario")]
        public Guid IdUsuario { get; set; }

        // Propriedade de navegação
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Column("periodo")]
        public DateTime Periodo { get; set; }

        [Column("horas_produtivas")]
        public DateTime HorasProdutivas { get; set; }

        [Column("horas_improdutivas")]
        public DateTime HorasImprodutivas { get; set; }

        [Column("horas_neutras")]
        public DateTime HorasNeutras { get; set; }

        [Column("score_produtividade")]
        public DateTime scoreProdutividade { get; set; }
        
    }
}
