using Code1Line.Domains;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code1Line.Interfaces;

namespace Code1Line.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Code1Line_Context _context;

        public UsuarioRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ListarAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> BuscarPorIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task<Usuario> BuscarPorEmailAsync(string email)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
