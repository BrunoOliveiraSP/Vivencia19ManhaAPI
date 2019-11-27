using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vivencia19ManhaAPI.Models;
using System.Linq;
using Vivencia19ManhaAPI.Database;

namespace Vivencia19ManhaAPI.Business
{
    public class CursoDisciplinaBusiness
    {
        Database.CursoDisciplinaDatabase db = new CursoDisciplinaDatabase();

        public void Inserir(Models.TbCursoDisciplina cursoDisciplina)
        {
            if(cursoDisciplina.IdCurso <= 0)
            {
                throw new Exception("ID do cursoDisciplina invalido");
            }
            if(cursoDisciplina.IdDisciplina <= 0 )
            {
                throw new Exception("ID  da disciplina invalido");
            }
            bool validarCurso = db.ValidarIdCurso(cursoDisciplina);

            if(validarCurso == true)
            {
                throw new Exception("ID do curso já validado no sistema");
            }
            bool validarDisciplina = db.ValidarIdDisciplina(cursoDisciplina);
            if(validarDisciplina == true)
            {
                throw new Exception("Disciplina já registrada no sistema");
            }
            db.Inserir(cursoDisciplina);
        }        
        public void Deletar(int id)
        {
            if(id <= 0)
            {
                throw new Exception("ID do cursoDisciplina invalido");
            }
            db.Deletar(id);
        }   
        
        public void Alterar(int id, Models.TbCursoDisciplina cursoDisciplina)
        {
            if(id <= 0)
            {
                throw new Exception("ID inválido");
            }
            if(cursoDisciplina.IdCurso <= 0)
            {
                throw new Exception("ID do cursoDisciplina invalido");
            }
            if(cursoDisciplina.IdDisciplina <= 0 )
            {
                throw new Exception("ID  da disciplina invalido");
            }

            db.Alterar(id, cursoDisciplina);           
        }   
        
        public List<Models.TbCursoDisciplina> Consultar()
        {
            List<Models.TbCursoDisciplina> consulta = db.Consultar();

            if(consulta == null)
            {
                throw new Exception("Consulta inválida");
            }

            return consulta;
        }
        
        public List<Models.TbCursoDisciplina>  ConsultarPorId(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Id inválido para consulta");
            }    

            List<Models.TbCursoDisciplina> consulta = db.ConsultarPorId(id);
            if (consulta == null)
            {
                throw new Exception("Consulta inválida");
            }

            return consulta;
        }   
    }
}