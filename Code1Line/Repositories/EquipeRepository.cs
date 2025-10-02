using Code1Line.Context;
using Code1Line.Domains;
using Code1Line.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code1Line.Repositories
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly Code1Line_Context _context;

        public EquipeRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Equipe equipe)
        {
            var equipeExistente = _context.Equipe.Find(id);
            if (equipeExistente != null)
            {
                equipeExistente.Nome = equipe.Nome;
                equipeExistente.Descricao = equipe.Descricao;
                _context.SaveChanges();
            }
        }

        public Equipe BuscarPorId(Guid id)
        {
            return _context.Equipe.FirstOrDefault(e => e.IdEquipe == id);
        }

        public void Cadastrar(Equipe novaEquipe)
        {
            _context.Equipe.Add(novaEquipe);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var equipe = _context.Equipe.Find(id);
            if (equipe != null)
            {
                _context.Equipe.Remove(equipe);
                _context.SaveChanges();
            }
        }

        public List<Equipe> Listar()
        {
            return _context.Equipe.ToList();
        }

        public List<Equipe> ListarPorId(Guid id)
        {
            return _context.Equipe
                           .Where(e => e.IdEquipe == id)
                           .ToList();
        }
    }
}
