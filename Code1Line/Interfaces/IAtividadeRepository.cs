using Code1Line.Domains;

namespace Code1Line.Interface
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