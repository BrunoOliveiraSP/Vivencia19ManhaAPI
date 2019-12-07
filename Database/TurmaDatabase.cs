using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Vivencia19ManhaAPI.Database
{
    public class TurmaDatabase
    {
       Models.db_a5064d_freiContext db = new Models.db_a5064d_freiContext();

     public void InserirTurma(Models.TbTurma modelo)
        {  
            

            db.TbTurma.Add(modelo);

            

            db.SaveChanges();
     }
        public List<Models.TbTurma> ConsultarTurma()
        {
            List<Models.TbTurma> lista = db.TbTurma.ToList();
            return lista;
        }
         public void AlterarTurma(Models.TbTurma modelo)
        {
             Models.TbTurma alterar = db.TbTurma.FirstOrDefault(x=> x.IdTurma == modelo.IdTurma);

             alterar.IdAnoLetivo = modelo.IdAnoLetivo;
             alterar.NmTurma = modelo.NmTurma;
             alterar.TpPeriodo = modelo.TpPeriodo;
             alterar.IdCurso = modelo.IdCurso;
             alterar.NrCapacidadeMax = modelo.NrCapacidadeMax;

             db.SaveChanges();

        }
        public void RemoverTurma(int id)
        {
           Models.TbTurma turma = db.TbTurma.FirstOrDefault(t => t.IdTurma == id);

           db.TbTurma.Remove(turma);

           db.SaveChanges();
        }
    }
}