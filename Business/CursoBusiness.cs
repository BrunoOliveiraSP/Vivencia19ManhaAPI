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

        public Models.TbCurso InserirCurso(Models.TbCurso curso)
        {
            this.AjustarNome(curso);
            if(curso.NmCurso == string.Empty)
                throw new ArgumentException("Ocorreu um erro. Insira o nome do curso.");
            
            if(curso.DsCategoria == "Selecione")
                throw new  ArgumentException("Ocorreu um erro. Altere a categoria do curso.");
            
            bool validar = db.ValidarNmCurso(curso);
            if (validar == true)
                throw new Exception("Ocorreu um erro. Impossivel cadastrar duas vezes o mesmo curso no sistema."); 
            
            bool validarSigla = db.Validarsigla(curso);
            if (validarSigla == true)
            throw new Exception("Ocorreu um erro. Impossivel duas vezes a mesma sigla no sistema.");

            if(curso.NrCapacidadeMaxima <= 0 || curso.NrCapacidadeMaxima > 50)
                throw new Exception("Ocorreu um erro. A capacidade de alunos deve ser maior que zero e igual ou menor a cinquenta.");

            if(curso.DsSigla == string.Empty)
                throw new Exception("Ocorreu um erro. Insira o campo da sigla do curso.");
                
            if(curso.DsCategoria == string.Empty)
                throw new Exception("Ocorreu um erro. Insira um categoria para o curso.");
             db.InserirCurso(curso);
            
            return curso;
        }

        public void Alterar(Models.TbCurso curso)
        {
            this.AjustarNome(curso);

            if(curso.NmCurso == string.Empty)
                throw new Exception("Ocorreu um erro. Insria o nome do curso.");
            
            if(curso.DsSigla == string.Empty)
                throw new Exception("Öcorreu um erro. Insira uma sigla para o curso.");

            if(curso.DsCategoria == "Selecione")
                throw new Exception("Öcorreu um erro. Insira uma sigla para o curso.");

            if(curso.NrCapacidadeMaxima <= 0 || curso.NrCapacidadeMaxima > 50)
                throw new Exception("Ocorreu um erro. A capacidade de alunos deve ser maior que zero e igual ou menor a cinquenta.");

            if(curso.DsCategoria == string.Empty)
                throw new Exception("Ocorreu um erro. Insira um categoria para o curso.");
            db.Alterar(curso);

        }
        public void Remover(int id)
        {
            if(id <= 0)  
                throw new Exception("Ocorreu um erro. Insira um ID de curso para remover no sistema.");
            
            bool validar = db.ValidarRemover(id);
            if(validar == true)
                throw new Exception("Ocorreu um erro. Impossivel remover um curso vinculado a uma disciplina.");
            db.Remover(id);
            
        }
        public List<Models.TbCurso> Consultar()
        {
            List<Models.TbCurso> consulta = db.Consultar();
            if(consulta == null)
                throw new Exception("Ocorreu um erro. Nenhum valor para consulta no sistema.");

            return consulta;
        }
        public List<Models.TbCurso> ConsultarPorNomeSigla(string nome, string sigla)
        {   
            this.AjustarNomeConsulta(nome, sigla);
            List<Models.TbCurso> consulta = db.ConsultarPorNomeSigla(nome, sigla);
            return consulta;
        }

        public List<Models.TbCurso> ConsultarPorSigla(string sigla)
        {
            List<Models.TbCurso> consulta = db.ConsultarPorSigla(sigla);
            if (consulta == null )
                throw new Exception("Ocorreu um erro. Nenhum valor correspondente encontrado no sistema.");
            return consulta;
        }
        public void AjustarNomeConsulta(string nome, string sigla)
        {
            if (nome != string.Empty && sigla != string.Empty)
            {
            string primeiraLetra = nome.Substring(0, 1).ToUpper();
            string resto = nome.Substring(1).ToLower();
            nome = primeiraLetra +  resto;
            
            sigla = sigla.ToUpper();
            }
        }
        public void AjustarNome(Models.TbCurso curso)
        {
            if (curso.NmCurso != string.Empty)
            {
            string nome = curso.NmCurso;
            string primeiraLetra = nome.Substring(0, 1).ToUpper();
            string resto = nome.Substring(1).ToLower();
            string nomeAjustado = primeiraLetra +  resto;
            curso.NmCurso = nomeAjustado;
            }
        }
    }
}