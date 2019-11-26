using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vivencia19ManhaAPI.Models;
using System.Linq;

namespace Vivencia19ManhaAPI.Database
{
    public class SalaVestibularDataBases
    {
        Models.db_a5064d_freiContext db = new Models.db_a5064d_freiContext();

        public void Inserir(Models.TbSalaVestibular modelo)
        {
            db.TbSalaVestibular.Add(modelo);
            db.SaveChanges();
        }

        public List<Models.TbSalaVestibular> Consultar()
       {
           List<Models.TbSalaVestibular> salas = db.TbSalaVestibular.ToList();
           return salas;
       }

       public void Deletar(int id)
       {
           Models.TbSalaVestibular sala = db.TbSalaVestibular.First(t => t.IdSalaVestibular == id);
           db.TbSalaVestibular.Remove(sala);
           db.SaveChanges();
       }

       public void Alterar(Models.TbSalaVestibular modelo)
       {
         Models.TbSalaVestibular sala = db.TbSalaVestibular.First(t => t.IdSalaVestibular == modelo.IdSalaVestibular);

        //  sala.id_sala = modelo.id_sala;
        //  sala.ds_periodo = modelo.ds_periodo;
        //  sala.nr_capacidade_maxima = modelo.nr_capacidade_maxima;
        //  sala.nr_ordem = modelo.nr_ordem;
        //  sala.qt_inscritos = modelo.qt_inscritos;
        
         db.SaveChanges();

       }
    }
}