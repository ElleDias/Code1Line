using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using Code1Line.Interfaces;

namespace Code1Line.Repositories
{
    public class MetricaRepository : IMetricaRepository
    {
        private readonly Code1Line_Context _context;

        public MetricaRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Metrica metrica)
        {
            throw new NotImplementedException();
        }

        public Metrica BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Metrica novaMetrica)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Metrica> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Metrica> ListarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
