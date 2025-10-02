using Code1Line.Domains;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("UsuarioFuncao")]
    public class UsuarioFuncao
    {
        // FK para Usuario
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        // FK para equipe
        public Guid IdFuncao { get; set; }
        [ForeignKey("IdFuncao")]
        public Funcao Funcao { get; set; }

        public int dataInicio { get; set; }
        public int dataFim { get; set; }
    }

}
