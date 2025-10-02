using Code1Line.Domains;

namespace Code1Line.Interfaces
{
    public interface IOutlierRepository
    {
        void Cadastrar(Outlier novoOutlier);
        List<Outlier> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Outlier outlier);
        List<Outlier> ListarPorId(Guid id);
        Outlier BuscarPorId(Guid id);
    }
}
