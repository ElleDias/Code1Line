using Code1Line.Domains;
using System;
using System.Collections.Generic;

namespace Code1Line.Interfaces
{
    public interface IAtividadeRepository
    {
        void Cadastrar(Atividade novaAtividade);
        List<Atividade> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Atividade atividade);
        List<Atividade> ListarPorId(Guid id);
        Atividade BuscarPorId(Guid id);
    }
}

