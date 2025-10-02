using Code1Line.Context;
using Code1Line.Domains;
using Code1Line.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code1Line.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly Code1Line_Context _context;

        public void Atualizar(Guid id, Departamento departamento)
        {
            throw new NotImplementedException();
        }

        public Departamento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Departamento novoDepartamento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Departamento> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Departamento> ListarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
