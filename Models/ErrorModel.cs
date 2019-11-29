namespace Vivencia19ManhaAPI.Models
{
    public class ErrorModel
    {
        public int CodigoErro{get;set;}
        public string Mensagem{get;set;}

        public ErrorModel(int codigo,string mensagem)
        {
            CodigoErro = codigo;
            Mensagem = mensagem;
        }
    }
}