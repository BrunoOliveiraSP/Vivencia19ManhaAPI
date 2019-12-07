using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Vivencia19ManhaAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        Business.CursoBusiness business = new Business.CursoBusiness();
        [HttpPost]
        public ActionResult InserirCurso(Models.TbCurso curso)
        {
            try
            {
            business.InserirCurso(curso);
            return Ok();
            }
            catch (System.Exception ex)
            {
                Models.ErrorModel erro = new Models.ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }
        
        [HttpPut]
        public ActionResult AlterarCurso(Models.TbCurso curso)
        {
           try
           {
                business.Alterar(curso);
                return Ok();
           }
           catch(System.Exception ex)
           {
               Models.ErrorModel erro = new Models.ErrorModel(500, ex.Message);
               return StatusCode(500, erro);
           }
        }
        [HttpDelete("{id}")]
        public ActionResult RemoverCurso(int id)
        {
            try
            {
            business.Remover(id);
            return Ok();
            }

            catch(System.Exception ex)
            {
                Models.ErrorModel erro = new Models.ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }
        
        
        [HttpGet]
        public ActionResult<List<Models.TbCurso>> ConsultarCurso()
        {
            try
            {
            List<Models.TbCurso> consulta = business.Consultar();

            return consulta;
            }
            catch(System.Exception ex)
            {
                Models.ErrorModel erro = new Models.ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }
        
        [HttpGet("ConsultarPorNome/{nome}")]
        public ActionResult<List<Models.TbCurso>> ConsultarPorNome(string nome)
        {
            try
            {
            List<Models.TbCurso> consulta = business.ConsultarPorNome(nome);

            return consulta;
            }
            catch(System.Exception ex)
            {
                Models.ErrorModel erro = new Models.ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpGet("ConsultarPorSigla/{sigla}")]
        public ActionResult<List<Models.TbCurso>> ConsultarPorSigla(string sigla)
        {
            try{
            List<Models.TbCurso> consulta = business.ConsultarPorSigla(sigla);

            return consulta;
            }
            catch(System.Exception ex)
            {
                Models.ErrorModel erro = new Models.ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }
    }
}