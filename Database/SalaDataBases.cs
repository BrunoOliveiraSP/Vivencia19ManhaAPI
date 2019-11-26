using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vivencia19ManhaAPI.Models;
using System.Linq;

namespace Vivencia19ManhaAPI.Database
{
    public class SalaDatabase
    {
       db_a5064d_freiContext db = new db_a5064d_freiContext();

       public void Inserir(TbSala modelo)
       {
           db.TbSala.Add(modelo);
           db.SaveChanges();
       }
        public List<TbSala> Consultar()
       {
           List<TbSala> salas = db.TbSala.ToList();
           return salas;
       }
       public void Deletar(int id)
       {
             TbSala sala = db.TbSala.First(t => t.IdSala == id);
             db.TbSala.Remove(sala);
             db.SaveChanges();
       }
       public void Alterar(TbSala modelo)
       {
          TbSala sala = db.TbSala.First(t => t.IdSala == modelo.IdSala);
            
          sala.NmLocal = modelo.NmLocal;
          sala.NmSala = modelo.NmSala;
          sala.NrCapacidadeMaxima = modelo.NrCapacidadeMaxima;
          sala.BtAtivo = modelo.BtAtivo;
          sala.DtInclusao = modelo.DtInclusao;
          sala.DtAlteracao = modelo.DtAlteracao;
          sala.IdFuncionarioAlteracao = modelo.IdFuncionarioAlteracao;

         db.SaveChanges();

       }
       
    }
}