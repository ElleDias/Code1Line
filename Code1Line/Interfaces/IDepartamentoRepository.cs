namespace Code1Line.Interface
{
    public interface IDepartamentoRepository
    {
        void Cadastrar(Departamento novoDepartamento);
        List<Departamento> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Departamento departamento);
        List<Departamento> ListarPorId(Guid id);
        Departamento BuscarPorId(Guid id);
    }
}
