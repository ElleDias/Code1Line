using Code1Line.Context;
using Code1Line.Domains;
using Code1Line.Interface;
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

        public async Task<IEnumerable<Monitoramento>> ListarAsync()
        {
            return await _context.Monitoramento
                .Include(m => m.Usuario)
                .ToListAsync();
        }

        public async Task<Monitoramento?> BuscarPorIdAsync(Guid id)
        {
            return await _context.Monitoramento
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.IdMonitoramento == id);
        }

        public async Task<IEnumerable<Monitoramento>> BuscarPorUsuarioAsync(Guid idUsuario)
        {
            return await _context.Monitoramento
                .Where(m => m.IdUsuario == idUsuario)
                .Include(m => m.Usuario)
                .ToListAsync();
        }

        public async Task CadastrarAsync(Monitoramento monitoramento)
        {
            await _context.Monitoramento.AddAsync(monitoramento);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Monitoramento monitoramento)
        {
            _context.Monitoramento.Update(monitoramento);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var monitoramento = await _context.Monitoramento.FindAsync(id);
            if (monitoramento != null)
            {
                _context.Monitoramento.Remove(monitoramento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
