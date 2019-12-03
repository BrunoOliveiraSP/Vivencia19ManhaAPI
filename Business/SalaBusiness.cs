using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vivencia19ManhaAPI.Models;
using System.Linq;
using Vivencia19ManhaAPI.Database;

namespace Vivencia19ManhaAPI.Business
{
    public class SalaBusiness
    {
        
    Database.SalaDatabase db = new SalaDatabase();

      public void Inserir(TbSala modelo)
      {
          if(string.IsNullOrEmpty(modelo.NmLocal) == true)
            throw new ArgumentException("Coloque o nome do local");

          else if(string.IsNullOrEmpty(modelo.NmSala) == true)
            throw new ArgumentException("Coloque o nome da sala");

         else if(modelo.NrCapacidadeMaxima <= 0)
            throw new ArgumentException("A capacidade maxima inválida");

          else if( modelo.IdFuncionarioAlteracao <= 0)
            throw new ArgumentException("Informe um funcionário");

          modelo.DtAlteracao = DateTime.Now;
          modelo.DtInclusao = DateTime.Now;
         
          db.Inserir(modelo);
      }

       public List<TbSala> Consultar()
       {
           return db.Consultar();
       }
       public void Deletar(int id)
       {
          if(id == 0)
          throw new ArgumentException("O id nao pode ser igual a zero");

           db.Deletar(id);
       }
       public void Alterar(TbSala modelo)
       {
           if(modelo.IdSala == 0)
            throw new ArgumentException("O id nao pode ser igual a zero");
            
          else if(string.IsNullOrEmpty(modelo.NmLocal) == true)
            throw new ArgumentException("Coloque o nome do local");

          else if(string.IsNullOrEmpty(modelo.NmSala) == true)
            throw new ArgumentException("Coloque o nome da sala");

         else if(modelo.NrCapacidadeMaxima <= 0)
            throw new ArgumentException("A capacidade maxima inválida");

          else if( modelo.IdFuncionarioAlteracao <= 0)
            throw new ArgumentException("Informe um funcionário");

           db.Alterar(modelo);
       }
       public TbSala BuscarPorID(int id)
       {
            if(id == 0)
          throw new ArgumentException("O id nao pode ser igual a zero");

          TbSala sala = db.BuscarPorID(id);
          return sala;
       }
         public List<TbSala> ConsultarPorInstituicao(string nome)
       {
         if(!string.IsNullOrEmpty(nome))
         {
            return db.ConsultarPorInstituicao(nome);
         }
         else
         {
            return db.Consultar();
         }
           
          
       }

    }
}