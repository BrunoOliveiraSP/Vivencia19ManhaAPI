using System.Linq;
using System.Linq.Expressions;
namespace Vivencia19ManhaAPI.Database
{
    public class diciplinaDatabase
    {
        public void InserirDisciplina(Models.TbDisciplina disciplina)
        {
            Models.db_a5064d_freiContext db = new Models.db_a5064d_freiContext();
            db.TbDisciplina.Add(disciplina);
            db.SaveChanges();
        }
    }
}