using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Departamento")]
    public class Departamento
    {
        [Key]
        [Column("id_departamento")]
        public Guid IdDepartamento { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }
    }
}
