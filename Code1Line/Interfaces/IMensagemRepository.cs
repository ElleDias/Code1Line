namespace Code1Line.Interface
{
    public interface IMensagemRepository
    {
        void Cadastrar(Mensagem novaMensagem);
        List<Mensagem> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Mensagem mensagem);
        List<Mensagem> ListarPorId(Guid id);
        Mensagem BuscarPorId(Guid id);

    }
}
