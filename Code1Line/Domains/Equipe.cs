using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Equipe")]
    public class Equipe
    {
        [Key]
        [Column("id_equipe")]
        public Guid IdEquipe { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }
    }
}
