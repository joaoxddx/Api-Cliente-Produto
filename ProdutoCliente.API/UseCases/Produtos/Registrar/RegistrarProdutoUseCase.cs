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
            try
    {
                var ContextoDb = new ProdutoClienteContextoDb();
                Validador(ContextoDb, clienteId, requisicao);
                var entity = new Produto
                {
                    Id = Guid.NewGuid(),
                    Nome = requisicao.Nome,
                    Marca = requisicao.Marca,
                    Preco = requisicao.Preco,
                    Clienteid = clienteId
                };
                ContextoDb.Produtos.Add(entity);
                ContextoDb.SaveChanges();
                return new RespostaShortProdutoJson
                {
                    Id = entity.Id,
                    Nome = entity.Nome
                };
            }
    catch (Exception ex)
    {
                //Log de excessão caso dê erro na injeção de produto
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
        private void Validador(ProdutoClienteContextoDb dbContexto, Guid clienteId, RequisicaoProdutoJson requisicao)
        {
            var clienteExiste = dbContexto.Clientes.Any(Cliente => Cliente.Id == clienteId);
            if (clienteExiste == false)
            {
                throw new NaoLocalizadoExcessao("Cliente não localizado");
            }

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

