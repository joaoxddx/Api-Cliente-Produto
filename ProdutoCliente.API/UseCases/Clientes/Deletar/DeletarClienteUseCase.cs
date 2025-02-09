using ProdutoCliente.API.Infraestrutura;
using ProdutoCliente.Exceptions.ExcessõesBase;

namespace ProdutoCliente.API.UseCases.Clientes.Deletar
{
    public class DeletarClienteUseCase
    {
        public void Executar(Guid clienteId)
        {
            var Contextodb = new ProdutoClienteContextoDb();
            var entidade = Contextodb.Clientes.FirstOrDefault(cliente => cliente.Id == clienteId);
            if (entidade is null)
            {
                throw new NaoLocalizadoExcessao("Cliente não encontrado");
            }
            
            Contextodb.Clientes.Remove(entidade);

            Contextodb.SaveChanges();
        }
    }
}
