using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Monitoramento")]
    public class Monitoramento
    {
        [Key]
        public Guid IdMonitoramento { get; set; }

        // FK
        public Guid IdUsuario { get; set; }

        // Propriedade de navegação
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public string TempoAtivo { get; set; }

        public string TempoInativo { get; set; }

        
    }
}
