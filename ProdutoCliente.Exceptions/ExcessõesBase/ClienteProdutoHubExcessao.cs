using System.Net;

namespace ProdutoCliente.Exceptions.ExcessõesBase
{
    public abstract class ClienteProdutoHubExcessao : System.Exception
    {
        public ClienteProdutoHubExcessao(string erroMensg) : base(erroMensg)
        {

        }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
