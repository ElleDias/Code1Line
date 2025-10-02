using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Funcao")]
    public class Funcao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
