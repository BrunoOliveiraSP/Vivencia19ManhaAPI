namespace Vivencia19ManhaAPI.Business
{
    public class DiciplinaBusiness
    {
        Models.Vivencia19ManhaAPI db = new Models.Vivencia19ManhaAPI();
        public void Deletar(int id)
        {
            if (id == 0)
                throw new exception("Id inválido");

                Deletar.Remover(id);
        }  
    }
}