using Microsoft.AspNetCore.Mvc;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Servico.Despesas;

namespace MoneyWise.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        private readonly ServicoDespesa _repositorio;
        public DespesasController(ServicoDespesa repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_repositorio.ObterTodos().ToList());
            }
            catch (Exception erro)
            {
                return NotFound($"Erro ao obter as despesas. {erro}");
            }
        }

        [HttpGet]
        public IActionResult ObterPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                return Ok(_repositorio.ObterDespesasPorPeriodo(dataInicial, dataFinal));
            }
            catch (Exception erro)
            {
                return NotFound($"Erro ao obter as despesas. {erro}");
            }
        }

        [HttpGet]
        public IActionResult ObterPorValor(decimal valor)
        {
            try
            {
                return Ok(_repositorio.ObterDespesasPorValor(valor));
            }
            catch (Exception erro)
            {
                return NotFound($"Erro ao obter as despesas. {erro}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            try
            {
                return Ok(_repositorio.ObterPorId(id));
            }
            catch (Exception erro)
            {
                return NotFound($"Erro ao obter despesa por id {id}. {erro}");
            }
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Despesa despesa)
        {
            try
            {
                if (despesa == null) return BadRequest();

                _repositorio.Adicionar(despesa);

                return Created($"despesas/{despesa.Id}", despesa);
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao criar despesa :: {erro.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] Despesa despesa)
        {
            try
            {
                if (despesa == null) return BadRequest();

                _repositorio.Atualizar(despesa);

                return NoContent();
            }
            catch (Exception erro)
            {
                return NotFound($"Erro ao atualizar despesa. {erro}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(Despesa despesa)
        {
            try
            {
                if (despesa == null) return BadRequest();

                _repositorio.Remover(despesa);

                return NoContent();
            }
            catch (Exception erro)
            {
                return NotFound($"Erro ao deletar despesa. {erro}");
            }
        }
    }
}
