using System.Linq;
using System.Linq.Expressions;

namespace Vivencia19ManhaAPI.Business
{
    public class ProfessorBusiness
    {
        Database.ProfessorDatabase db = new Database.ProfessorDatabase();
        public void Inserir(Models.TbProfessor professor)
        {
            db.Inserir(professor);
        }
    }
}