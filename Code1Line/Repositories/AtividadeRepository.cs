using Code1Line.Domains;
using Code1Line.Interfaces;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            var atividadeExistente = _context.Atividades.Find(id);
            if (atividadeExistente != null)
            {
                atividadeExistente.IdUsuario = atividade.IdUsuario;
                atividadeExistente.fim = atividade.fim;
                atividadeExistente.categoria = atividade.categoria;
                atividadeExistente.Descricao = atividade.Descricao;
                _context.SaveChanges();
            }
        }

        public Atividades BuscarPorId(Guid id)
        {
            return _context.Atividades
                           .Include(a => a.Usuario)
                           .FirstOrDefault(a => a.IdAtividades == id);
        }

        public void Cadastrar(Atividades novaAtividade)
        {
            _context.Atividades.Add(novaAtividade);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var atividade = _context.Atividades.Find(id);
            if (atividade != null)
            {
                _context.Atividades.Remove(atividade);
                _context.SaveChanges();
            }
        }

        public List<Atividades> Listar()
        {
            return _context.Atividades
                           .Include(a => a.Usuario)
                           .ToList();
        }

        public List<Atividades> ListarPorId(Guid id)
        {
            return _context.Atividades
                           .Include(a => a.Usuario)
                           .Where(a => a.IdAtividades == id)
                           .ToList();
        }
    }
}
