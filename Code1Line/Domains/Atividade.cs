using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("Atividade")] 
    public class Atividade
    {
        [Key]
        [Column("id_atividade")]
        public Guid IdAtividade { get; set; }

        [Column("id_usuario")]
        public Guid IdUsuario { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("inicio")]
        public DateTime? Inicio { get; set; }

        [Column("fim")]
        public DateTime? Fim { get; set; }

        [Column("categoria")]
        public string Categoria { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}
