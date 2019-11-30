using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vivencia19ManhaAPI.Models;
using System.Linq;
using Vivencia19ManhaAPI.Database;

namespace Vivencia19ManhaAPI.Business
{
    public class CursoBusiness
    {
        Database.CursoDatabase db = new Database.CursoDatabase();

        public void InserirCurso(Models.TbCurso curso)
        {
            if(curso.NmCurso == string.Empty)
            {
                throw new Exception("Insira o nome de um curso");
            }
            if(curso.NrCapacidadeMaxima <= 0 || curso.NrCapacidadeMaxima > 50)
            {
                throw new Exception("Insira um valor váildo para o limite maximo");
            }

            bool validar = db.ValidarNmCurso(curso);
            if(validar == true)
            {
                throw new Exception("Nome do curso já validado no sistema");
            }
        
            db.InserirCurso(curso);
        }

        public void Alterar(Models.TbCurso curso)
        {
            if (curso.IdFuncionarioAlteracao <= 0)
            {
                throw new Exception("Valor inválido para o ID do funcionario");
            }
            if(curso.NmCurso == string.Empty)
            {
                throw new Exception("Insira o nome de um curso");
            }
            if(curso.NrCapacidadeMaxima <= 0 || curso.NrCapacidadeMaxima > 50)
            {
                throw new Exception("Insira um valor váildo para o limite maximo");
            }

            db.Alterar(curso);

        }
        public void Remover(int id)
        {
            if(id == 0) { 
                throw new Exception("ID Invalido");
            }
            db.Remover(id);
        }
        public List<Models.TbCurso> Consultar()
        {
            return db.Consultar();
        }
        public List<Models.TbCurso> ConsultarPorNome(string nome)
        {
            List<Models.TbCurso> consulta = db.ConsultarPorNome(nome);
            return consulta;
        }

        public List<Models.TbCurso> ConsultarPorSigla(string sigla)
        {
            List<Models.TbCurso> consulta = db.ConsultarPorSigla(sigla);
            return consulta;
        }
    }
}