using ProdutoCliente.API.Infraestrutura;
using ProdutoCliente.Communication.Respostas;

namespace ProdutoCliente.API.UseCases.Clientes.GetAll
{
    public class GetAllClientUseCase
    {
        public RespostaTodosClientesJson Executar()
        {
            var dbContext = new ProdutoClienteContextoDb();

            var clientes = dbContext.Clientes.ToList();

            var listaClientes = clientes.Select(cliente => new RespostaShortClienteJson
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
       
            }).ToList();

            return new RespostaTodosClientesJson
            {
                Clientes = listaClientes
            };
        }
    }
}
