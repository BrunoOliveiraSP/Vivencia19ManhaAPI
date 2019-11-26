using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vivencia19ManhaAPI.Models;
using System.Linq;
using Vivencia19ManhaAPI.Database;

namespace Vivencia19ManhaAPI.Business
{
    public class SalaVestibularBusiness
    {
        Database.SalaVestibularDataBases db = new SalaVestibularDataBases();
        public void Inserir(Models.TbSalaVestibular modelo)
        {
          if(modelo.IdSala <= 0)
          throw new ArgumentException("O id da sala nao pode ser igual a zero");

          else if(modelo.DsPeriodo == string.Empty)
          throw new ArgumentException("Preencha o periodo corretamente");

          else if(modelo.NrOrdem <= 0)
          throw new ArgumentException("A capacidade maxima nao pode ser igual a zero");

          else if(modelo.QtInscritos <= 0)
          throw new ArgumentException("A quatidade de inscritos nao pode ser igual a zero");

          db.Inserir(modelo);
        }

        public List<TbSalaVestibular> Consultar()
       {
           return null;
       }
       public void Deletar(int id)
       {
          if(id == 0)
          throw new ArgumentException("O id nao pode ser igual a zero");

           db.Deletar(id);
       }
       public void Alterar(TbSalaVestibular modelo)
       {
           db.Alterar(modelo);
       }
    }
}