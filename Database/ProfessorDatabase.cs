using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using Vivencia19ManhaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Vivencia19ManhaAPI.Database
{
    public class ProfessorDatabase
    {
            db_a5064d_freiContext db = new db_a5064d_freiContext();

        public void Inserir(Models.TbProfessor professor)
        {
            db.TbProfessor.Add(professor);
            db.SaveChanges();
        }

        public void Alterar(Models.TbProfessor professor)
        {
            Models.TbProfessor novo = db.TbProfessor.FirstOrDefault(x => x.IdProfessor == professor.IdProfessor);

            novo.NmProfessor = professor.NmProfessor;
            novo.DsCelular = professor.DsCelular;
            novo.DsTelefone = professor.DsTelefone;
            novo.DtNascimento = professor.DtNascimento;
            novo.DsEstado = professor.DsEstado;
            novo.DsEmail = professor.DsEmail;
            novo.DsCvLattes = professor.DsCvLattes;
            novo.NrAnoPrimeiroEmprego = professor.NrAnoPrimeiroEmprego;
            novo.DsCpf = professor.DsCpf;
            novo.DsRg = professor.DsRg;
            novo.DsRgOrgao = professor.DsRgOrgao;
            novo.DsRgEmissor = professor.DsRgEmissor;
            novo.NmMae = professor.NmMae;
            novo.NmPai = professor.NmPai;
            novo.TpContratacao = professor.TpContratacao;
            novo.BtAtivo = professor.BtAtivo;
            novo.DsFaculdade = professor.DsFaculdade;
            novo.DsCurso = professor.DsCurso;
            novo.DtFaculdadeInicio = professor.DtFaculdadeInicio;
            novo.DtFaculdadeFim = professor.DtFaculdadeFim;

            db.SaveChanges();
        }
        public List<Models.TbProfessor> ListarTodos()
        {
            List<Models.TbProfessor> lista = db.TbProfessor
                                             .Include(x => x.TbProfessorDisciplina)
                                             .ToList();
            return lista;
        }

        public List<Models.TbProfessor> ConsultarPorNome(string nome)
	    {
		List<Models.TbProfessor> list = db.TbProfessor.Where(x => x.NmProfessor.Contains(nome))
                                        .Include(x => x.TbProfessorDisciplina)
                                        .ToList();

		return list;
	    }

        public Models.TbProfessor ConsultarPotId(int Id)
        {
            Models.TbProfessor l = db.TbProfessor.FirstOrDefault(x => x.IdProfessor == Id);
            return l;
        }

        public void Deletar(int id)
         {
             Models.TbProfessor r = db.TbProfessor.FirstOrDefault(x =>x.IdProfessor == id);
             db.TbProfessor.Remove(r);
             db.SaveChanges();
         } 
    }
    
}