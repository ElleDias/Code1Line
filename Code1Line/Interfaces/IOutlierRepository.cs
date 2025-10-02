namespace Code1Line.Interface
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
