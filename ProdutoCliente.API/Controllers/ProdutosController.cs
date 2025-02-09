using Microsoft.AspNetCore.Mvc;
using ProdutoCliente.API.UseCases.Produtos.Deletar;
using ProdutoCliente.API.UseCases.Produtos.Registrar;
using ProdutoCliente.Communication.Requisição;
using ProdutoCliente.Communication.Respostas;
using ProdutoCliente.Exceptions.ExcessõesBase;

namespace ProdutoCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        [Route("{ClienteId}")]
        [ProducesResponseType(typeof(RespostaShortClienteJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErroMensagensJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(NaoLocalizadoExcessao), StatusCodes.Status404NotFound)]
        public IActionResult Registrar([FromBody] RequisicaoProdutoJson requisicao, [FromRoute] Guid ClienteId)
        {

            var useCase = new RegistrarProdutoUseCase();
            var response = useCase.Executar(ClienteId, requisicao);
            return Created(string.Empty, response);


        }

        [HttpDelete]
        [Route("{produtoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErroMensagensJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute]Guid produtoId)
        {
            var useCase = new DeletarProdutoUseCase();
            useCase.Executar(produtoId);
            return NoContent();

        }
    }
}
