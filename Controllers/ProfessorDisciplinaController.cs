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


    public class ProfessorDisciplinaController : ControllerBase
    {
        Business.ProfessorDisciplinaBusiness business = new Business.ProfessorDisciplinaBusiness();

        [HttpPost]
        public ActionResult Inserir(List<Models.ProfessorRequest> request)
        {
            try
            {
                business.Inserir(request);
                return Ok();
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult Remover(int Id)
        {
            try
            {
                business.Remover(Id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpGet]
        public ActionResult<List<Models.TbProfessorDisciplina>> ListarTodos()
        {
            try
            {
                List<Models.TbProfessorDisciplina> list = business.ListarTodos(); 
                return list;
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpPut]
        public ActionResult Alterar(Models.TbProfessorDisciplina profdisc)
        {
            try
            {
                business.Alterar(profdisc);
                return Ok();
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpGet("idprofessor/{Id}")]
        public ActionResult<List<Models.TbProfessorDisciplina>> ListarPorIdProfessor(int id)
        {
            try
            {
                List<Models.TbProfessorDisciplina> list = business.ListarTodos(); 
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