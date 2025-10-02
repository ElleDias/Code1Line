using Code1Line.Domains;

namespace Code1Line.Interfaces
{
    public interface IMonitoramentoRepository
    {
        void Cadastrar(Monitoramento novoMonitoramento);
        List<Monitoramento> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Monitoramento monitoramento);
        List<Monitoramento> ListarPorId(Guid id);
        Monitoramento BuscarPorId(Guid id);
    }
}
