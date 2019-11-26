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

      public void Inserir(TbSala modelo)
      {
          if(modelo.NmLocal == string.Empty)
          throw new ArgumentException("Coloque o nome do local");

          else if(modelo.NmSala == string.Empty)
          throw new ArgumentException("Coloque o nome da sala");

         else if(modelo.NrCapacidadeMaxima <= 0)
          throw new ArgumentException("A capacidade maxima nao pode ser igual a zero");

          else if( modelo.BtAtivo == 0 )
          throw new ArgumentException("Responda se a sala esta ativa ou não");

          else if(modelo.DtInclusao == null)
          throw new ArgumentException("A data nao pode ser vazia");

          else if(modelo.DtAlteracao == null )
          throw new ArgumentException("A data nao pode ser vazia");

          else if( modelo.IdFuncionarioAlteracao <= 0)
          throw new ArgumentException("O id do funcionario nao pode ser 0");
         
          a.Inserir(modelo);
      }

       public List<TbSala> Consultar()
       {
           return null;
       }
       public void Deletar(int id)
       {
          if(id == 0)
          throw new ArgumentException("O id nao pode ser igual a zero");

           a.Deletar(id);
       }
       public void Alterar(TbSala modelo)
       {
           a.Alterar(modelo);
       }

    }
}