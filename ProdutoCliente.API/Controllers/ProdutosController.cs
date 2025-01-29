using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutoCliente.API.UseCases.Produtos.Registrar;
using ProdutoCliente.Communication.Requisição;
using ProdutoCliente.Communication.Respostas;

namespace ProdutoCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RespostaShortProdutoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErroMensagensJson), StatusCodes.Status400BadRequest)]
        public IActionResult Registrar([FromRoute] Guid id, [FromBody] RequisicaoClienteJson requisicao)
        {

            var useCase = new RegistrarProdutoUseCase(id, requisicao);

            var response = useCase.Executar();
            return Ok();
        }
    }
}
