using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            var metricaExistente = _context.Metrica.Find(id);
            if (metricaExistente != null)
            {
                metricaExistente.IdUsuario = metrica.IdUsuario;
                metricaExistente.HorasProdutivas = metrica.HorasProdutivas;
                metricaExistente.HorasInprodutivas = metrica.HorasInprodutivas;
                metricaExistente.HorasNeutras = metrica.HorasNeutras;
                metricaExistente.Periodo = metrica.Periodo;
                _context.SaveChanges();
            }
        }

        public Metrica BuscarPorId(Guid id)
        {
            return _context.Metrica
                           .Include(m => m.Usuario)
                           .FirstOrDefault(m => m.IdMetrica == id);
        }

        public void Cadastrar(Metrica novaMetrica)
        {
            _context.Metrica.Add(novaMetrica);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var metrica = _context.Metrica.Find(id);
            if (metrica != null)
            {
                _context.Metrica.Remove(metrica);
                _context.SaveChanges();
            }
        }

        public List<Metrica> Listar()
        {
            return _context.Metrica
                           .Include(m => m.Usuario)
                           .ToList();
        }

        public List<Metrica> ListarPorId(Guid id)
        {
            return _context.Metrica
                           .Include(m => m.Usuario)
                           .Where(m => m.IdMetrica == id)
                           .ToList();
        }
    }
}
