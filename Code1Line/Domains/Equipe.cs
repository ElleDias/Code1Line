using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Equipe")]
    public class Equipe
    {
        [Key]
        public Guid IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
