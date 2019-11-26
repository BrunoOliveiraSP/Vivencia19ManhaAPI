using Vivencia19ManhaAPI.Models;
using System.Linq;
using System.Linq.Expressions;

namespace Vivencia19ManhaAPI.Database
{
    public class ProfessorDatabase
    {
        Models.db_a5064d_freiContext db = new Models.db_a5064d_freiContext();

        public void Inserir(Models.TbProfessor professor)
        {
            db.TbProfessor.Add(professor);
            db.SaveChanges();
        }
    }
}