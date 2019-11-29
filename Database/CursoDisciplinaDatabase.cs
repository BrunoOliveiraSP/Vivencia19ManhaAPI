using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Vivencia19ManhaAPI.Database
{
    public class CursoDisciplinaDatabase
    {
    Models.db_a5064d_freiContext db = new Models.db_a5064d_freiContext();

    public void Inserir(Models.TbCursoDisciplina cursoDisciplina)
    {
        db.TbCursoDisciplina.Add(cursoDisciplina);

        db.SaveChanges();
    }
    public bool ValidarIdDisciplina(Models.TbCursoDisciplina cursoDisciplina)
    {
        bool validar = db.TbCursoDisciplina.Any(x => x.IdDisciplina == cursoDisciplina.IdDisciplina);

        return validar;
    }

    public bool ValidarIdCurso(Models.TbCursoDisciplina cursoDisciplina)
    {
        bool validar = db.TbCursoDisciplina.Any(x => x.IdCurso == cursoDisciplina.IdCurso);

        return validar;
    }
    public void Deletar(int id)
    {
        Models.TbCursoDisciplina deletar = db.TbCursoDisciplina.FirstOrDefault(x => x.IdCursoDisciplina == id);
        db.Remove(deletar);

        db.SaveChanges();
    }
    public void Alterar(Models.TbCursoDisciplina cursoDisciplina)
    {
        Models.TbCursoDisciplina alterar = db.TbCursoDisciplina.FirstOrDefault(x => x.IdCursoDisciplina == cursoDisciplina.IdCursoDisciplina);
        alterar.IdCurso = cursoDisciplina.IdCurso;
        alterar.IdDisciplina = cursoDisciplina.IdDisciplina;        
        alterar.NrCargaHoraria = cursoDisciplina.NrCargaHoraria;

        db.SaveChanges();
    }

    public List<Models.TbCursoDisciplina> Consultar()
    {
        List<Models.TbCursoDisciplina> consulta = db.TbCursoDisciplina.ToList();

        return consulta;
    }
    public List<Models.TbCursoDisciplina> ConsultarPorId(int id)
    {
        List<Models.TbCursoDisciplina> consulta = db.TbCursoDisciplina.Where(x => x.IdCursoDisciplina == id).
                                                                            ToList();

        return consulta;
    }
    }
}