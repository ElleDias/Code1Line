using Code1Line.Domains;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code1Line.Interfaces;

namespace Code1Line.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Code1Line_Context _context;

        public UsuarioRepository(Code1Line_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ListarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
