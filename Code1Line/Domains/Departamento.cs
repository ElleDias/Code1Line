using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Departamento")]
    public class Departamento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
