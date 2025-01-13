using ProdutoCliente.Communication.Requisição;
using ProdutoCliente.Communication.Respostas;
using ProdutoCliente.Exceptions.ExcessõesBase;

namespace ProdutoCliente.API.UseCases.Clientes.Registrar
{
    public class RegistrarClientesUseCases
    {
        public RespostaClienteJson Executar(RequisicaoClienteJson requisicao)
        {  

            var validador = new RegistrarClientesValidador();

            var result = validador.Validate(requisicao);

            if(result.IsValid== false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErroValidacaoInternal(errors);    
            }
            return new RespostaClienteJson();
        }
    }
}
