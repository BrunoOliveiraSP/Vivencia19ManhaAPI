using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        public void Remover(int id)
        {
            Models.TbCurso remover = db.TbCurso.FirstOrDefault(x => x.IdCurso == id);
            db.TbCurso.Remove(remover);
            db.SaveChanges();
        }
    }
}