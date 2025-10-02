using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Atividades")]
    public class Atividades
    {

        [Key]
        public Guid IdAtividades { get; set; }

        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public string fim { get; set; }

        public string categoria { get; set; }

        public string Descricao { get; set; }
    }
}
