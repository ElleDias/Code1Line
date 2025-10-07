using Microsoft.AspNetCore.Mvc;
using Code1Line.Domains;
using Code1Line.Interfaces;

namespace Code1Line.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeRepository _atividadeRepository;

        public AtividadeController(IAtividadeRepository atividadeRepository)
        {
            _atividadeRepository = atividadeRepository;
        }

        // ✅ GET: api/atividade
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var lista = _atividadeRepository.Listar();
                return Ok(lista);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        // ✅ GET: api/atividade/{id}
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                var atividade = _atividadeRepository.BuscarPorId(id);

                if (atividade == null)
                    return NotFound("Atividade não encontrada.");

                return Ok(atividade);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        // ✅ POST: api/atividade
        [HttpPost]
        public IActionResult Cadastrar(Atividade novaAtividade)
        {
            try
            {
                if (string.IsNullOrEmpty(novaAtividade.Descricao))
                    return BadRequest("A descrição é obrigatória.");

                _atividadeRepository.Cadastrar(novaAtividade);
                return StatusCode(201, "Atividade cadastrada com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        // ✅ PUT: api/atividade/{id}
        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, Atividade atividadeAtualizada)
        {
            try
            {
                var atividadeBuscada = _atividadeRepository.BuscarPorId(id);

                if (atividadeBuscada == null)
                    return NotFound("Atividade não encontrada.");

                _atividadeRepository.Atualizar(id, atividadeAtualizada);
                return Ok("Atividade atualizada com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        // ✅ DELETE: api/atividade/{id}
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                var atividadeBuscada = _atividadeRepository.BuscarPorId(id);

                if (atividadeBuscada == null)
                    return NotFound("Atividade não encontrada.");

                _atividadeRepository.Deletar(id);
                return Ok("Atividade excluída com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
