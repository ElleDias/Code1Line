using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domains
{
    public class UsuarioDepartamento
    {
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdDepartamento")]
        public Departamento Departamento { get; set; }
    }
}
