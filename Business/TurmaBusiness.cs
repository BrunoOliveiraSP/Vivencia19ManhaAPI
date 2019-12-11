using System;
using System.Collections.Generic;

namespace Vivencia19ManhaAPI.Business
{
    public class TurmaBusiness
    {
        Database.TurmaDatabase db = new Database.TurmaDatabase();

        public void InserirTurma(Models.TbTurma modelo)
        {
            if(modelo.IdAnoLetivo == 0)
            throw new ArgumentException("Impossível criar ou alterar uma turma sem antes selecionar um Ano Letivo");

            if(modelo.TpPeriodo == string.Empty || modelo.TpPeriodo == "Selecione")
            throw new ArgumentException("Selecione um período");
            
            if(modelo.NrCapacidadeMax == 0)
            throw new ArgumentException("Capacidade maxima dever ser preenchida");

            if(modelo.NmTurma == string.Empty)
            throw new ArgumentException("Nome da Turma invalido");

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
            response.NmCurso = turma.IdCursoNavigation.NmCurso;
            response.NrCapacidadeMax = turma.NrCapacidadeMax;
            response.TpPeriodo = turma.TpPeriodo;
            response.IdTurma = turma.IdTurma;
            response.NmTurma = turma.NmTurma;

            return response;
        }

        public void AlterarTurma(Models.TbTurma modelo)
        {
            if(modelo.IdAnoLetivo == 0)
            throw new ArgumentException("Impossível criar ou alterar uma turma sem antes selecionar um Ano Letivo");

            if(modelo.TpPeriodo == string.Empty || modelo.TpPeriodo == "Selecione")
            throw new ArgumentException("Selecione um período");

            if(modelo.IdTurma == 0)
            throw new ArgumentException("ID Inválido");

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