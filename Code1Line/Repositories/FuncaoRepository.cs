using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using Code1Line.Interface;

namespace Code1Line.Repositories
{
    public class FuncaoRepository : IFuncaoRepository
    {
        private readonly Code1Line_Context _context;

        public FuncaoRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Funcao>> ListarAsync()
        {
            return await _context.Funcao.ToListAsync();
        }

        public async Task<Funcao?> BuscarPorIdAsync(int id)
        {
            return await _context.Funcao.FindAsync(id);
        }

        public async Task CadastrarAsync(Funcao funcao)
        {
            await _context.Funcao.AddAsync(funcao);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Funcao funcao)
        {
            _context.Funcao.Update(funcao);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var funcao = await _context.Funcao.FindAsync(id);
            if (funcao != null)
            {
                _context.Funcao.Remove(funcao);
