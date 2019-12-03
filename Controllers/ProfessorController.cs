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
        public ActionResult Inserir(Models.TbProfessor professor)
        {
            try
            {
                bussines.Inserir(professor);
                return Ok();    
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpPut]
        public ActionResult Alterar(Models.TbProfessor professor)
        {
            try
            {
                bussines.Alterar(professor);
                return Ok();    
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            try
            {
                bussines.Deletar(id);
                return Ok();    
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpGet]
        public ActionResult<List<Models.TbProfessor>> ListarTodos()
        {
            try
            {
                List<Models.TbProfessor> lista = bussines.ListarTodos();
                return lista;
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }
        [HttpGet("{Id}")]

         public Models.TbProfessor ConsultarPotId(int Id)
        {
            return bussines.ConsultarPotId(Id);
        }


        [HttpGet("nome/{nome}")]
	    public ActionResult<List<Models.TbProfessor>> ConsultarPporNome(string nome)
	    {
            try
            {
                List<Models.TbProfessor> list = bussines.ConsultarPorNome(nome);
	    	    return list; 
                
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
	    }
    }
}