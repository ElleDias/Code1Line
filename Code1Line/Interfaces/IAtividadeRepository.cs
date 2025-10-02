using Code1Line.Domains;

namespace Code1Line.Interfaces
{
    public interface IAtividadeRepository
    {
        void Cadastrar(Atividades novaAtividade);
        List<Atividades> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Atividades atividade);
        List<Atividades> ListarPorId(Guid id);
        Atividades BuscarPorId(Guid id);
    }
}