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

        public bool ValidarNmCurso(Models.TbCurso curso)
        {
            bool validar = db.TbCurso.Any(x => x.NmCurso == curso.NmCurso);
            
            return validar;
        }
        public void Alterar(Models.TbCurso curso)
        {
            Models.TbCurso alterar = db.TbCurso.FirstOrDefault(x => x.IdCurso == curso.IdCurso);
            alterar.IdFuncionarioAlteracao = curso.IdFuncionarioAlteracao;
            alterar.NmCurso = curso.NmCurso;
            alterar.NrCapacidadeMaxima = curso.NrCapacidadeMaxima;
            
            db.SaveChanges();
        }
        public void Remover(int id)
        {
            Models.TbCurso remover = db.TbCurso.FirstOrDefault(x => x.IdCurso == id);
            db.Remove(remover);
            db.SaveChanges();
        }
        public List<Models.TbCurso> Consultar()
        {
            List<Models.TbCurso> Listar = db.TbCurso.ToList();
            return Listar;
        }
        public List<Models.TbCurso> ConsultarPorID (int id)
        {
            List<Models.TbCurso> Consultar = db.TbCurso.Where(x => x.IdCurso == id).ToList();
            return Consultar;
        }
    }
}