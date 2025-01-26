using Microsoft.AspNetCore.Mvc;
using ProdutoCliente.API.UseCases.Clientes.Atualizar;
using ProdutoCliente.API.UseCases.Clientes.GetAll;
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
        [ProducesResponseType(typeof(RespostaShortClienteJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErroMensagensJson), StatusCodes.Status400BadRequest)]
        public IActionResult Registrar([FromBody]RequisicaoClienteJson requisicao) 
        {
            var useCase = new RegistrarClientesUseCases(); 

            var response = useCase.Executar(requisicao);

            return Created(string.Empty, response);
        
        }
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErroMensagensJson), StatusCodes.Status404NotFound)]
        public IActionResult Atualizar([FromRoute] Guid id, [FromBody] RequisicaoClienteJson requisicao)
        {
            var UseCase = new AtualizarClienteUseCase();

            UseCase.Executar(id, requisicao);

            return NoContent();

        }

        [HttpGet]
        [ProducesResponseType(typeof(RespostaTodosClientesJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ResgatarTodos()
        {

            var useCase = new GetAllClientUseCase();

            var response = useCase.Executar();

            if (response.Clientes.Count == 0)
            {
                return NoContent();
            }
            return Ok(response);

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
