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
          throw new ArgumentException("O id da sala não pode ser igual a zero");

          else if(string.IsNullOrEmpty(modelo.DsPeriodo))
          throw new ArgumentException("Preencha o periodo");

          else if(modelo.NrOrdem <= 0)
          throw new ArgumentException("o numero da ordem não pode ser igual a zero");

          else if(modelo.QtInscritos <= 0)
          throw new ArgumentException("A quantidade de inscritos não pode ser igual a zero");

          db.Inserir(modelo);
        }

        public List<TbSalaVestibular> Consultar()
       {
           List<TbSalaVestibular> salas = db.Consultar();
           return salas;
       }
       public void Deletar(int id)
       {
          if(id == 0)
          throw new ArgumentException("O id não pode ser igual a zero");

           db.Deletar(id);
       }
       public void Alterar(TbSalaVestibular modelo)
       {
           if(modelo.IdSalaVestibular == 0)
          throw new ArgumentException("O id da sala do vestibular não pode ser igual a zero");

          else if(modelo.IdSala <= 0)
            throw new ArgumentException("O id da sala não pode ser igual a zero");

          else if(string.IsNullOrEmpty(modelo.DsPeriodo))
          throw new ArgumentException("Preencha o periodo");

          else if(modelo.NrOrdem <= 0)
          throw new ArgumentException("o numero da ordem não pode ser igual a zero");

          else if(modelo.QtInscritos <= 0)
          throw new ArgumentException("A quantidade de inscritos não pode ser igual a zero");
           db.Alterar(modelo);
       }
       public TbSalaVestibular BuscarPorID(int id)
       {
           if(id == 0)
          throw new ArgumentException("O id não pode ser igual a zero");

           TbSalaVestibular sala = db.BuscarPorID(id);
           return sala;
       }
       public void DeletarPorSala(int id)
       {
           if(id == 0)
          throw new ArgumentException("O id não pode ser igual a zero");

           db.DeletarPorSala(id);
       }
    }
}