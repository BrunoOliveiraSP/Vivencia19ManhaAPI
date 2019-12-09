using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using Vivencia19ManhaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Vivencia19ManhaAPI.Database
{
    public class LoginDatabase
    {
        db_a5064d_freiContext db = new db_a5064d_freiContext();

        public void Inserir(Models.TbLogin login)
        {
            db.TbLogin.Add(login);
            db.SaveChanges();
        }

        public void Alterar(Models.TbLogin login)
        {
            Models.TbLogin antigo = db.TbLogin.FirstOrDefault(x => x.IdLogin == login.IdLogin);

            antigo.DsLogin = login.DsLogin; 

            db.SaveChanges();
        }

        public List<Models.TbLogin> ListarTodos()
        {
            List<Models.TbLogin> list = db.TbLogin.ToList();

            return list;
        }

        public Models.TbLogin BuscarPorID(int id)
        {
            Models.TbLogin login = db.TbLogin.FirstOrDefault(x => x.IdLogin == id);

            return login;
        }

        public void Deletar(int id)
        {
            Models.TbLogin login = db.TbLogin.FirstOrDefault(x => x.IdLogin == id);

            db.TbLogin.Remove(login);
            db.SaveChanges();
        }

        public void ResetarSenha(Models.TbLogin login)
        {
            Models.TbLogin antigo = db.TbLogin.FirstOrDefault(x => x.IdLogin == login.IdLogin);

            antigo.DsSenha = "1234";

            db.SaveChanges();
        }

        public Models.TbLogin VerificarSeExiste(Models.TbLogin login)
        {
            Models.TbLogin existe = db.TbLogin.FirstOrDefault(x => x.DsLogin == login.DsLogin);

            return existe;
        }
    }
}