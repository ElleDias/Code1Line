using Code1Line.Domains;
using Code1Line.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Code1Line.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessosController : ControllerBase
    {
        private readonly IAcessoRepository _acessoRepository;

        public AcessosController(IAcessoRepository acessoRepository)
        {
            _acessoRepository = acessoRepository;
        }

        // GET: api/Acessos
        [HttpGet]
        public IActionResult Listar()
        {
            var acessos = _acessoRepository.Listar();
            return Ok(acessos);
        }

        // GET: api/Acessos/usuario/{id}
        [HttpGet("usuario/{id}")]
        public IActionResult ListarPorUsuario(Guid id)
        {
            var acessos = _acessoRepository.ListarPorId(id);
            if (acessos == null || acessos.Count == 0)
                return NotFound("Nenhum acesso encontrado para esse usuário.");

            return Ok(acessos);
        }

        // GET: api/Acessos/{id}
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            var acesso = _acessoRepository.BuscarPorId(id);
            if (acesso == null)
                return NotFound("Acesso não encontrado.");

            return Ok(acesso);
        }

        // POST: api/Acessos
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Acessos novoAcesso)
        {
            if (novoAcesso == null)
                return BadRequest("Dados do acesso inválidos.");

            _acessoRepository.Cadastrar(novoAcesso);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoAcesso.IdAcessos }, novoAcesso);
        }

        // PUT: api/Acessos/{id}
        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] Acessos acessoAtualizado)
        {
            var acessoExistente = _acessoRepository.BuscarPorId(id);
            if (acessoExistente == null)
                return NotFound("Acesso não encontrado.");

            _acessoRepository.Atualizar(id, acessoAtualizado);
            return NoContent();
        }

        // DELETE: api/Acessos/{id}
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            var acessoExistente = _acessoRepository.BuscarPorId(id);
            if (acessoExistente == null)
                return NotFound("Acesso não encontrado.");

            _acessoRepository.Deletar(id);
            return NoContent();
        }
    }
}
