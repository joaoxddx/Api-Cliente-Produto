using Microsoft.AspNetCore.Mvc;
using ProdutoCliente.API.UseCases.Clientes.Registrar;
using ProdutoCliente.Communication.Requisição;
using ProdutoCliente.Communication.Respostas;

namespace ProdutoCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {   
        [HttpPost]
        [ProducesResponseType(typeof(RespostaClienteJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErroMensagensJson), StatusCodes.Status400BadRequest)]
        public IActionResult Registrar([FromBody]RequisicaoClienteJson requisicao) 
        {
            try
            {
                var useCase = new RegistrarClientesUseCases();
                var response = useCase.Executar(requisicao);
                return Created(string.Empty, requisicao);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new ResponseErroMensagensJson(ex.Message));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroMensagensJson("ERRO DESCONHECIDO"));
            }
        
        }
        [HttpPut]
        public IActionResult Atualizar()
        {
            return Ok();

        }

        [HttpGet]
        public IActionResult ResgatarTodos()
        {
            return Ok();

        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult ResgatarID([FromRoute]Guid id)
        {
            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();

        }
    }
}
