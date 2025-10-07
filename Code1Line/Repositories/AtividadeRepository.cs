using Code1Line.Context;
using Code1Line.Domains;
using Code1Line.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code1Line.Repositories
{
    public class AtividadeRepository : IAtividadeRepository
    {
        private readonly Code1Line_Context _context;

        public AtividadeRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public void Cadastrar(Atividade novaAtividade)
        {
            novaAtividade.IdAtividade = Guid.NewGuid();
            _context.Atividade.Add(novaAtividade);
            _context.SaveChanges();
        }

        public List<Atividade> Listar()
        {
            return _context.Atividade.ToList();
        }

        public Atividade BuscarPorId(Guid id)
        {
            return _context.Atividade.FirstOrDefault(a => a.IdAtividade == id);
        }

        public void Atualizar(Guid id, Atividade atividadeAtualizada)
        {
            var atividade = BuscarPorId(id);
            if (atividade != null)
            {
                atividade.Descricao = atividadeAtualizada.Descricao;
                atividade.Categoria = atividadeAtualizada.Categoria;
                atividade.Fim = atividadeAtualizada.Fim;
                atividade.Inicio = atividadeAtualizada.Inicio;
                atividade.Status = atividadeAtualizada.Status;

                _context.Atividade.Update(atividade);
                _context.SaveChanges();
            }
        }

        public void Deletar(Guid id)
        {
            var atividade = BuscarPorId(id);
            if (atividade != null)
            {
                _context.Atividade.Remove(atividade);
                _context.SaveChanges();
            }
        }
    }
}
