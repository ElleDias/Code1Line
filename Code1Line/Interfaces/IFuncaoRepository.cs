using Code1Line.Domains;

namespace Code1Line.Interface
{
    public interface IFuncaoRepository
    {
        void Cadastrar(Funcao novaFuncao);
        List<Funcao> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Funcao funcao);
        List<Funcao> ListarPorId(Guid id);
        Funcao BuscarPorId(Guid id);
    }
}
