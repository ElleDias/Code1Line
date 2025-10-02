using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using Code1Line.Interface;

namespace Code1Line.Repositories
{
    public class MetricaRepository : IMetricaRepository
    {
        private readonly Code1Line_Context _context;

        public MetricaRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Metrica>> ListarAsync()
        {
            return await _context.Metrica
                .Include(m => m.Usuario) // carrega o usuário junto
                .ToListAsync();
        }

        public async Task<Metrica?> BuscarPorIdAsync(Guid id)
        {
            return await _context.Metrica
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.IdMetrica == id);
        }

        public async Task<IEnumerable<Metrica>> BuscarPorUsuarioAsync(Guid idUsuario)
        {
            return await _context.Metrica
                .Where(m => m.IdUsuario == idUsuario)
                .Include(m => m.Usuario)
                .ToListAsync();
        }

        public async Task CadastrarAsync(Metrica metrica)
        {
            await _context.Metrica.AddAsync(metrica);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Metrica metrica)
        {
            _context.Metrica.Update(metrica);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var metrica = await _context.Metrica.FindAsync(id);
            if (metrica != null)
            {
                _context.Metrica.Remove(metrica);
                await _context.SaveChangesAsync();
            }
        }
    }
}
