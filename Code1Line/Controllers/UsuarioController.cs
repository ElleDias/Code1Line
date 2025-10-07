using Microsoft.AspNetCore.Mvc;
using Code1Line.Domains;
using Code1Line.Interfaces;
using System;
using System.Collections.Generic;

namespace Code1Line.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/Usuario
        [HttpGet]
        public ActionResult<List<Usuario>> Listar()
        {
            return _usuarioRepository.Listar();
        }

        // GET: api/Usuario/{id}
        [HttpGet("{id}")]
        public ActionResult<Usuario> BuscarPorId(Guid id)
        {
            var usuario = _usuarioRepository.BuscarPorId(id);
            if (usuario == null)
                return NotFound(new { mensagem = "Usuário não encontrado." });

            return usuario;
        }

        // POST: api/Usuario
        [HttpPost]
        public ActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return CreatedAtAction(nameof(BuscarPorId), new { id = usuario.IdUsuario }, usuario);
        }

        // PUT: api/Usuario/{id}
        [HttpPut("{id}")]
        public ActionResult Atualizar(Guid id, [FromBody] Usuario usuario)
        {
            var usuarioExistente = _usuarioRepository.BuscarPorId(id);
            if (usuarioExistente == null)
                return NotFound(new { mensagem = "Usuário não encontrado." });

            _usuarioRepository.Atualizar(id, usuario);
            return NoContent();
        }

        // DELETE: api/Usuario/{id}
        [HttpDelete("{id}")]
        public ActionResult Deletar(Guid id)
        {
            var usuarioExistente = _usuarioRepository.BuscarPorId(id);
            if (usuarioExistente == null)
                return NotFound(new { mensagem = "Usuário não encontrado." });

            _usuarioRepository.Deletar(id);
            return NoContent();
        }

        // POST: api/Usuario/Login
        [HttpPost("Login")]
        public ActionResult<Usuario> Login([FromBody] Usuario usuario)
        {
            var usuarioLogin = _usuarioRepository.Login(usuario.Email, usuario.Senha);
            if (usuarioLogin == null)
                return Unauthorized(new { mensagem = "Email ou senha inválidos." });

            return usuarioLogin;
        }
    }
}
