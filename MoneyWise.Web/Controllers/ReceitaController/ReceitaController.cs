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

        [HttpGet("parametros")]
        public IActionResult ObterPorPeriodo([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
        {
            try
            {
                var receitas = _receitaRepositorio.ObterTodos().Where(x => x.DataTrasacao >= dataInicial
                                                                           && x.DataTrasacao <= dataFinal).ToList();
                return Ok(receitas);
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
                return Ok(_receitaRepositorio.ObterPorId(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarReceita(Receita receita)
        {
            try
            {
                return Ok(_receitaRepositorio.Atualizar(receita));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverReceita(Receita receita)
        {
            try
            {
                _receitaRepositorio.Remover(receita);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
