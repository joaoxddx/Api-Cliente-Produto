using System.Net;

namespace ProdutoCliente.Exceptions.ExcessõesBase
{
    public class ErroValidacaoInternal : ClienteProdutoHubExcessao
    {

        private readonly List<string> _errors; // readonly -> só pode ser alterado e adicionado o valor dentro do construtor

        public ErroValidacaoInternal(List<string> errorMensg) : base(string.Empty)
        {
            _errors = errorMensg;

        }

        public override List<string> GetErrors()
        {
            return _errors;
        }

        public override HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
