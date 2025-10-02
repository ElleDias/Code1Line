using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Metrica")]
    public class Metrica
    {
        [Key]
        public Guid IdMetrica { get; set; }

        // FK
        public Guid IdUsuario { get; set; }

        // Propriedade de navegação
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public DateTime HorasProdutivas { get; set; }
        public DateTime HorasInprodutivas { get; set; }
        public DateTime HorasNeutras { get; set; }
        public string Periodo { get; set; }
    }
}
