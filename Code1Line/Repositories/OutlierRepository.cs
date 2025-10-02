using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            var outlierExistente = _context.Outlier.Find(id);
            if (outlierExistente != null)
            {
                outlierExistente.IdUsuario = outlier.IdUsuario;
                outlierExistente.Periodo = outlier.Periodo;
                outlierExistente.Descricao = outlier.Descricao;
                outlierExistente.Tipo = outlier.Tipo;
                _context.SaveChanges();
            }
        }

        public Outlier BuscarPorId(Guid id)
        {
            return _context.Outlier
                           .Include(o => o.Usuario) // Inclui dados do usuário
                           .FirstOrDefault(o => o.IdOutlier == id);
        }

        public void Cadastrar(Outlier novoOutlier)
        {
            _context.Outlier.Add(novoOutlier);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var outlier = _context.Outlier.Find(id);
            if (outlier != null)
            {
                _context.Outlier.Remove(outlier);
                _context.SaveChanges();
            }
        }

        public List<Outlier> Listar()
        {
            return _context.Outlier
                           .Include(o => o.Usuario) // Inclui dados do usuário
                           .ToList();
        }

        public List<Outlier> ListarPorId(Guid id)
        {
            return _context.Outlier
                           .Include(o => o.Usuario)
                           .Where(o => o.IdOutlier == id)
                           .ToList();
        }
    }
}
