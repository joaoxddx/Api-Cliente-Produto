using ProdutoCliente.API.Infraestrutura;
using ProdutoCliente.Communication.Requisição;
using ProdutoCliente.Communication.Respostas;
using ProdutoCliente.API.Entidades;
using ProdutoCliente.Exceptions.ExcessõesBase;
using ProdutoCliente.API.UseCases.Clientes.ValidacaoCliente;
using FluentValidation;

namespace ProdutoCliente.API.UseCases.Clientes.Registrar
{
    public class RegistrarClientesUseCases
    {
        public RespostaShortClienteJson Executar(RequisicaoClienteJson requisicao)
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

            return new RespostaShortClienteJson 
            {
                Nome = entity.Nome,
                Id = entity.Id
            };
        }
        private void Validador(RequisicaoClienteJson requisicao)
        {
            var validador = new RequisicaoValidacao();

            var result = validador.Validate(requisicao);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErroValidacaoInternal(errors);
            }
        }

    }
}
