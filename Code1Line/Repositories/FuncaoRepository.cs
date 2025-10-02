using System;
using System.Collections.Generic;
using System.Linq;
using Code1Line.Domains;
using Code1Line.Interfaces;

namespace Code1Line.Repositories
{
    public class FuncaoRepository : IFuncaoRepository
    {
        // Lista simulando banco de dados
        private readonly List<Funcao> funcoes = new List<Funcao>();

        // Cadastrar nova função
        public void Cadastrar(Funcao funcao)
        {
            funcao.IdFuncao = Guid.NewGuid(); // gera id único
            funcoes.Add(funcao);
        }

        // Atualizar função existente
        public void Atualizar(Guid id, Funcao funcaoAtualizada)
        {
            var funcao = funcoes.FirstOrDefault(f => f.IdFuncao == id);
            if (funcao != null)
            {
                funcao.Nome = funcaoAtualizada.Nome;
                funcao.Descricao = funcaoAtualizada.Descricao;
            }
        }

        // Deletar função por id
        public void Deletar(Guid id)
        {
            var funcao = funcoes.FirstOrDefault(f => f.IdFuncao == id);
            if (funcao != null)
                funcoes.Remove(funcao);
        }

        // Listar todas as funções
        public List<Funcao> Listar()
        {
            return funcoes;
        }

        // Buscar função pelo Id
        public Funcao ListarPorId(Guid id)
        {
            return funcoes.FirstOrDefault(f => f.IdFuncao == id);
        }

        // Se quiser manter BuscarPorId também
        public Funcao BuscarPorId(Guid id)
        {
            return ListarPorId(id);
        }
    }
}
