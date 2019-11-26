using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;
using System.Linq;

namespace Vivencia19ManhaAPI.Database
{
    public class SalaVestibularDataBases
    {
        Models.db_a504d_FreiContext db = new Models.db_a504d_FreiContext();

        public void Inserir(Models.tbSalaVestibular modelo)
        {
            db.tbSalaVestibular.Add(modelo);
           db.SaveChanges();
        }

        public List<Models.tbSalaVestibular> Consultar()
       {
           List<Models.tbSalaVestibular> salas = db.tbSalaVestibular.ToList();
           return salas;
       }

       public void Deletar(int id)
       {
           Models.tbSalaVestibular sala = db.TbSala.First(t => t.id_sala_vestibular == id);
           db.tbSalaVestibular.Remove(sala);
           db.SaveChanges();
       }

       public void Alterar(Models.tbSalaVestibular modelo)
       {
         Models.tbSalaVestibular sala = db.tbSalaVestibular.First(t => t.id_sala_vestibular == id);

         sala.id_sala = modelo.id_sala;
         sala.ds_periodo = modelo.ds_periodo;
         sala.nr_capacidade_maxima = modelo.nr_capacidade_maxima;
         sala.nr_ordem = modelo.nr_ordem;
         sala.qt_inscritos = modelo.qt_inscritos;
        
         db.SaveChanges();

       }
    }
}