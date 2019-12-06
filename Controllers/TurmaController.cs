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
    public class TurmaController : ControllerBase
    {
        Business.TurmaBusiness business = new Business.TurmaBusiness();

        [HttpPost]
        public ActionResult InserirTurma(Models.TbTurma modelo)
        {
            try
            {
                business.InserirTurma(modelo);
                return Ok();    
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }
        [HttpGet]
         public ActionResult<List<Models.TbTurma>> ConsultarTurma()
        {
            try
            {
                List<Models.TbTurma> lista =  business.ConsultarTurma();
                return lista;    
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpPut]
        public ActionResult AlterarTurma(Models.TbTurma modelo)
        {
            try
            {
                business.AlterarTurma(modelo);
                return Ok();    
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }
        [HttpDelete("{id}")]
         public ActionResult RemoverTurma(int id)
        {
            try
            {
                business.RemoverTurma(id);
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