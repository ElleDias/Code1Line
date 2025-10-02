using Code1Line.Domains;

namespace Code1Line.Interfaces
{
    public interface IEquipeRepository
    {
        void Cadastrar(Equipe novaEquipe);
        List<Equipe> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Equipe equipe);
        List<Equipe> ListarPorId(Guid id);
        Equipe BuscarPorId(Guid id);
    }
}
