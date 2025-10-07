using Microsoft.AspNetCore.Mvc;
using Code1Line.Domains;
using Code1Line.Interfaces;
using System;
using System.Collections.Generic;

namespace Code1Line.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricaController : ControllerBase
    {
        private readonly IMetricaRepository _metricaRepository;

        public MetricaController(IMetricaRepository metricaRepository)
        {
            _metricaRepository = metricaRepository;
        }

        // GET: api/Metrica
        [HttpGet]
        public ActionResult<List<Metrica>> Listar()
        {
            return _metricaRepository.Listar();
        }

        // GET: api/Metrica/{id}
        [HttpGet("{id}")]
        public ActionResult<Metrica> BuscarPorId(Guid id)
        {
            var metrica = _metricaRepository.BuscarPorId(id);
            if (metrica == null)
                return NotFound(new { mensagem = "Métrica não encontrada." });

            return metrica;
        }

        // GET: api/Metrica/Usuario/{idUsuario}
        [HttpGet("Usuario/{idUsuario}")]
        public ActionResult<List<Metrica>> ListarPorUsuario(Guid idUsuario)
        {
            var metricas = _metricaRepository.ListarPorId(idUsuario);
            if (metricas.Count == 0)
                return NotFound(new { mensagem = "Nenhuma métrica encontrada para este usuário." });

            return metricas;
        }

        // POST: api/Metrica
        [HttpPost]
        public ActionResult Cadastrar([FromBody] Metrica metrica)
        {
            _metricaRepository.Cadastrar(metrica);
            return CreatedAtAction(nameof(BuscarPorId), new { id = metrica.IdMetrica }, metrica);
        }

        // PUT: api/Metrica/{id}
        [HttpPut("{id}")]
        public ActionResult Atualizar(Guid id, [FromBody] Metrica metrica)
        {
            var metricaExistente = _metricaRepository.BuscarPorId(id);
            if (metricaExistente == null)
                return NotFound(new { mensagem = "Métrica não encontrada." });

            _metricaRepository.Atualizar(id, metrica);
            return NoContent();
        }

        // DELETE: api/Metrica/{id}
        [HttpDelete("{id}")]
        public ActionResult Deletar(Guid id)
        {
            var metricaExistente = _metricaRepository.BuscarPorId(id);
            if (metricaExistente == null)
                return NotFound(new { mensagem = "Métrica não encontrada." });

            _metricaRepository.Deletar(id);
            return NoContent();
        }
    }
}
