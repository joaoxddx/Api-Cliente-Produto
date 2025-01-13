namespace ProdutoCliente.Communication.Respostas
{
    public class ResponseErroMensagensJson
    {
        public List<string> Erro { get; private set; }


        public ResponseErroMensagensJson(string mensagem)
        {
            Erro = [mensagem];
        }
        public ResponseErroMensagensJson(List<string> mensagens)
        {
            Erro = mensagens;
        }

    }
}
