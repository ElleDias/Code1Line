using Code1Line.Context;
using Code1Line.Domains;
using Code1Line.Interface;
using Code1Line.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code1Line.Repositories
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly Code1Line_Context _context;

        public EquipeRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipe>> ListarAsync()
        {
            return await _context.Equipe.ToListAsync();
        }

        public async Task<Equipe?> BuscarPorIdAsync(Guid id)
        {
            return await _context.Equipe.FindAsync(id);
        }

        public async Task CadastrarAsync(Equipe equipe)
        {
            await _context.Equipe.AddAsync(equipe);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Equipe equipe)
        {
            _context.Equipe.Update(equipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var equipe = await _context.Equipe.FindAsync(id);
            if (equipe != null)
            {
                _context.Equipe.Remove(equipe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
