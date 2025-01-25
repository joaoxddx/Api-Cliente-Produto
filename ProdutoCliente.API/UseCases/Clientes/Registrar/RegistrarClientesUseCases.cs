using ProdutoCliente.API.Infraestrutura;
using ProdutoCliente.Communication.Requisição;
using ProdutoCliente.Communication.Respostas;
using ProdutoCliente.API.Entidades;
using ProdutoCliente.Exceptions.ExcessõesBase;

namespace ProdutoCliente.API.UseCases.Clientes.Registrar
{
    public class RegistrarClientesUseCases
    {
        public RespostaClienteJson Executar(RequisicaoClienteJson requisicao)
        {  
            Validador(requisicao);

            var ContextoDb = new ProdutoClienteContextoDb();

            var entity = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = requisicao.Nome,
                Email = requisicao.Email
            };


            ContextoDb.Clientes.Add(entity);
            
            ContextoDb.SaveChanges();

            return new RespostaClienteJson 
            {
                Nome = entity.Nome,
                Id = entity.Id
            };
        }
        private void Validador(RequisicaoClienteJson requisicao)
        {
            var validador = new RegistrarClientesValidador();

            var result = validador.Validate(requisicao);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErroValidacaoInternal(errors);
            }

        }

    }
}
