using ProdutoCliente.API.Infraestrutura;
using ProdutoCliente.Exceptions.ExcessõesBase;

namespace ProdutoCliente.API.UseCases.Produtos.Deletar
{
    public class DeletarProdutoUseCase
    {
        public void Executar(Guid produtoId)
        {
            var Contextodb = new ProdutoClienteContextoDb();

            var entidade = Contextodb.Produtos.FirstOrDefault(produto => produto.Id == produtoId);
            if (entidade is null)
            {
                throw new NaoLocalizadoExcessao("Produto não encontrado");
            }
            Contextodb.Produtos.Remove(entidade);
            Contextodb.SaveChanges();
        }
    }
}
