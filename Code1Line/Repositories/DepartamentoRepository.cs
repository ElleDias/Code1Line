using Code1Line.Context;
using Code1Line.Domains;
using Code1Line.Interfaces;
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

        public void Atualizar(Guid id, Departamento departamento)
        {
            var departamentoExistente = _context.Departamento.Find(id);
            if (departamentoExistente != null)
            {
                departamentoExistente.Nome = departamento.Nome;
                departamentoExistente.Descricao = departamento.Descricao;
                _context.SaveChanges();
            }
        }

        public Departamento BuscarPorId(Guid id)
        {
            return _context.Departamento.FirstOrDefault(d => d.Id == id);
        }

        public void Cadastrar(Departamento novoDepartamento)
        {
            _context.Departamento.Add(novoDepartamento);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var departamento = _context.Departamento.Find(id);
            if (departamento != null)
            {
                _context.Departamento.Remove(departamento);
                _context.SaveChanges();
            }
        }

        public List<Departamento> Listar()
        {
            return _context.Departamento.ToList();
        }

        public List<Departamento> ListarPorId(Guid id)
        {
            return _context.Departamento
                           .Where(d => d.Id == id)
                           .ToList();
        }
    }
}
