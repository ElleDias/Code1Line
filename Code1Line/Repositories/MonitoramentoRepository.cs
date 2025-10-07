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

        public void Cadastrar(Monitoramento novoMonitoramento)
        {
            _context.Monitoramento.Add(novoMonitoramento);
            _context.SaveChanges();
        }

        public void Atualizar(Guid id, Monitoramento monitoramento)
        {
            var monitoramentoExistente = _context.Monitoramento.Find(id);
            if (monitoramentoExistente != null)
            {
                monitoramentoExistente.IdUsuario = monitoramento.IdUsuario;
                monitoramentoExistente.TempoAtivo = monitoramento.TempoAtivo;
                monitoramentoExistente.TempoInativo = monitoramento.TempoInativo;

                _context.Monitoramento.Update(monitoramentoExistente);
                _context.SaveChanges();
            }
        }

        public void Deletar(Guid id)
        {
            var monitoramento = _context.Monitoramento.Find(id);
            if (monitoramento != null)
            {
                _context.Monitoramento.Remove(monitoramento);
                _context.SaveChanges();
            }
        }

        public Monitoramento BuscarPorId(Guid id)
        {
            return _context.Monitoramento
                .Include(m => m.Usuario)
                .FirstOrDefault(m => m.IdMonitoramento == id);
        }

        public List<Monitoramento> Listar()
        {
            return _context.Monitoramento
                .Include(m => m.Usuario)
                .ToList();
        }

        public List<Monitoramento> ListarPorId(Guid id)
        {
            return _context.Monitoramento
                .Where(m => m.IdUsuario == id)
                .Include(m => m.Usuario)
                .ToList();
        }
    }
}
