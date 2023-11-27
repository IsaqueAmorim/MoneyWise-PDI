using Microsoft.AspNetCore.Mvc;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Servico.Despesas;

namespace MoneyWise.Web.Controladores
{
    [Route("api/v1/[controller]")]
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

        [HttpGet("periodo")]
        public IActionResult ObterPorPeriodo([FromQuery] DateTime dataInicial,[FromQuery] DateTime dataFinal)
        {
            try
            {
                if (dataInicial == DateTime.MinValue || dataFinal == DateTime.MaxValue) 
                    return BadRequest();

                return Ok(_repositorio.ObterDespesasPorPeriodo(dataInicial, dataFinal));
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
                if (id == Guid.Empty) 
                    return BadRequest();

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
                if (despesa == null) 
                    return BadRequest();

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
                if (despesa == null) 
                    return BadRequest();

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
                if (despesa == null) 
                    return BadRequest();

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
