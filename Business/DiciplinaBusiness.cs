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

           // if(disciplina.IdFuncionarioAlteracao == 0)
            //  throw new ArgumentException("informe o id");
            
            db.InserirDisciplina(disciplina);
        }

        internal void Alterar(Models.TbDisciplina disciplina)
        {
            if(Verificar(disciplina))
                db.Alterar(disciplina);
        }

        public bool Verificar(Models.TbDisciplina disciplina)
        {
            if(disciplina.BtAtivo <= 0)
                return false;
            if(string.IsNullOrEmpty(disciplina.DsSigla))
                return false;
            if(string.IsNullOrEmpty(disciplina.DtInclusao.ToString()))
                return false;
            if(string.IsNullOrEmpty(disciplina.NmDisciplina))
                return false;
          //  if(disciplina.IdFuncionarioAlteracao == 0)
           //     return false;
            return true;
        }

        public void remover (int id)
        {
          if(id == 0)
          throw new ArgumentException("id invalido");
           db.Deletar(id);
        }

        public List<Models.TbDisciplina> listarPorNome (string nome)
        {
           List<Models.TbDisciplina> list = db.listaPorNome(nome);

           return list;
        }
         public List<Models.TbDisciplina> listar()
        {
            
             List<Models.TbDisciplina> lista = db.listar();
             return lista;

         }  
          
          public List<Models.TbDisciplina> LIstarporsigla (string sigla)
          {
              List<Models.TbDisciplina>LIstarporsigla=db.listarporsigla(sigla);

              return LIstarporsigla;
          }

    }
}