using Code1Line.Context;
using Code1Line.Domains;
using Code1Line.Interface;
using Microsoft.EntityFrameworkCore;

namespace Code1Line.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly Code1Line_Context _context;

        public DepartamentoRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> ListarAsync()
        {
            return await _context.Departamento.ToListAsync();
        }

        public async Task<Departamento?> BuscarPorIdAsync(int id)
        {
            return await _context.Departamento.FindAsync(id);
        }

        public async Task CadastrarAsync(Departamento departamento)
        {
            await _context.Departamento.AddAsync(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Departamento departamento)
        {
            _context.Departamento.Update(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento != null)
            {
                _context.Departamento.Remove(departamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
