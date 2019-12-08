using System;
using System.Collections.Generic;
using System.Collections;
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
           List<TbSala> salas = db.TbSala.OrderBy(t => t.NmSala).ToList();
           return salas;
       }
       public List<TbSala> ConsultarPorInstituicao(string nome)
       {
           List<TbSala> salas = db.TbSala.Where(t => t.NmLocal.ToLower().Contains(nome.ToLower())).OrderBy(t => t.NmSala).ToList();
           return salas;
       }
       public void Deletar(int id)
       {
             TbSala sala = db.TbSala.First(t => t.IdSala == id);
             db.TbSala.Remove(sala);
             db.SaveChanges();
       }
        public TbSala BuscarPorID(int id)
       {
             TbSala sala = db.TbSala.First(t => t.IdSala == id);
             return sala;
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
       public bool VerificarNome(string nome)
       {
           bool existe = db.TbSala.Any(t => t.NmSala.ToLower() == nome.ToLower() );
           return existe;
       }
       
    }
}