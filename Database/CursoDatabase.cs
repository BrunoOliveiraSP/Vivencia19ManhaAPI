namespace Vivencia19ManhaAPI.Database
{
    public class CursoDatabase
    {
        Models.db_a5064d_freiContext db = new Models.db_a5064d_freiContext();

        public void InserirCurso(Models.TbCurso curso)
        {
            db.TbCurso.Add(curso);

            db.SaveChanges();
        }
        
    }
}