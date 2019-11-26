using System.Linq;
using System.Linq.Expressions;
namespace Vivencia19ManhaAPI.Database
{
    public class diciplinaDatabase
    {
        public void InserirDisciplina(Models.TbDisciplina disciplina)
        {
            Models.
            db.TbDisciplina.Add(disciplina);
            db.SaveChanges();
        }
    }
}