using Microsoft.AspNetCore.Mvc;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Servico.Usuarios;

namespace MoneyWise.Web.Controladores
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ServicoUsuario _repositorio;
        public UsuariosController(ServicoUsuario repositorio)
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
                return NotFound($"Erro ao obter usuários. {erro}");
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
                return NotFound($"Erro ao obter usuário com ID {id}. {erro}");
            }
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null) return BadRequest();

                _repositorio.Adicionar(usuario);

                return Created($"usuarios/{usuario.Id}", usuario);
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao criar usuário :: {erro.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null) return BadRequest();

                _repositorio.Atualizar(usuario);

                return NoContent();
            }
            catch (Exception erro)
            {
                return NotFound($"Erro ao atualizar usuário. {erro}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(Usuario usuario)
        {
            try
            {
                if (usuario == null) return BadRequest();

                _repositorio.Remover(usuario);

                return NoContent();
            }
            catch (Exception erro)
            {
                return NotFound($"Erro ao deletar usuário. {erro}");
            }
        }
    }
}
