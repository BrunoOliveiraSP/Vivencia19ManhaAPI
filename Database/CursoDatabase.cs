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
            alterar.NmCurso = curso.NmCurso;
            alterar.DsSigla = curso.DsSigla;
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
            List<Models.TbCurso> Listar = db.TbCurso.OrderBy(x => x.NmCurso).ToList();
            return Listar;
        }
        public List<Models.TbCurso> ConsultarPorNome(string nome)
        {
            List<Models.TbCurso> Consultar = db.TbCurso.OrderBy(x => x.NmCurso.Contains(nome)).ToList();
            return Consultar;
        }
        public List<Models.TbCurso> ConsultarPorSigla(string sigla)
        {
            List<Models.TbCurso> consulta = db.TbCurso.Where(x => x.DsSigla.Contains(sigla)).ToList();

            return consulta;
        }

    }
}