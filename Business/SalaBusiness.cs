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
        
    Database.SalaDatabase a = new SalaDatabase();

      public void Inserir(Models.TbSala modelo)
      {
        //  if(modelo.nm_local == string.Empty)
        //  throw new ArgumentException("Coloque o nome do local");

        //  else if(modelo.nm_sala == string.Empty)
        //  throw new ArgumentException("Coloque o nome da sala");

        //  else if(modelo.nr_capacidade_maxima <= 0)
        //  throw new ArgumentException("A capacidade maxima nao pode ser igual a zero");

        //  else if( modelo.bt_ativo == null )
        //  throw new ArgumentException("");

        //  else if(modelo.dt_inclusao == null)
        //  throw new ArgumentException("A data nao pode ser vazia");

        //  else if(modelo.dt_alteracao == null )
        //  throw new ArgumentException("A data nao pode ser vazia");

        //  else if( modelo.id_funcionario_alteracao <= 0)
        //  throw new ArgumentException("O id do funcionario nao pode ser 0");
         
        //  a.Inserir(modelo);
      }

       public List<Models.TbSala> Consultar()
       {
           return null;
       }
       public void Deletar(int id)
       {
          if(id == 0)
          throw new ArgumentException("O id nao pode ser igual a zero");

           a.Deletar(id);
       }
       public void Alterar(Models.TbSala modelo)
       {
           a.Alterar(modelo);
       }

    }
}