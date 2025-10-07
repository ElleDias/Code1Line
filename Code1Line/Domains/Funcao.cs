using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Funcao")]
    public class Funcao
    {
        [Key]
        [Column("id_funcao")]
        public Guid IdFuncao { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }
    }
}
