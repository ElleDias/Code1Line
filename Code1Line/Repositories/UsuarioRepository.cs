using Code1Line.Domains;
using Code1Line.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            var usuarioExistente = _context.Usuario.Find(id);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
                usuarioExistente.Senha = usuario.Senha;
                usuarioExistente.Cargo = usuario.Cargo;
                usuarioExistente.Status = usuario.Status;
                _context.SaveChanges();
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuario.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var usuario = _context.Usuario.Find(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();
            }
        }

        public List<Usuario> Listar()
        {
            return _context.Usuario.ToList();
        }

        public List<Usuario> ListarPorId(Guid id)
        {
            return _context.Usuario
                           .Where(u => u.IdUsuario == id)
                           .ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuario
                           .FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
