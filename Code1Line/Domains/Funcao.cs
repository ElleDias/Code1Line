using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Funcao")]
    public class Funcao
    {
        [Key]
        public Guid IdFuncao { get; set; }
       
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
