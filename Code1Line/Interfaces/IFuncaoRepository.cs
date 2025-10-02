using Code1Line.Domains;

public interface IFuncaoRepository
{
    void Cadastrar(Funcao funcao);
    List<Funcao> Listar();
    void Deletar(Guid id);
    void Atualizar(Guid id, Funcao funcao);
    Funcao ListarPorId(Guid id);
    Funcao BuscarPorId(Guid id);
}
