namespace ProdutoCliente.API.Entidades
{
    public class Cliente : EntidadeBase
    {
        
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set;} = string.Empty;
    }
}
