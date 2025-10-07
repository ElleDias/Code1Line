using Code1Line.Domains;
using Code1Line.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Code1Line.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoramentoController : ControllerBase
    {
        private readonly IMonitoramentoRepository _monitoramentoRepository;

        public MonitoramentoController(IMonitoramentoRepository monitoramentoRepository)
        {
            _monitoramentoRepository = monitoramentoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_monitoramentoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            var monitoramento = _monitoramentoRepository.BuscarPorId(id);
            if (monitoramento == null)
                return NotFound();

            return Ok(monitoramento);
        }

        [HttpGet("usuario/{id}")]
        public IActionResult ListarPorUsuario(Guid id)
        {
            return Ok(_monitoramentoRepository.ListarPorId(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(Monitoramento monitoramento)
        {
            _monitoramentoRepository.Cadastrar(monitoramento);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, Monitoramento monitoramento)
        {
            _monitoramentoRepository.Atualizar(id, monitoramento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            _monitoramentoRepository.Deletar(id);
            return NoContent();
        }
    }
}
