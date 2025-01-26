using System.Net;

namespace ProdutoCliente.Exceptions.ExcessõesBase
{
    public class NaoLocalizadoExcessao : ClienteProdutoHubExcessao
    {
        public NaoLocalizadoExcessao(string erroMensg) : base(erroMensg)
        {


        }

        public override List<string> GetErrors() => [Message];
       

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
        
    }
}
