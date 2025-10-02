using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using Code1Line.Interfaces;

namespace Code1Line.Repositories
{
    public class AtividadesRepository : IAtividadeRepository
    {
        private readonly Code1Line_Context _context;

        public AtividadesRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Atividades atividade)
        {
            throw new NotImplementedException();
        }

        public Atividades BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Atividades novaAtividade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Atividades> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Atividades> ListarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

