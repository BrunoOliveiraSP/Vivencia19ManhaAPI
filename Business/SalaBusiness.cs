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
    Business.SalaVestibularBusiness business = new SalaVestibularBusiness();
    Database.SalaDatabase db = new SalaDatabase();

      public void Inserir(TbSala modelo)
      {
          ValidarSala(modelo);

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
          ValidarID(id);

          TbSala sala = db.BuscarPorID(id);

          business.DeletarPorSala(sala.IdSala);
           db.Deletar(id);
       }
       public void Alterar(TbSala modelo)
       {
           ValidarID(modelo.IdSala);
           ValidarSala(modelo);

           db.Alterar(modelo);
       }
       public TbSala BuscarPorID(int id)
       {
         ValidarID(id);

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
       public void ValidarSala(TbSala modelo)
         {
            if(string.IsNullOrEmpty(modelo.NmLocal) == true)
              throw new ArgumentException("Informe o nome do local.");

              else if(modelo.NmLocal == "Selecione")
            throw new ArgumentException("Selecione uma Instituição.");

            else if(string.IsNullOrEmpty(modelo.NmSala) == true)
              throw new ArgumentException("Informe o nome da sala.");

            else if(modelo.NrCapacidadeMaxima <= 0)
              throw new ArgumentException("Capacidade máxima inválida.");

            else if( modelo.IdFuncionarioAlteracao <= 0)
              throw new ArgumentException("Informe um funcionário.");

              VerificarNome(modelo.NmSala);
         }
         public void ValidarID(int id)
         {
            if(id <= 0)
              throw new ArgumentException("Selecione uma sala.");
         }
         private void VerificarNome(string nome)
         {
           bool existe = db.VerificarNome(nome);

           if(existe == true)
           throw new ArgumentException("Sala ja cadastrada, informe outro nome.");
         }
         public TbSala BuscarPorNome(string nome)
         {
            if(string.IsNullOrEmpty(nome) == true || nome == "Selecione")
              throw new ArgumentException("Selecione uma sala.");

              return db.BuscarPorNome(nome);
         }

    }
}