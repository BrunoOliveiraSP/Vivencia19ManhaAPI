using System.Linq;
using System.Linq.Expressions;
using Vivencia19ManhaAPI.Models;

namespace Vivencia19ManhaAPI.Business
{   
    public class ProfessorBusiness
    {
        Database.ProfessorDatabase db = new Database.ProfessorDatabase();

        public void Inserir(Models.TbProfessor professor)
        {
            db.Inserir(professor);
        }
       
        public void Remover(int ID )
        {
        }

        public void Alterar(Models.TbProfessor professor)
        {
            db.Alterar(professor);
        }

       
    }
}