using System;
using System.Collections.Generic;

namespace Vivencia19ManhaAPI.Business
{
    public class TurmaBusiness
    {
        Database.TurmaDatabase db = new Database.TurmaDatabase();

         public void InserirTurma(Models.TbTurma modelo)
        {
           if(modelo.NmTurma == string.Empty)
            throw new ArgumentException("Nome da Turma invalido");

            if(modelo.TpPeriodo == string.Empty)
            throw new ArgumentException("unidade de tempo invalido");

            db.InserirTurma(modelo);
        }

        public List<Models.TbTurma> ConsultarTurma()
        {
             List<Models.TbTurma> lista = db.ConsultarTurma();
             return lista;
        }

        public void AlterarTurma(Models.TbTurma modelo)
        {
             if(modelo.IdTurma == 0)
            throw new ArgumentException("Id invalido");

            if(modelo.NmTurma == string.Empty)
            throw new ArgumentException("Nome da Turma invalido");

            if(modelo.TpPeriodo == string.Empty)
            throw new ArgumentException("unidade de tempo invalido");

            if(modelo.IdCurso == 0)
            throw new ArgumentException("Id invalido");

            if(modelo.NrCapacidadeMax == 0)
            throw new ArgumentException("Id invalido");

            db.AlterarTurma(modelo);
        }

        public void RemoverTurma(int id)
        {
            if(id == 0)
            throw new ArgumentException("Id invalido");

            db.RemoverTurma(id);
        }
    }
}