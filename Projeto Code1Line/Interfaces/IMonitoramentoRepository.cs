using Code1Line.Domain;

namespace Code1Line.Interfaces;

public interface IMonitoramentoRepository
{
    Task<IEnumerable<Monitoramento>> GetAllAsync();
    Task<Monitoramento?> GetByIdAsync(int id);
    Task AddAsync(Monitoramento monitoramento);
    Task UpdateAsync(Monitoramento monitoramento);
    Task DeleteAsync(int id);
}
