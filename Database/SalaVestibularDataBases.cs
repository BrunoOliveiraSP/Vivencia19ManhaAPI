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
            OrganizarOrdem();
        }

        public List<Models.TbSalaVestibular> Consultar()
       {
           List<Models.TbSalaVestibular> salas = db.TbSalaVestibular.ToList();
           return salas;
       }

       public void Deletar(int id)
       {
           Models.TbSalaVestibular sala = db.TbSalaVestibular.FirstOrDefault(t => t.IdSalaVestibular == id);
           db.TbSalaVestibular.Remove(sala);
           db.SaveChanges();
       }

       public void Alterar(Models.TbSalaVestibular modelo)
       {
         Models.TbSalaVestibular sala = db.TbSalaVestibular.FirstOrDefault(t => t.IdSalaVestibular == modelo.IdSalaVestibular);

          sala.IdSala = modelo.IdSala;
          sala.DsPeriodo = modelo.DsPeriodo;
          sala.NrOrdem = modelo.NrOrdem;
          sala.QtInscritos = modelo.QtInscritos;
          
         db.SaveChanges();
         OrganizarOrdem();
       }
       public Models.TbSalaVestibular BuscarPorID(int id)
       {
           Models.TbSalaVestibular sala = db.TbSalaVestibular.FirstOrDefault(t => t.IdSalaVestibular == id);
           return sala;

       }
       public void DeletarPorSala(int id)
       {
           List<Models.TbSalaVestibular> salas = db.TbSalaVestibular.Where(t => t.IdSala == id).ToList();

           foreach(var item in salas)
           {
               Deletar(item.IdSalaVestibular);
           }
       }
       public void OrganizarOrdem()
       {
           List<TbSalaVestibular> salas = db.TbSalaVestibular.OrderBy(t => TimeSpan.Parse(t.DsPeriodo)).ToList();
           int ordem = 1;
           foreach(var item in salas)
           {
               item.NrOrdem = ordem;
               Alterar(item);
               ordem = ordem+1;
           }
       }
    }
}