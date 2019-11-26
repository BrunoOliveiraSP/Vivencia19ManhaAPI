using System;

namespace Vivencia19ManhaAPI.Business
{
    public class CursoBusiness
    {
        Database.CursoDatabase db = new Database.CursoDatabase();
        public void Remover(int id)
        {
            if(id == 0) { 
                throw new ArgumentException("ID Invalído");
            }
            db.Remover(id);
        }
        public List<Models.TbCurso> Consultar()
        {
            return db.Consultar();
        }
        public List<Models.TbCurso> ConsultarPorID (int id)
        {
            return db.ConsultarPorID(id);
        }
        
    }
}