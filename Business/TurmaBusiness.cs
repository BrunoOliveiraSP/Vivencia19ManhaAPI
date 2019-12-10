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

        public List<Models.TurmaResponse> ConsultarTurmaPorAnoLetivo(int idAnoLetivo)
        {
             List<Models.TbTurma> lista = db.ConsultarTurmaPorAnoLetivo(idAnoLetivo);

             List<Models.TurmaResponse> response = new List<Models.TurmaResponse>();

            foreach(Models.TbTurma turma in lista)
            {
                Models.TurmaResponse r = this.CriarResponse(turma);
                response.Add(r);
            }

             return response;
        }

        private Models.TurmaResponse CriarResponse(Models.TbTurma turma)
        {
            Models.TurmaResponse response = new Models.TurmaResponse();
            response.IdTurma = turma.IdTurma;
            response.NmTurma = turma.NmTurma;
            response.NrCapacidadeMax = turma.NrCapacidadeMax;
            response.TpPeriodo = turma.TpPeriodo;
            response.NmCurso = turma.IdCursoNavigation.NmCurso;

            return response;
        }

        public void AlterarTurma(Models.TbTurma modelo)
        {
             if(modelo.IdTurma == 0)
            throw new ArgumentException("Id invalido");

            if(modelo.NmTurma == string.Empty)
            throw new ArgumentException("Nome da Turma invalido");

            if(modelo.TpPeriodo == string.Empty)
            throw new ArgumentException("unidade de tempo invalido");

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