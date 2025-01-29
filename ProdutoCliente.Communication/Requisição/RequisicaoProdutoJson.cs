namespace ProdutoCliente.Communication.Requisição
{
    public class RequisicaoProdutoJson
    {
        public string Nome { get; set; } = string.Empty; // inicio da propriedade em string vazia, para não dar excessão    
        public string Marca { get; set; } = string.Empty;
        public decimal Preco { get; set; } = 0;
    }
}
