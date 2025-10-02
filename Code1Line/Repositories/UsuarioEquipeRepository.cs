using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using Code1Line.Interface;

namespace Code1Line.Repositories
{
    public class UsuarioEquipeRepository : IUsuarioEquipeReposiotry
    {
        private readonly Code1Line_Context _context;

        public UsuarioEquipeRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioEquipe>> ListarAsync()
        {
            return await _context.UsuarioEquipe
                .Include(ue => ue.Usuario)
                .Include(ue => ue.Equipe)
                .ToListAsync();
        }

        public async Task<UsuarioEquipe?> BuscarPorIdsAsync(Guid idUsuario, Guid idEquipe)
        {
            return await _context.UsuarioEquipe
                .Include(ue => ue.Usuario)
                .Include(ue => ue.Equipe)
                .FirstOrDefaultAsync(ue => ue.IdUsuario == idUsuario && ue.IdEquipe == idEquipe);
        }

        public async Task<IEnumerable<UsuarioEquipe>> BuscarPorUsuarioAsync(Guid idUsuario)
        {
            return await _context.UsuarioEquipe
                .Where(ue => ue.IdUsuario == idUsuario)
                .Include(ue => ue.Equipe)
                .ToListAsync();
        }

        public async Task<IEnumerable<UsuarioEquipe>> BuscarPorEquipeAsync(Guid idEquipe)
        {
            return await _context.UsuarioEquipe
                .Where(ue => ue.IdEquipe == idEquipe)
                .Include(ue => ue.Usuario)
                .ToListAsync();
        }

        public async Task CadastrarAsync(UsuarioEquipe usuarioEquipe)
        {
            await _context.UsuarioEquipe.AddAsync(usuarioEquipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid idUsuario, Guid idEquipe)
        {
            var registro = await _context.UsuarioEquipe
                .FirstOrDefaultAsync(ue => ue.IdUsuario == idUsuario && ue.IdEquipe == idEquipe);

            if (registro != null)
            {
                _context.UsuarioEquipe.Remove(registro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
