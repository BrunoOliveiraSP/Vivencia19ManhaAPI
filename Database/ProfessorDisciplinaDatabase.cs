using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using Vivencia19ManhaAPI.Models;

namespace Vivencia19ManhaAPI.Database
{
    

    public class ProfessorDisciplinaDatabase
    {
        
            db_a5064d_freiContext db = new db_a5064d_freiContext();


            public void Inserir(Models.TbProfessorDisciplina profdisc)
            {
                db.TbProfessorDisciplina.Add(profdisc);
                db.SaveChanges();
            }

            public void Remover(int Id)
            {
                Models.TbProfessorDisciplina r = db.TbProfessorDisciplina.FirstOrDefault(x =>x.IdProfessorDisciplina == Id);
                db.TbProfessorDisciplina.Remove(r);
                db.SaveChanges();
            }
            public void Alterar(Models.TbProfessorDisciplina profdisc)
            {
               // db.TbProfessorDisciplina.Add(profdisc);
              //  db.SaveChanges();
            }

            public List<Models.TbProfessorDisciplina> ListarTodos()
            {
                List<Models.TbProfessorDisciplina> lista = db.TbProfessorDisciplina.ToList();
                return lista;
            }



    }
}