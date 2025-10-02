using Code1Line.Domains;

namespace Code1Line.Interfaces
{
    public interface IAcessoRepository
    {
        void Cadastrar(Acessos novoAcesso);
        List<Acessos> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Acessos acesso);
        List<Acessos> ListarPorId(Guid id);
        Acessos BuscarPorId(Guid id);
    }
}