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

            if(result.IsValid== false)
            {
                throw new ArgumentException("Erro nos dados recebidos");    
            }
            return new RespostaClienteJson();
        }
    }
}
