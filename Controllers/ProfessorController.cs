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
        public ActionResult<Models.ProfessorRequest> Inserir(Models.ProfessorRequest request)
        {
            try
            {
                bussines.Inserir(request);
                return request;    
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpGet]
        public ActionResult<List<Models.ProfessorResponse>> ListarTodos()
        {
            try
            {
                List<Models.ProfessorResponse> lista = bussines.ListarTodos();
                return lista;
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpGet("nome/{nome}")]
        public ActionResult<List<Models.ProfessorResponse>> ListarPorNome(string nome)
        {
            try
            {
                List<Models.ProfessorResponse> lista = bussines.ListarPorNome(nome);
                return lista;
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

         [HttpPut]
        public ActionResult<Models.ProfessorRequest> Alterar(Models.ProfessorRequest request)
        {
            try
            {
                bussines.Alterar(request);
                return request;    
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpPut("resetarsenha")]
        public ActionResult ResetarSenha(Models.TbLogin login)
        {
            try
            {
                bussines.ResetarSenha(login);
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
    }
}