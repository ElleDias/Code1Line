using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    public class Atividades
    {
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public string fim { get; set; }

        public string categoria { get; set; }

        public string Descricao { get; set; }
    }
}
