using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    public class Outlier
    {
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public string Periodo { get; set; }

        public string Descricao { get; set; }

        public string Tipo { get; set; }
    }
}
