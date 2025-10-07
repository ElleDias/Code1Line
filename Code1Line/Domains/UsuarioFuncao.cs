using Code1Line.Domains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("UsuarioFuncao")]
    public class UsuarioFuncao
    {
        // FK para Usuario
        [Key]
        [Column("id_usuario")]
        public Guid IdUsuario { get; set; }

        // FK para equipe
        public Guid IdFuncao { get; set; }
        [ForeignKey("IdFuncao")]

        [Column("funcao")]
        public Funcao Funcao { get; set; }

        [Column("data_inicio")]
        public int dataInicio { get; set; }

        [Column("data_fim")]
        public int dataFim { get; set; }
    }

}
