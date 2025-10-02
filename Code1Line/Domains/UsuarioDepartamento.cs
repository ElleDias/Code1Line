using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    [Table("UsuarioDepartamento")]
    public class UsuarioDepartamento
    {    
        // FK para Usuario
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        // FK para Departamento
        public Guid IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public Departamento Departamento { get; set; }
    }
}
