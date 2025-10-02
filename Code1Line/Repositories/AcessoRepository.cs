using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context; // aqui está o seu DbContext
using Microsoft.EntityFrameworkCore;
using Code1Line.Interface;

namespace Code1Line.Repositories
{
    public class AcessosRepository : IAcessoRepository
    {
        private readonly Code1Line_Context _context;

        public AcessosRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Acessos>> ListarAsync()
        {
            return await _context.Acessos
                .Include(a => a.Usuario) // traz também o usuário
                .ToListAsync();
        }

        public async Task<Acessos?> BuscarPorIdAsync(Guid id)
        {
            return await _context.Acessos
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(a => a.IdAcessos == id);
        }

        public async Task<IEnumerable<Acessos>> BuscarPorUsuarioAsync(Guid idUsuario)
        {
            return await _context.Acessos
                .Where(a => a.IdUsuario == idUsuario)
                .Include(a => a.Usuario)
                .ToListAsync();
        }

        public async Task CadastrarAsync(Acessos acesso)
        {
            await _context.Acessos.AddAsync(acesso);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Acessos acesso)
        {
            _context.Acessos.Update(acesso);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var acesso = await _context.Acessos.FindAsync(id);
            if (acesso != null)
            {
                _context.Acessos.Remove(acesso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
