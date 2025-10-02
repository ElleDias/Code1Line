using Code1Line.Context;
using Code1Line.Domains;
using Code1Line.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code1Line.Repositories
{
    public class EquipeRepository : IEquipeRepository
    {        

        public void Atualizar(Guid id, Equipe equipe)
        {
            throw new NotImplementedException();
        }

        public Equipe BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Equipe novaEquipe)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Equipe> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Equipe> ListarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
