using Code1Line.Domains;

namespace Code1Line.Interface
{
    public interface IMetricaRepository
    {
        void Cadastrar(Metrica novaMetrica);
        List<Metrica> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Metrica metrica);
        List<Metrica> ListarPorId(Guid id);
        Metrica BuscarPorId(Guid id);
    }
}
