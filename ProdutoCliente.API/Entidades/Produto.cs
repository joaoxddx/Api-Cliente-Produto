namespace ProdutoCliente.API.Entidades
{
    public class Produto : EntidadeBase
    {
        

        public string Nome { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public Guid Clienteid { get; set; }


    }
}
