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
        Database.ProfessorDatabase db = new Database.ProfessorDatabase();

        public void Inserir(Models.TbProfessor professor)
        {
            ValidarProfessor(professor);    
            db.Inserir(professor);
        }
       
        public void Deletar(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id não informado ou igual a 0");

                db.Deletar(id);
        }

        public void Alterar(Models.TbProfessor professor)
        {
            ValidarProfessor(professor);
            db.Alterar(professor);
        }
        public List<Models.TbProfessor> ListarTodos()
        {
            List<Models.TbProfessor> lista = db.ListarTodos();
            return lista;
        }
         public Models.TbProfessor ConsultarPotId(int Id)
        {
           return db.ConsultarPotId(Id);
            
        }

	    public List<Models.TbProfessor> ConsultarPorNome(string nome)
	    {
		    List<Models.TbProfessor> list = db.ConsultarPorNome(nome);

		    return list;
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