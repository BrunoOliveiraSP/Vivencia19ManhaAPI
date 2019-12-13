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

        public Models.TbCurso InserirCurso(Models.TbCurso curso)
        {
            db.TbCurso.Add(curso);

            db.SaveChanges();

            return curso;
        }
        
        public bool Validarsigla(Models.TbCurso curso)
        {
            bool validar = db.TbCurso.Any(x => x.DsSigla == curso.DsSigla);

            return validar;
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
            alterar.DsCategoria = curso.DsCategoria;
            alterar.NrCapacidadeMaxima = curso.NrCapacidadeMaxima;
            alterar.BtAtivo = curso.BtAtivo;
            
            db.SaveChanges();
        }
        public void Remover(int id)
        {
            Models.TbCurso removerCurso = db.TbCurso.FirstOrDefault(x => x.IdCurso == id);
            db.Remove(removerCurso);
            db.SaveChanges();
        }
        public bool ValidarRemover(int id)
        {
            bool validar = db.TbCursoDisciplina.Any(x => x.IdCurso == id);
            
            return validar;
        }
        public  List<Models.TbCurso> Consultar()
        {
            List<Models.TbCurso> Listar = db.TbCurso.OrderBy(x => x.NmCurso).ToList();
            return Listar;
        }
        public List<Models.TbCurso> ConsultarPorNomeSigla(string nome, string sigla)
        {
            List<Models.TbCurso> Consultar = db.TbCurso.Where(x => x.NmCurso.Contains(nome)
                                                            || x.DsSigla.Contains(sigla))
                                                       .OrderBy(x => x.NmCurso).ToList();
            return Consultar;
        }
        public List<Models.TbCurso> ConsultarPorSigla(string sigla)
        {
            List<Models.TbCurso> consulta = db.TbCurso.Where(x => x.DsSigla.Contains(sigla))
                                                            .OrderBy(x => x.NmCurso).ToList();

            return consulta;
        }

    }
}