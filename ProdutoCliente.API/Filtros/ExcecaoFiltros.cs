using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProdutoCliente.Communication.Respostas;
using ProdutoCliente.Exceptions.ExcessõesBase;

namespace ProdutoCliente.API.Filtros
{
    public class ExcecaoFiltros : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ClienteProdutoHubExcessao clienteProdutoHubExcessao)
            {
                context.HttpContext.Response.StatusCode = (int)clienteProdutoHubExcessao.GetHttpStatusCode();

                context.Result = new ObjectResult(new ResponseErroMensagensJson(clienteProdutoHubExcessao.GetErrors()));
            }
            else
            {
                ThrowUnknowError(context);
            }
        }
    

        private void ThrowUnknowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult( new ResponseErroMensagensJson("ERRO DESCONHECIDO"));
        }
    

    }
}
