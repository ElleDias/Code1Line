using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;

namespace Code1Line.Repositories
{
    public class AcessosRepository : IAcessoRepository
    {
        private readonly Code1Line_Context _context;

        public AcessosRepository(Code1Line_Context context)
        {
            _context = context;
        }

        // Cadastrar novo acesso
        public void Cadastrar(Acessos novoAcesso)
        {
            novoAcesso.IdAcessos = Guid.NewGuid(); // garante que o ID seja único
            _context.Acessos.Add(novoAcesso);
            _context.SaveChanges();
        }

        // Listar todos os acessos
        public List<Acessos> Listar()
        {
            return _context.Acessos
                .Include(a => a.Usuario) // inclui dados do usuário relacionado
                .ToList();
        }

        // Buscar acesso por ID
        public Acessos BuscarPorId(Guid id)
        {
            return _context.Acessos
                .Include(a => a.Usuario)
                .FirstOrDefault(a => a.IdAcessos == id);
        }

        // Listar acessos por ID de usuário
        public List<Acessos> ListarPorId(Guid idUsuario)
        {
            return _context.Acessos
                .Include(a => a.Usuario)
                .Where(a => a.IdUsuario == idUsuario)
                .ToList();
        }

        // Atualizar acesso
        public void Atualizar(Guid id, Acessos acessoAtualizado)
        {
            var acessoExistente = _context.Acessos.Find(id);
            if (acessoExistente != null)
            {
                acessoExistente.IdUsuario = acessoAtualizado.IdUsuario;
                acessoExistente.UltimoAcesso = acessoAtualizado.UltimoAcesso;

                _context.Acessos.Update(acessoExistente);
                _context.SaveChanges();
            }
        }

        // Deletar acesso
        public void Deletar(Guid id)
        {
            var acesso = _context.Acessos.Find(id);
            if (acesso != null)
            {
                _context.Acessos.Remove(acesso);
                _context.SaveChanges();
            }
        }
    }
}
