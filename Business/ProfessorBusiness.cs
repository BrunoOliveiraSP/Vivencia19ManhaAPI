using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Vivencia19ManhaAPI.Models;
using System.Globalization;

namespace Vivencia19ManhaAPI.Business
{   
    public class ProfessorBusiness
    {
        Database.ProfessorDatabase dbProfessor = new Database.ProfessorDatabase();
        Database.ProfessorDisciplinaDatabase dbProfessorDisciplina = new Database.ProfessorDisciplinaDatabase();
        Database.diciplinaDatabase dbDisciplina = new Database.diciplinaDatabase();
        Database.LoginDatabase dbLogin = new Database.LoginDatabase();

        public void Inserir(Models.ProfessorRequest request)
        {
            ValidarProfessor(request.Professor);  
            ValidarLogin(request.Login);
            if(request.Disciplina == null || request.Disciplina.Count == 0)
                throw new ArgumentException("Especifique as disciplinas do professor");
            
            dbLogin.Inserir(request.Login);

            request.Professor.IdLogin = request.Login.IdLogin;

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
                Models.TbLogin login = dbLogin.BuscarPorID(item.IdLogin);
                Models.ProfessorResponse resp = CriarResponse(item, login);
                response.Add(resp);
            }

            return response;
        }
        public List<Models.ProfessorResponse> ListarPorNome(string nome)
        {
            List<Models.TbProfessor> lista = dbProfessor.ConsultarPorNome(nome);

            List<Models.ProfessorResponse> response = new List<ProfessorResponse>();

            foreach(Models.TbProfessor item in lista)
            {
                Models.TbLogin login = dbLogin.BuscarPorID(item.IdLogin);
                Models.ProfessorResponse resp = CriarResponse(item, login);
                response.Add(resp);
            }

            return response;
        }

        public void Alterar(Models.ProfessorRequest request)
        {
            ValidarProfessor(request.Professor);
            ValidarLogin(request.Login);  

            if(request.Disciplina == null || request.Disciplina.Count == 0)
                throw new ArgumentException("Especifique as disciplinas do professor.");

            dbLogin.Alterar(request.Login);

            dbProfessor.Alterar(request.Professor);

            dbProfessorDisciplina.RemoverPorProfessor(request.Professor.IdProfessor);

            foreach(Models.TbDisciplina disciplina in request.Disciplina)
            {
                Models.TbProfessorDisciplina profdisc = new TbProfessorDisciplina();
                profdisc.IdDisciplina = disciplina.IdDisciplina;
                profdisc.IdProfessor = request.Professor.IdProfessor;

                dbProfessorDisciplina.Inserir(profdisc);
            }
        }

        public void Deletar(int id)
        {
            dbProfessorDisciplina.RemoverPorProfessor(id);
            dbProfessor.Deletar(id);
        }

        public void ResetarSenha(Models.TbLogin login)
        {
            dbLogin.ResetarSenha(login);
        }

        private Models.ProfessorResponse CriarResponse(Models.TbProfessor prof, Models.TbLogin login)
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
            
            response.Login = login;

            List<Models.TbDisciplina> disciplinas = new List<TbDisciplina>();

            foreach(Models.TbProfessorDisciplina item in prof.TbProfessorDisciplina)
            {
                Models.TbDisciplina disciplina = dbProfessorDisciplina.ListarPorIdDisciplina(item.IdDisciplina);
                disciplinas.Add(disciplina);
            }

            response.DisciplinaProfessor = disciplinas;

            List<Models.TbDisciplina> disponiveis = dbDisciplina.listar();

            foreach (Models.TbDisciplina item in response.DisciplinaProfessor)
            {
                Models.TbDisciplina disciplina = disponiveis.FirstOrDefault(x => x.IdDisciplina == item.IdDisciplina);
                disponiveis.Remove(disciplina);
            }

            response.DisciplinaDisponiveis = disponiveis;

            return response;
        }

        private void ValidarProfessor(Models.TbProfessor professor)
        {
            if(professor.NmProfessor == string.Empty)
                throw new ArgumentException("O campo Nomenão pode ser vazio.");

            if(professor.NmProfessor.Length < 3)
                throw new ArgumentException("O campo Nome não atingiu o número minimo de caracteres.");

            if(professor.NmMae == string.Empty)
                throw new ArgumentException("O campo Mãe não pode ser vazio.");

            if(professor.NmMae.Length < 3)
                throw new ArgumentException("O campo Mãe não atingiu o número minimo de caracteres.");

            if(professor.NmPai == string.Empty)
                throw new ArgumentException("O campo Pai não pode ser vazio.");   

            if(professor.NmPai.Length < 3)
                throw new ArgumentException("O campo Pai não atingiu o número minimo de caracteres."); 

             if(professor.DsCelular == "(  )      -")
                throw new ArgumentException("O campo Celular não pode ser vazio.");       

            if(professor.DsCpf == "   .   .   -")
                throw new ArgumentException("O campo CPF não pode ser vazio.");    

            if(professor.DsCpf.Length != 14)
                throw new ArgumentException("O campo CPF é inválido."); 

            if(professor.DsCurso == string.Empty)
                throw new ArgumentException("O campo Curso não pode ser vazio.");       

            if(professor.DsEmail == string.Empty)
                throw new ArgumentException("O campo E-mail não pode ser vazio."); 

            if(professor.DsEmail.Contains("@") == false || professor.DsEmail.Contains(".com") == false)   
                throw new ArgumentException("E-mail inválido.");

            if(professor.DsCvLattes == string.Empty)   
                throw new ArgumentException("O campo CV Lattes não pode ser vazio.");

            if(professor.DsCvLattes.Length < 3)   
                throw new ArgumentException("O campo CV Lattes não atingiu o número minimo de caracteres.");

            if(professor.DsEstado == string.Empty)
                throw new ArgumentException("O campo Estado não pode ser vazio.");

            if(professor.DsEstado.Length < 2)
                throw new ArgumentException("O campo Estado não atingiu o número minimo de caracteres.");

            if(professor.DsFaculdade == string.Empty)
                throw new ArgumentException("O campo Faculdade não pode ser vazio.");     

            if(professor.DsFaculdade.Length < 3)
                throw new ArgumentException("O campo Faculdade não atingiu o número minimo de caracteres.");   

            if(professor.DsRg == string.Empty)
                throw new ArgumentException("O campo RG não pode ser vazio.");     

            if(professor.DsRgEmissor == string.Empty)
                throw new ArgumentException("O campo RG Emissor não pode ser vazio.");     

            if(professor.DsRgOrgao == string.Empty)
                throw new ArgumentException("O campo RG Orgão não pode ser vazio.");     

            if(professor.DsTelefone == "(  )     -")
                throw new ArgumentException("O campo Telefone não pode ser vazio.");     

            if(professor.DtFaculdadeFim.Year < professor.DtFaculdadeInicio.Year + 2)
                throw new ArgumentException("O campo data de termino da Faculdade é inválido.");     

            if(professor.DtFaculdadeInicio == null)
                throw new ArgumentException("O campo data de inicio da Faculdade não pode ser vazio."); 

            if(professor.DtFaculdadeInicio == DateTime.Now.Date)
                throw new ArgumentException("O campo inicio da Faculdade não pode ser igual a data de hoje.");         

            if(professor.DtNascimento.Year >= DateTime.Now.Year - 14)
                throw new ArgumentException("A idade mínima do Professor não foi atingida.");   

            if(professor.NrAnoPrimeiroEmprego <= professor.DtNascimento.Year + 14)
                throw new ArgumentException("O campo de Primeiro emprego é inválido.");  

            if(professor.TpContratacao == "Selecione" || professor.TpContratacao == string.Empty)
                throw new ArgumentException("Escolha o tipo de contratação.");  
        }

        private void ValidarLogin(Models.TbLogin login)
        {
            Models.TbLogin existe = new Models.TbLogin();

            if(login.IdLogin != 0)
            {
                Models.TbLogin antigo = dbLogin.BuscarPorID(login.IdLogin);

                if(antigo .DsLogin != login.DsLogin)
                {
                    existe = dbLogin.VerificarSeExiste(login);

                    if(existe != null)
                        throw new ArgumentException("Login já existente, escolha outro.");
                }
            }
            else
            {
                existe = dbLogin.VerificarSeExiste(login);

                if(existe != null)
                    throw new ArgumentException("Login já existente, escolha outro.");
            }

            if(login.DsLogin.Length < 3)
                throw new ArgumentException("Login muito curto.");
        }
    }
}