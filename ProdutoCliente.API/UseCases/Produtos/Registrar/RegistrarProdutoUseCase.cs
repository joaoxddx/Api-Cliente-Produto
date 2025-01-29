using ProdutoCliente.API.Entidades;
using ProdutoCliente.API.Infraestrutura;
using ProdutoCliente.Communication.Requisição;
using ProdutoCliente.Communication.Respostas;
using ProdutoCliente.Exceptions.ExcessõesBase;
using ProdutoCliente.API.UseCases.Produtos.ValidacaoProduto;
namespace ProdutoCliente.API.UseCases.Produtos.Registrar
{
    public class RegistrarProdutoUseCase
    {
        public RespostaShortProdutoJson Executar(Guid clienteId, RequisicaoProdutoJson requisicao)

        {
            Validador(requisicao);
            var ContextoDb = new ProdutoClienteContextoDb();
            var entity = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = requisicao.Nome,
                Marca = requisicao.Marca,
                Preco = requisicao.Preco,
               
            };
            ContextoDb.Produtos.Add(entity);
            ContextoDb.SaveChanges();
            return new RespostaShortProdutoJson
            {
                Id = entity.Id,
                Nome = entity.Nome
            };
        }
        private void Validador(RequisicaoProdutoJson requisicao)
        {
            var validador = new RequisicaoProdutoValidacao();

            var result = validador.Validate(requisicao);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErroValidacaoInternal(errors);
            }
        }

    }
}

