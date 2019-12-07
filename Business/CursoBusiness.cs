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
                throw new ArgumentException("Ocorreu um erro. Insira o nome do curso");
            
            if(curso.DsCategoria == "Selecione")
                throw new  ArgumentException("Ocorreu um erro. Altere a categoria do curso");
            
            bool validar = db.ValidarNmCurso(curso);
            if (validar == true)
                throw new Exception("Ocorreu um erro. Impossivel cadastrar duas vezes o mesmo curso no sistema"); 
            
            if(curso.NrCapacidadeMaxima <= 0 || curso.NrCapacidadeMaxima > 50)
                throw new Exception("Ocorreu um erro. A capacidade de alunos deve ser maior que zero e igual ou menor a cinquenta");

            if(curso.DsSigla == string.Empty)
                throw new Exception("Ocorreu um erro. Insira o campo da sigla do curso");
                
            if(curso.DsCategoria == string.Empty)
                throw new Exception("Ocorreu um erro. Insira um categoria para o curso");
            db.InserirCurso(curso);
        }

        public void Alterar(Models.TbCurso curso)
        {
            if(curso.NmCurso == string.Empty)
                throw new Exception("Ocorreu um erro. Insria o nome do curso");
            
            if(curso.DsSigla == string.Empty)
                throw new Exception("Öcorreu um erro. Insira uma sigla para o curso");

            if(curso.DsCategoria == "Selecione")
                throw new Exception("Öcorreu um erro. Insira uma sigla para o curso");

            if(curso.NrCapacidadeMaxima <= 0 || curso.NrCapacidadeMaxima > 50)
                throw new Exception("Ocorreu um erro. A capacidade de alunos deve ser maior que zero e igual ou menor a cinquenta");

            if(curso.DsCategoria == string.Empty)
                throw new Exception("Ocorreu um erro. Insira um categoria para o curso");
            db.Alterar(curso);

        }
        public void Remover(int id)
        {
            if(id <= 0)  
                throw new Exception("Ocorreu um erro. Insira um ID de curso para remover no sistema");
            db.Remover(id);
        }
        public List<Models.TbCurso> Consultar()
        {
            List<Models.TbCurso> consulta = db.Consultar();
            if(consulta == null)
                throw new Exception("Ocorreu um erro. Nenhum valor para consulta no sistema");

            return consulta;
        }
        public List<Models.TbCurso> ConsultarPorNome(string nome)
        {
            List<Models.TbCurso> consulta = db.ConsultarPorNome(nome);
            if(consulta == null)
                throw new Exception("Ocorreu um erro. Nenhum valor correspondente encontrado no sistema");
            return consulta;
        }

        public List<Models.TbCurso> ConsultarPorSigla(string sigla)
        {
            List<Models.TbCurso> consulta = db.ConsultarPorSigla(sigla);
            if (consulta == null )
                throw new Exception("Ocorreu um erro. Nenhum valor correspondente encontrado no sistema");
            return consulta;
        }
    }
}