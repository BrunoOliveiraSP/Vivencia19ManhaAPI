using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vivencia19ManhaAPI.Models;
using System.Linq;
using Vivencia19ManhaAPI.Database;
using System.Text.RegularExpressions;

namespace Vivencia19ManhaAPI.Business
{
    public class SalaVestibularBusiness
    {
        Database.SalaVestibularDataBases db = new SalaVestibularDataBases();
        public void Inserir(Models.TbSalaVestibular modelo)
        {
          ValidarSala(modelo);

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
           throw new ArgumentException("Selecione uma sala de vestibular válida.");

           db.Deletar(id);
       }
       public void Alterar(TbSalaVestibular modelo)
       {
           if(modelo.IdSalaVestibular == 0)
          throw new ArgumentException("Selecione uma sala de vestibular válida.");

           ValidarSala(modelo);
           db.Alterar(modelo);
       }
       public TbSalaVestibular BuscarPorID(int id)
       {
           if(id == 0)
          throw new ArgumentException("Selecione uma sala de vestibular válida.");

           TbSalaVestibular sala = db.BuscarPorID(id);
           return sala;
       }
       public void DeletarPorSala(int id)
       {
           if(id == 0)
          throw new ArgumentException("Selecione uma sala de vestibular válida.");

           db.DeletarPorSala(id);
       }
       public void ValidarSala(TbSalaVestibular modelo)
       {

          if(modelo.IdSala <= 0)
            throw new ArgumentException("Selecione uma sala válida.");

          else if(string.IsNullOrEmpty(modelo.DsPeriodo))
            throw new ArgumentException("Preencha o período.");

          else if(modelo.NrOrdem <= 0)
            throw new ArgumentException("o numero da ordem não pode ser igual a zero.");

          else if(modelo.QtInscritos <= 0)
            throw new ArgumentException("A quantidade de inscritos não pode ser igual a zero.");
          
          else if(modelo.DsPeriodo == "Selecione" || modelo.DsPeriodo == string.Empty)
          throw new ArgumentException("Selecione um período.");

          
       }
    }
}