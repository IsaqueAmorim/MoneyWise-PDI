using Microsoft.AspNetCore.Mvc;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Servico.Autenticacao;

namespace MoneyWise.Web.Controllers.Usuarios
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly ServicoAutenticacao _servicoAutenticacao;

        public AutenticacaoController(ServicoAutenticacao servicoAutenticacao)
        {
            _servicoAutenticacao = servicoAutenticacao;
        }

        [HttpPost]
        public IActionResult Autenticar([FromBody] Usuario usuario)
        {
            try
            {
                var token = _servicoAutenticacao.Autenticar(usuario);

                return Ok(token);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
