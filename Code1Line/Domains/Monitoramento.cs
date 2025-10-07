using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Monitoramento")]
    public class Monitoramento
    {
        [Column("id_monitoramento")]
        [Key]
        public Guid IdMonitoramento { get; set; }

        [Column("id_usuario")]
        [Required]
        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Column("tempo_ativo")]
        // Representando duração real
        [Required]
        public TimeSpan TempoAtivo { get; set; }


        [Column("tempo_inativo")]
        [Required]
        public TimeSpan TempoInativo { get; set; }
    }
}
