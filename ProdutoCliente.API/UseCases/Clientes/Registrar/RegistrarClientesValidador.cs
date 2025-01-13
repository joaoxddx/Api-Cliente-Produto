            using FluentValidation;
using ProdutoCliente.Communication.Requisição;

namespace ProdutoCliente.API.UseCases.Clientes.Registrar
{
    public class RegistrarClientesValidador : AbstractValidator<RequisicaoClienteJson>
    {
        public RegistrarClientesValidador()
        {
            RuleFor(cliente => cliente.Nome).NotEmpty().WithMessage("O nome não pode ser Vazio")
                .MinimumLength(3).WithMessage("No mínimo de 3 caracteres");
            RuleFor(cliente => cliente.Email).NotEmpty().WithMessage("O E-mail não pode ser Vazio")
                .MinimumLength(3).WithMessage("No mínimo de 3 caracteres");


        }
    }
}
