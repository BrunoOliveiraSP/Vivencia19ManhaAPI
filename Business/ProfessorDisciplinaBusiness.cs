using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Vivencia19ManhaAPI.Models;

namespace Vivencia19ManhaAPI.Business
{
    public class ProfessorDisciplinaBusiness
    {
        Database.ProfessorDisciplinaDatabase db = new Database.ProfessorDisciplinaDatabase();
            public void Inserir(Models.TbProfessorDisciplina profdisc)
            {
                db.Inserir(profdisc);
            }

            public void Remover(int Id)
            {
                db.Remover(Id);
            }
            public void Alterar(Models.TbProfessorDisciplina profdisc)
            {
                db.Alterar(profdisc);
            
            }

            public List<Models.TbProfessorDisciplina> ListarTodos()
            {
                return db.ListarTodos();;
            }

            // public List<Models.TbProfessorDisciplina> ListarPorIdProfessor(int id)
            // {
            //     List<Models.TbProfessorDisciplina> lista = db.ListarPorIdProfessor(id);
            //     return lista;
            // }

    }
}