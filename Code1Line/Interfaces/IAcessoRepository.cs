namespace Code1Line.Interface
{
    public interface IAcessoRepository
    {
            void Cadastrar(Acesso novoAcesso);
            List<Acesso> Listar();
            void Deletar(Guid id);
            void Atualizar(Guid id, Acesso acesso);
            List<Evento> ListarPorId(Guid id);
            Evento BuscarPorId(Guid id);
        }
    }


