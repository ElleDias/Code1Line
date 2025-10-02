using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    public class Metrica
    {
        public int Id { get; set; }

        // Chave estrangeira
        public int IdUsuario { get; set; }

        // Propriedade de navegação
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public float HorasProdutivas { get; set; }
        public float HorasInprodutivas { get; set; }
        public float HorasNeutras { get; set; }
        public string Periodo { get; set; }
    }
}
