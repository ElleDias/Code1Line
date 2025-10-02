using Code1Line.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Code1Line.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar (Usuario usuario);
        List<Usuario> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Usuario usuario);
        List<Usuario> ListarPorId(Guid id);
        Usuario BuscarPorId(Guid id);
        Usuario Login(string email, string senha);
        
    }
}
