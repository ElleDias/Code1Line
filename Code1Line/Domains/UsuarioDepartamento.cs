using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("UsuarioDepartamento")]
    public class UsuarioDepartamento
    {    
        // FK para Usuario
       
        [Key]
        [Column("id_usuario")]
        public Guid IdUsuario { get; set; }

        // FK para Departamento
        [Column("id_departamento")]
        public Guid IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public Departamento Departamento { get; set; }
    }
}
