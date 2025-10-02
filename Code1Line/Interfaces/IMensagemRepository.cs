using Code1Line.Domains;

namespace Code1Line.Interface
{
    public interface IMensagemRepository
    {
        void Cadastrar(Mensagens novaMensagem);
        List<Mensagens> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Mensagens mensagem);
        List<Mensagens> ListarPorId(Guid id);
        Mensagens BuscarPorId(Guid id);

    }
}
