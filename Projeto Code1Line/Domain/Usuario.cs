using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1Line.Domain;

[Table("Usuario")]
public class Usuario
{
    [Key]
    [Column("Id")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O nome � obrigatorio")]
    [Column (TypeName = "nome")]
    public string Nome { get; set; } = string.Empty;
    [Required(ErrorMessage = "O campo do email � obrigatorio")]
    [Column(TypeName = "email")]    
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "O  campo da senha � obrigatorio")]
    [Column(TypeName = "senha")]
    public string Senha { get; set; } = string.Empty;

    [Column("cargo")]
    public string Cargo { get; set; } = string.Empty; // e.g., "Gestor", "Funcionario", "Gerente"
}
