using MoneyWise.Dominio.Repositorios.ReceitaRepositorio;
using MoneyWise.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace MoneyWise.Web.Controllers.ReceitaController
{
    [Route("api/v1/[Controller]")]
    public class ReceitaController : Controller
    {
        private IReceitaRepositorio _receitaRepositorio;

        public ReceitaController(IReceitaRepositorio repositorio)
        {
            _receitaRepositorio = repositorio;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_receitaRepositorio.ObterTodos());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("periodo")]
        public IActionResult ObterPorPeriodo([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
        {
            try
            {
                if(dataInicial == DateTime.MinValue || dataFinal == DateTime.MinValue)
                    return BadRequest();

                return Ok(_receitaRepositorio.ObterReceitasPorPeriodo(dataInicial, dataFinal));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                    return BadRequest();

                return Ok(_receitaRepositorio.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarReceita(Receita receita)
        {
            try
            {
                if(receita == null)
                    return BadRequest();

                return Ok(_receitaRepositorio.Atualizar(receita));
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverReceita(Guid id)
        {
            try
            {
                var receita = _receitaRepositorio.ObterPorId(id);
                
                _receitaRepositorio.Remover(receita);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
