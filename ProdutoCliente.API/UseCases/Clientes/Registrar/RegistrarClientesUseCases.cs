using ProdutoCliente.Communication.Requisição;
using ProdutoCliente.Communication.Respostas;

namespace ProdutoCliente.API.UseCases.Clientes.Registrar
{
    public class RegistrarClientesUseCases
    {
        public RespostaClienteJson Executar(RequisicaoClienteJson requisicao)
        {  

            var validador = new RegistrarClientesValidador();

            var result = validador.Validate(requisicao);
            return new RespostaClienteJson();
        }
    }
}
