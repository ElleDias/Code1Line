namespace Code1Line.Domain;

public class Monitoramento
{
    public int Id { get; set; }
    public int FuncionarioId { get; set; }
    public Funcionario? Funcionario { get; set; }
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    public string Aplicativo { get; set; } = string.Empty;
    public int TempoEmUsoMinutos { get; set; }
}
