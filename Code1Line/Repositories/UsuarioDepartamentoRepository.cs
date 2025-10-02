using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using Code1Line.Interface;

namespace Code1Line.Repositories
{
    public class UsuarioDepartamentoRepository : IUsuarioDepartamentoRepository
    {
        private readonly Code1Line_Context _context;

        public UsuarioDepartamentoRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioDepartamento>> ListarAsync()
        {
            return await _context.UsuarioDepartamento
                .Include(ud => ud.Usuario)
                .Include(ud => ud.Departamento)
                .ToListAsync();
        }

        public async Task<UsuarioDepartamento?> BuscarPorIdsAsync(Guid idUsuario, Guid idDepartamento)
        {
            return await _context.UsuarioDepartamento
                .Include(ud => ud.Usuario)
                .Include(ud => ud.Departamento)
                .FirstOrDefaultAsync(ud => ud.IdUsuario == idUsuario && ud.IdDepartamento == idDepartamento);
        }

        public async Task<IEnumerable<UsuarioDepartamento>> BuscarPorUsuarioAsync(Guid idUsuario)
        {
            return await _context.UsuarioDepartamento
                .Where(ud => ud.IdUsuario == idUsuario)
                .Include(ud => ud.Departamento)
                .ToListAsync();
        }

        public async Task<IEnumerable<UsuarioDepartamento>> BuscarPorDepartamentoAsync(Guid idDepartamento)
        {
            return await _context.UsuarioDepartamento
                .Where(ud => ud.IdDepartamento == idDepartamento)
                .Include(ud => ud.Usuario)
                .ToListAsync();
        }

        public async Task CadastrarAsync(UsuarioDepartamento usuarioDepartamento)
        {
            await _context.UsuarioDepartamento.AddAsync(usuarioDepartamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid idUsuario, Guid idDepartamento)
        {
            var registro = await _context.UsuarioDepartamento
                .FirstOrDefaultAsync(ud => ud.IdUsuario == idUsuario && ud.IdDepartamento == idDepartamento);

            if (registro != null)
            {
                _context.UsuarioDepartamento.Remove(registro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
