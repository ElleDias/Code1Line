using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context; // aqui está o seu DbContext
using Microsoft.EntityFrameworkCore;
using Code1Line.Interfaces;

namespace Code1Line.Repositories
{
    public class AcessosRepository : IAcessoRepository
    {
        private readonly Code1Line_Context _context;

        public AcessosRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Acessos acesso)
        {
            throw new NotImplementedException();
        }

        public Acessos BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Acessos novoAcesso)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Acessos> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Acessos> ListarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
