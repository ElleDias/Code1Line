using Code1Line.Domains;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    public class UsuarioFuncao
    {
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdFuncao")]
        public Funcao Funcao { get; set; }

        public int dataInicio { get; set; }
        public int dataFim { get; set; }
    }

}
