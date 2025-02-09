using FluentValidation;
using ProdutoCliente.Communication.Requisição;
namespace ProdutoCliente.API.UseCases.Produtos.ValidacaoProduto
{
    
    
        public class RequisicaoProdutoValidacao : AbstractValidator<RequisicaoProdutoJson>
        {
            public RequisicaoProdutoValidacao()
            {
                RuleFor(Produto => Produto.Nome).NotEmpty().WithMessage("O nome do Produto não pode ser vazio");

                RuleFor(Produto => Produto.Marca).NotEmpty().WithMessage("A marca não pode ser em branco");

                RuleFor(Produto => Produto.Preco).GreaterThan(0).NotEmpty().WithMessage("O preço tem que ser maior que zero");
            }
        }
    
}
