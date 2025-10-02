using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using Code1Line.Interface;

namespace Code1Line.Repositories
{
    public class AtividadesRepository : IAtividadeRepository
    {
        private readonly Code1Line_Context _context;

        public AtividadesRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Atividades>> ListarAsync()
        {
            return await _context.Atividades
                .Include(a => a.Usuario) // traz os dados do usuário junto
                .ToListAsync();
        }

        public async Task<Atividades?> BuscarPorIdAsync(Guid id)
        {
            return await _context.Atividades
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(a => a.IdAtividades == id);
        }

        public async Task<IEnumerable<Atividades>> BuscarPorUsuarioAsync(Guid idUsuario)
        {
            return await _context.Atividades
                .Where(a => a.IdUsuario == idUsuario)
                .Include(a => a.Usuario)
                .ToListAsync();
        }

        public async Task CadastrarAsync(Atividades atividade)
        {
            await _context.Atividades.AddAsync(atividade);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Atividades atividade)
        {
            _context.Atividades.Update(atividade);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var atividade = await _context.Atividades.FindAsync(id);
            if (atividade != null)
            {
                _context.Atividades.Remove(atividade);
                await _context.SaveChangesAsync();
            }
        }
    }
}

