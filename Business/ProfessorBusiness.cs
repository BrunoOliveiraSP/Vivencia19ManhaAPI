using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Vivencia19ManhaAPI.Models;

namespace Vivencia19ManhaAPI.Business
{   
    public class ProfessorBusiness
    {
        Database.ProfessorDatabase db = new Database.ProfessorDatabase();

        public void Inserir(Models.TbProfessor professor)
        {
            if(professor.NmProfessor == string.Empty)
                throw new ArgumentException("Nome do professor Não pode ser vaziu");

            if(professor.NmMae == string.Empty)
                throw new ArgumentException("Nome da mãe Não pode ser vaziu");

            if(professor.NmPai == string.Empty)
                throw new ArgumentException("Nome do pai Não pode ser vaziu");   

             if(professor.DsCelular == null)
                throw new ArgumentException("O campo Celular Não pode ser vaziu");       

            if(professor.DsCpf == null)
                throw new ArgumentException("O campo CPF Não pode ser vaziu");     

            if(professor.DsCurso == string.Empty)
                throw new ArgumentException("O campo Curso Não pode ser vaziu");     

            // if(professor.DsCvLattes == null)
            //     throw new Exception("O Celular Não pode ser vaziu");     

            if(professor.DsEmail == string.Empty)
                throw new ArgumentException("O campo E-mail Não pode ser vaziu");     

            if(professor.DsEstado == string.Empty)
                throw new ArgumentException("O campo Estado Não pode ser vaziu");     

            if(professor.DsFaculdade == string.Empty)
                throw new ArgumentException("O campo Faculdade Não pode ser vaziu");     

            if(professor.DsRg == string.Empty)
                throw new ArgumentException("O campo RG Não pode ser vaziu");     

            if(professor.DsRgEmissor == string.Empty)
                throw new ArgumentException("O campo RG Emissor Não pode ser vaziu");     

            if(professor.DsRgOrgao == string.Empty)
                throw new ArgumentException("O campo RG Orgão Não pode ser vaziu");     

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone Não pode ser vaziu");     

            if(professor.DtFaculdadeFim == null)
                throw new ArgumentException("O campo Data de Termino da Faculdade Não pode ser vaziu");     

            if(professor.DtFaculdadeInicio == null)
                throw new ArgumentException("O campo Data de inicio da Faculdade Não pode ser vaziu"); 

            if(professor.DtFaculdadeInicio == DateTime.Now)
                throw new ArgumentException("O campo inicio da Faculdade Não pode ser igual a data de hoje");         

            if(professor.DtNascimento == DateTime.Now)
                throw new ArgumentException("O professor Não pode ter nascido agora");     

            if(professor.TpContratacao == string.Empty)
                throw new ArgumentException("O campo de Contratação Não pode ser vaziu"); 

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone Não pode ser vaziu");     

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone Não pode ser vaziu");     

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone Não pode ser vaziu");     

            db.Inserir(professor);
        }
       
        public void Deletar(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id Não informado ou igual a 0");

                db.Deletar(id);
        }

        public void Alterar(Models.TbProfessor professor)
        {
            if(professor.NmProfessor == string.Empty)
                throw new ArgumentException("Nome do professor Não pode ser vaziu");

            if(professor.NmMae == string.Empty)
                throw new ArgumentException("Nome da mãe Não pode ser vaziu");

            if(professor.NmPai == string.Empty)
                throw new ArgumentException("Nome do pai Não pode ser vaziu");   

             if(professor.DsCelular == null)
                throw new ArgumentException("O campo Celular Não pode ser vaziu");       

            if(professor.DsCpf == null)
                throw new ArgumentException("O campo CPF Não pode ser vaziu");     

            if(professor.DsCurso == string.Empty)
                throw new ArgumentException("O campo Curso Não pode ser vaziu");     

            // if(professor.DsCvLattes == null)
            //     throw new Exception("O Celular Não pode ser vaziu");     

            if(professor.DsEmail == string.Empty)
                throw new ArgumentException("O campo E-mail Não pode ser vaziu");     

            if(professor.DsEstado == string.Empty)
                throw new ArgumentException("O campo Estado Não pode ser vaziu");     

            if(professor.DsFaculdade == string.Empty)
                throw new ArgumentException("O campo Faculdade Não pode ser vaziu");     

            if(professor.DsRg == string.Empty)
                throw new ArgumentException("O campo RG Não pode ser vaziu");     

            if(professor.DsRgEmissor == string.Empty)
                throw new ArgumentException("O campo RG Emissor Não pode ser vaziu");     

            if(professor.DsRgOrgao == string.Empty)
                throw new ArgumentException("O campo RG Orgão Não pode ser vaziu");     

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone Não pode ser vaziu");     

            if(professor.DtFaculdadeFim == null)
                throw new ArgumentException("O campo Data de Termino da Faculdade Não pode ser vaziu");     

            if(professor.DtFaculdadeInicio == null)
                throw new ArgumentException("O campo Data de inicio da Faculdade Não pode ser vaziu"); 

            if(professor.DtFaculdadeInicio == DateTime.Now)
                throw new ArgumentException("O campo inicio da Faculdade Não pode ser igual a data de hoje");         

            if(professor.DtNascimento == DateTime.Now)
                throw new ArgumentException("O professor Não pode ter nascido agora");     

            if(professor.TpContratacao == string.Empty)
                throw new ArgumentException("O campo de Contratação Não pode ser vaziu"); 

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone Não pode ser vaziu");     

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone Não pode ser vaziu");     

            if(professor.DsTelefone == string.Empty)
                throw new ArgumentException("O campo Telefone Não pode ser vaziu");     



            db.Alterar(professor);
        }
        public List<Models.TbProfessor> ListarTodos()
        {
            List<Models.TbProfessor> lista = db.ListarTodos();
            return lista;
        }
        
	    public List<Models.TbProfessor> ConsultarPorNome(string nome)
	    {
		    List<Models.TbProfessor> list = db.ConsultarPorNome(nome);

		    return list;
    	}
    }
}