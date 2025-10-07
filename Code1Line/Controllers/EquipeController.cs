using Microsoft.AspNetCore.Mvc;
using Code1Line.Domains;
using Code1Line.Interfaces;

namespace Code1Line.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeRepository _equipeRepository;

        public EquipeController(IEquipeRepository equipeRepository)
        {
            _equipeRepository = equipeRepository;
        }

        // GET: api/Equipe
        [HttpGet]
        public IActionResult Listar()
        {
            var equipes = _equipeRepository.Listar();
            return Ok(equipes);
        }

        // GET: api/Equipe/{id}
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            var equipe = _equipeRepository.BuscarPorId(id);
            if (equipe == null)
                return NotFound(new { mensagem = "Equipe não encontrada." });
            return Ok(equipe);
        }

        // POST: api/Equipe
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Equipe novaEquipe)
        {
            if (novaEquipe == null)
                return BadRequest(new { mensagem = "Dados inválidos." });

            _equipeRepository.Cadastrar(novaEquipe);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaEquipe.IdEquipe }, novaEquipe);
        }

        // PUT: api/Equipe/{id}
        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] Equipe equipeAtualizada)
        {
            var equipeExistente = _equipeRepository.BuscarPorId(id);
            if (equipeExistente == null)
                return NotFound(new { mensagem = "Equipe não encontrada." });

            _equipeRepository.Atualizar(id, equipeAtualizada);
            return NoContent();
        }

        // DELETE: api/Equipe/{id}
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            var equipeExistente = _equipeRepository.BuscarPorId(id);
            if (equipeExistente == null)
                return NotFound(new { mensagem = "Equipe não encontrada." });

            _equipeRepository.Deletar(id);
            return NoContent();
        }
    }
}
