using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vivencia19ManhaAPI.Models;

namespace Vivencia19ManhaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
       Business.ProfessorBusiness bussines = new Business.ProfessorBusiness();

        [HttpPost]
        public void Inserir(Models.TbProfessor professor)
        {
            bussines.Inserir(professor);
        }

        [HttpPut]
        public void Alterar(Models.TbProfessor professor)
        {
            bussines.Alterar(professor);
        }

        [HttpDelete("{id}")]
        public void Remover(int id)
        {
            bussines.Deletar(id);
        }

        [HttpGet]
        public List<Models.TbProfessor> ListarTodos()
        {
             List<Models.TbProfessor> lista = bussines.ListarTodos();
            return lista;

        }

        [HttpGet("{nome}")]
	    public List<Models.TbProfessor> ConsultarPorNome(string nome)
	    {
	    	List<Models.TbProfessor> list = bussines.ConsultarPorNome(nome);

	    	return list;
	    }
    }
}