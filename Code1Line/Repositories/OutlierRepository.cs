using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using Code1Line.Interface;

namespace Code1Line.Repositories
{
    public class OutlierRepository : IOutlierRepository
    {
        private readonly Code1Line_Context _context;

        public OutlierRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Outlier>> ListarAsync()
        {
            return await _context.Outlier
                .Include(o => o.Usuario) // carrega o usuário relacionado
                .ToListAsync();
        }

        public async Task<Outlier?> BuscarPorIdAsync(Guid id)
        {
            return await _context.Outlier
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(o => o.IdOutlier == id);
        }

        public async Task<IEnumerable<Outlier>> BuscarPorUsuarioAsync(Guid idUsuario)
        {
            return await _context.Outlier
                .Where(o => o.IdUsuario == idUsuario)
                .Include(o => o.Usuario)
                .ToListAsync();
        }

        public async Task CadastrarAsync(Outlier outlier)
        {
            await _context.Outlier.AddAsync(outlier);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Outlier outlier)
        {
            _context.Outlier.Update(outlier);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var outlier = await _context.Outlier.FindAsync(id);
            if (outlier != null)
            {
                _context.Outlier.Remove(outlier);
                await _context.SaveChangesAsync();
            }
        }
    }
}
