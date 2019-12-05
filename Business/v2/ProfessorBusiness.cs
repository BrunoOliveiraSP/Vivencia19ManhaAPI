using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Vivencia19ManhaAPI.Models;
using System.Globalization;

namespace Vivencia19ManhaAPI.Business.v2
{
    public class ProfessorBusiness
    {
        Database.ProfessorDatabase dbProfessor = new Database.ProfessorDatabase();
        Database.ProfessorDisciplinaDatabase dbProfessorDisciplina = new Database.ProfessorDisciplinaDatabase();

        public void Inserir(Models.ProfessorRequest request)
        {
            ValidarProfessor(request.Professor);  
            if(request.Disciplina == null)
                throw new ArgumentException("Especifique as disciplinas do professor");

            dbProfessor.Inserir(request.Professor);

            foreach(Models.TbDisciplina disciplina in request.Disciplina)
            {
                Models.TbProfessorDisciplina profdisc = new TbProfessorDisciplina();
                profdisc.IdDisciplina = disciplina.IdDisciplina;
                profdisc.IdProfessor = request.Professor.IdProfessor;

                dbProfessorDisciplina.Inserir(profdisc);
            }
        }

        public List<Models.ProfessorResponse> ListarTodos()
        {
            List<Models.TbProfessor> lista = dbProfessor.ListarTodos();

            List<Models.ProfessorResponse> response = new List<ProfessorResponse>();

            foreach(Models.TbProfessor item in lista)
            {
                Models.ProfessorResponse resp = CriarResponse(item);
                response.Add(resp);
            }

            return response;
        }

        public void Alterar(Models.ProfessorRequest request)
        {
            ValidarProfessor(request.Professor);  
            if(request.Disciplina == null)
                throw new ArgumentException("Especifique as disciplinas do professor");

            dbProfessor.Alterar(request.Professor);

            foreach(Models.TbDisciplina disciplina in request.Disciplina)
            {
                Models.TbProfessorDisciplina profdisc = new TbProfessorDisciplina();
                profdisc.IdDisciplina = disciplina.IdDisciplina;
                profdisc.IdProfessor = request.Professor.IdProfessor;

                dbProfessorDisciplina.Alterar(profdisc);
            }
        }

        private Models.ProfessorResponse CriarResponse(Models.TbProfessor prof)
        {
            Models.ProfessorResponse response = new Models.ProfessorResponse();
            response.DsCelular = prof.DsCelular;
            response.DsCpf = prof.DsCpf;
            response.DsCurso = prof.DsCurso;
            response.DsCvLattes = prof.DsCvLattes;
            response.DsEmail = prof.DsEmail;
            response.DsEstado = prof.DsEstado;
            response.DsFaculdade = prof.DsFaculdade;
            response.DsRg = prof.DsRg;
            response.DsRgEmissor = prof.DsRgEmissor;
            response.DsRgOrgao = prof.DsRgOrgao;
            response.DsTelefone = prof.DsTelefone;
            response.DtFaculdadeFim = prof.DtFaculdadeFim;
            response.DtFaculdadeInicio = prof.DtFaculdadeInicio;
            response.DtNascimento = prof.DtNascimento;
            response.IdLogin = prof.IdLogin;
            response.IdProfessor = prof.IdProfessor;
            response.NmMae = prof.NmMae;
            response.NmPai = prof.NmPai;
            response.NmProfessor = prof.NmProfessor;
            response.NrAnoPrimeiroEmprego = prof.NrAnoPrimeiroEmprego;
            response.TpContratacao = prof.TpContratacao;
            response.BtAtivo = prof.BtAtivo;

            List<Models.TbDisciplina> disciplinas = new List<TbDisciplina>();

            foreach(Models.TbProfessorDisciplina item in prof.TbProfessorDisciplina)
            {
                Models.TbDisciplina disciplina = dbProfessorDisciplina.ListarPorIdDisciplina(item.IdDisciplina);
                disciplinas.Add(disciplina);
            }

            response.Disciplina = disciplinas;

            return response;
        }

        private void ValidarProfessor(Models.TbProfessor professor)
        {
            if(professor.NmProfessor == string.Empty)
                throw new ArgumentException("Nome do professor não pode ser vazio");

            if(professor.NmProfessor.Length < 3)
                throw new ArgumentException("Nome do professor não atingiu o número minimo de caracteres");

            if(professor.NmMae == string.Empty)
                throw new ArgumentException("Nome da mãe não pode ser vazio");

            if(professor.NmMae.Length < 3)
                throw new ArgumentException("Nome da mãe não atingiu o número minimo de caracteres");

            if(professor.NmPai == string.Empty)
                throw new ArgumentException("Nome do pai não pode ser vazio");   

            if(professor.NmPai.Length < 3)
                throw new ArgumentException("Nome do pai não atingiu o número minimo de caracteres"); 

             if(professor.DsCelular == null)
                throw new ArgumentException("O campo Celular não pode ser vazio");       

            if(professor.DsCpf == null)
                throw new ArgumentException("O campo CPF não pode ser vazio");    

            if(professor.DsCpf.Length != 14)
                throw new ArgumentException("O campo CPF é inválido"); 

            if(professor.DsCurso == string.Empty)
                throw new ArgumentException("O campo Curso não pode ser vazio");       

            if(professor.DsEmail == string.Empty)
                throw new ArgumentException("O campo E-mail não pode ser vazio");     

            if(professor.DsEstado == string.Empty)
                throw new ArgumentException("O campo Estado não pode ser vazio");     

            if(professor.DsFaculdade == string.Empty)
                throw new ArgumentException("O campo Faculdade não pode ser vazio");     

            if(professor.DsFaculdade.Length < 3)
                throw new ArgumentException("O campo Faculdade não atingiu o número minimo de caracteres");   

            if(professor.DsRg == string.Empty)
                throw new ArgumentException("O campo RG não pode ser vazio");     

            if(professor.DsRg.Length < 9)
                throw new ArgumentException("O campo RG é inválido");  

            if(professor.DsRgEmissor == string.Empty)
                throw new ArgumentException("O campo RG Emissor não pode ser vazio");     

            if(professor.DsRgOrgao == string.Empty)
                throw new ArgumentException("O campo RG Orgão não pode ser vazio");     

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone não pode ser vazio");     

            if(professor.DtFaculdadeFim.Year < professor.DtFaculdadeInicio.Year + 2)
                throw new ArgumentException("O campo Data de Termino da Faculdade é inválido");     

            if(professor.DtFaculdadeInicio == null)
                throw new ArgumentException("O campo Data de inicio da Faculdade não pode ser vazio"); 

            if(professor.DtFaculdadeInicio == DateTime.Now.Date)
                throw new ArgumentException("O campo inicio da Faculdade não pode ser igual a data de hoje");         

            if(professor.DtNascimento.Year >= DateTime.Now.Year - 14)
                throw new ArgumentException("A idade minima não foi atingida");   

            if(professor.NrAnoPrimeiroEmprego <= professor.DtNascimento.Year + 14)
                throw new ArgumentException("O cammpo de Primeiro emprego é inválido");  

            if(professor.TpContratacao == string.Empty)
                throw new ArgumentException("O campo de Contratação não pode ser vazio"); 

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone não pode ser vazio");     

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone não pode ser vazio");     

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone não pode ser vazio"); 

            if(professor.DsEmail.Contains("@") == false && professor.DsEmail.Contains(".com") == false)
                throw new ArgumentException("O campo Email é inválido");
        }
    }
}