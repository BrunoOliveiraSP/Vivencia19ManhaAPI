using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vivencia19ManhaAPI.Database;
using Vivencia19ManhaAPI.Models;


namespace Vivencia19ManhaAPI.Business
{
    public class DiciplinaBusiness
    {
        Database.diciplinaDatabase db = new Database.diciplinaDatabase();
        internal void Inserir(Models.TbDisciplina disciplina)
        {
                           
            if(string.IsNullOrEmpty(disciplina.DsSigla))
              throw new ArgumentException("Sigla invalida");
                           
            if(string.IsNullOrEmpty(disciplina.NmDisciplina))
              throw new ArgumentException("Informe o nome da disciplina");
                       
            db.InserirDisciplina(disciplina);
        }

        public void Alterar(Models.TbDisciplina disciplina)
        {
            if(Verificar(disciplina))
                db.Alterar(disciplina);
        }

        public bool Verificar(Models.TbDisciplina disciplina)
        {
            if(string.IsNullOrEmpty(disciplina.DsSigla))
                return false;
            if(string.IsNullOrEmpty(disciplina.DtInclusao.ToString()))
                return false;
            if(string.IsNullOrEmpty(disciplina.NmDisciplina))
                return false;
          
            return true;
        }

        public void Remover (int id)
        {
          if(id == 0)
          throw new ArgumentException("id invalido");
           db.Deletar(id);
        }
        public List<Models.TbDisciplina> ListarPorNome (string nome)
        {
           List<Models.TbDisciplina> list = db.ListaPorNome(nome);

           return list;
        }
         public List<Models.TbDisciplina> Listar()
        {
             List<Models.TbDisciplina> lista = db.Listar();
             return lista;

         }  
          
        public List<Models.TbDisciplina> ListarPorsigla (string sigla)
        {
            List<Models.TbDisciplina>LIstarporsigla=db.ListarPorsigla(sigla);

            return LIstarporsigla;
        }

        public List<Models.TbDisciplina> ListarDisciplina (string disciplina, string sigla)   
        {
            List<Models.TbDisciplina> ListarDisciplina = db.ListarDisciplina(disciplina, sigla);

            return ListarDisciplina;
        }

    }
}