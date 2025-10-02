using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using Code1Line.Interfaces;

namespace Code1Line.Repositories
{
    public class OutlierRepository : IOutlierRepository
    {
        private readonly Code1Line_Context _context;

        public OutlierRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Outlier outlier)
        {
            throw new NotImplementedException();
        }

        public Outlier BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Outlier novoOutlier)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Outlier> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Outlier> ListarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
