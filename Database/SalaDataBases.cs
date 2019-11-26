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

       public void Inserir(Models.TbSala modelo)
       {
           db.TbSala.Add(modelo);
           db.SaveChanges();
       }
        public List<Models.TbSala> Consultar()
       {
           List<Models.TbSala> salas = db.TbSala.ToList();
           return salas;
       }
       public void Deletar(int id)
       {
        //    Models.TbSala sala = db.TbSala.First(t => t.id_sala == id);
        //    db.TbSala.Remove(sala);
        //    db.SaveChanges();
       }
       public void Alterar(Models.TbSala modelo)
       {
        //  Models.TbSala sala = db.TbSala.First(t => t.id_sala == id);

        //  sala.nm_local = modelo.nm_local;
        //  sala.nm_sala = modelo.nm_sala;
        //  sala.nr_capacidade_maxima = modelo.nr_capacidade_maxima;
        //  sala.bt_ativo = modelo.bt_ativo;
        //  sala.dt_inclusao = modelo.dt_inclusao;
        //  sala.dt_alteracao = modelo.dt_alteracao;
        //  sala.id_funcionario_alteracao = modelo.id_funcionario_alteracao;

         db.SaveChanges();

       }
       
    }
}