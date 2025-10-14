using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Code1Line.Domain;
using Code1Line.Interfaces;

namespace Code1Line.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MonitoramentoController : ControllerBase
{
    private readonly IMonitoramentoRepository _repo;

    public MonitoramentoController(IMonitoramentoRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    [Authorize(Roles = "Gerente,Gestor") ]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    [Authorize(Roles = "Gerente,Gestor") ]
    public async Task<IActionResult> GetById(int id)
    {
        var m = await _repo.GetByIdAsync(id);
        if (m == null) return NotFound();
        return Ok(m);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] Monitoramento monitoramento)
    {
        await _repo.AddAsync(monitoramento);
        return CreatedAtAction(nameof(GetById), new { id = monitoramento.Id }, monitoramento);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Gerente") ]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}
