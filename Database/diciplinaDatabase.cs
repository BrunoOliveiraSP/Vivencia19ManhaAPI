using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Vivencia19ManhaAPI.Models;

namespace Vivencia19ManhaAPI.Database
{
    public class diciplinaDatabase
    {
        Models.db_a5064d_freiContext db = new Models.db_a5064d_freiContext();

        public void InserirDisciplina(Models.TbDisciplina disciplina)
        {
            db.TbDisciplina.Add(disciplina);
            db.SaveChanges();
        }

        internal void Alterar(TbDisciplina disciplina)
        {
            TbDisciplina editar = db.TbDisciplina.FirstOrDefault(x => x.IdDisciplina == disciplina.IdDisciplina);
            editar.IdFuncionarioAlteracao = disciplina.IdFuncionarioAlteracao;
            editar.BtAtivo = disciplina.BtAtivo;
            editar.DsSigla = disciplina.DsSigla;
            editar.DtInclusao = disciplina.DtInclusao; 
            editar.DtUltimaAlteracao = disciplina.DtUltimaAlteracao;
            editar.NmDisciplina = disciplina.NmDisciplina;

            db.SaveChanges();           
        }
        public void Deletar(int id)
        {
            Models.TbDisciplina tb = db.TbDisciplina.FirstOrDefault(x => x.IdDisciplina == id); 

            db.TbDisciplina.Remove(tb);
        }

        internal List<TbDisciplina> lista(string nome)
        {
            
            if(string.IsNullOrEmpty(nome))
                return db.TbDisciplina.ToList();
            return db.TbDisciplina.Where(x => x.NmDisciplina == nome).ToList();

        }
    }
}