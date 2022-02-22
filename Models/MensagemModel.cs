using Newtonsoft.Json;

namespace ControleDeEstoqueWeb.Models
{
    public enum TipoMensagem
    {
         Informacao,

         Erro
    }

    public class MensagemModel
    {
        public TipoMensagem Tipo {get; set;}

        public string Texto {get; set;}

        public MensagemModel(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao)
        {
            this.Tipo = tipo;
            this.Texto = mensagem;
        }

        public static string Serializar(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao)
        {
            var mensagemModel = new MensagemModel(mensagem, tipo);
            return JsonConvert.SerializeObject(mensagemModel);
        }
        //sugestao da extensao do vscode
        //public static MensagemModel Deserializar(string mensagemString) => JsonConvert.DeserializeObject<MensagemModel>(mensagemString);

        public static MensagemModel Deserializar(string mensagemString)
        {
            return JsonConvert.DeserializeObject<MensagemModel>(mensagemString);
        }
    }
}