using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Monitoramento")]
    public class Monitoramento
    {
        [Key]
        public Guid IdMonitoramento { get; set; }

        [Required]
        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        // Representando duração real
        [Required]
        public TimeSpan TempoAtivo { get; set; }

        [Required]
        public TimeSpan TempoInativo { get; set; }
    }
}
