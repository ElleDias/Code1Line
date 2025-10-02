using Code1Line.Context;
using Code1Line.Domains;
using Code1Line.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code1Line.Repositories
{
    public class MonitoramentoRepository : IMonitoramentoRepository
    {
        private readonly Code1Line_Context _context;

        public MonitoramentoRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Monitoramento monitoramento)
        {
            throw new NotImplementedException();
        }

        public Monitoramento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Monitoramento novoMonitoramento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Monitoramento> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Monitoramento> ListarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
