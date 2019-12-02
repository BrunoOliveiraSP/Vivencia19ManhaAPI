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
        
        public void Alterar(Models.TbCursoDisciplina cursoDisciplina)
        { 
                   db.Alterar(cursoDisciplina);           
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
            List<Models.TbCursoDisciplina> consulta = db.ConsultarPorId(id);
            if (consulta == null)
            {
                throw new Exception("Consulta inválida");
            }

            return consulta;
        }   
    }
}