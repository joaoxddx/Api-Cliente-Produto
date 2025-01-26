using ProdutoCliente.API.Infraestrutura;
using ProdutoCliente.API.UseCases.Clientes.Validacao;
using ProdutoCliente.Communication.Requisição;
using ProdutoCliente.Exceptions.ExcessõesBase;

namespace ProdutoCliente.API.UseCases.Clientes.Atualizar
{
    public class AtualizarClienteUseCase
    {
        public void Executar(Guid clienteId, RequisicaoClienteJson requisicao)
        {
            Validate(requisicao);

            var ContextoDB = new ProdutoClienteContextoDb();

            var entity = ContextoDB.Clientes.FirstOrDefault(cliente => cliente.Id == clienteId);

            if (entity == null)
            {
                throw new NaoLocalizadoExcessao("Cliente não encontrado");
            }
            entity.Nome =  requisicao.Nome;
            entity.Email = requisicao.Email;

            ContextoDB.Update(entity);
            ContextoDB.SaveChanges();
        }

        private void Validate(RequisicaoClienteJson requisicao)
        {
            var validador = new RequisicaoValidacao();

            var result = validador.Validate(requisicao);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErroValidacaoInternal(errors);
            }
        }
    }
}
