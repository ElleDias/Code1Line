using Code1Line.Domains;
using Code1Line.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Code1Line.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        // GET: api/Departamento
        [HttpGet]
        public ActionResult<List<Departamento>> Listar()
        {
            var departamentos = _departamentoRepository.Listar();
            return Ok(departamentos);
        }

        // GET: api/Departamento/{id}
        [HttpGet("{id}")]
        public ActionResult<Departamento> BuscarPorId(Guid id)
        {
            var departamento = _departamentoRepository.BuscarPorId(id);
            if (departamento == null)
                return NotFound(new { mensagem = "Departamento não encontrado." });

            return Ok(departamento);
        }

        // POST: api/Departamento
        [HttpPost]
        public ActionResult Cadastrar([FromBody] Departamento novoDepartamento)
        {
            if (novoDepartamento == null)
                return BadRequest(new { mensagem = "Dados inválidos." });

            _departamentoRepository.Cadastrar(novoDepartamento);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoDepartamento.IdDepartamento }, novoDepartamento);
        }

        // PUT: api/Departamento/{id}
        [HttpPut("{id}")]
        public ActionResult Atualizar(Guid id, [FromBody] Departamento departamentoAtualizado)
        {
            var departamentoExistente = _departamentoRepository.BuscarPorId(id);
            if (departamentoExistente == null)
                return NotFound(new { mensagem = "Departamento não encontrado." });

            _departamentoRepository.Atualizar(id, departamentoAtualizado);
            return NoContent();
        }

        // DELETE: api/Departamento/{id}
        [HttpDelete("{id}")]
        public ActionResult Deletar(Guid id)
        {
            var departamentoExistente = _departamentoRepository.BuscarPorId(id);
            if (departamentoExistente == null)
                return NotFound(new { mensagem = "Departamento não encontrado." });

            _departamentoRepository.Deletar(id);
            return NoContent();
        }
    }
}
