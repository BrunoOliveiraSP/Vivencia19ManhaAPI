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
    public class AnoLetivoController : ControllerBase
    {
        Business.AnoLetivoBusiness business = new  Business.AnoLetivoBusiness();

        [HttpPost]
        public ActionResult Inserir(Models.TbAnoLetivo anoLetivo)
        {
            try
            {
                business.Inserir(anoLetivo);
                return Ok();    
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpPut]
        public ActionResult Alterar(Models.TbAnoLetivo anoLetivo)
        {
            try
            {
                business.Alterar(anoLetivo);
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
                business.Deletar(id);
                return Ok();    
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpGet]
        public ActionResult<List<Models.TbAnoLetivo>> ConsultarTodos()
        {
            try
            {
                List<Models.TbAnoLetivo> lista = business.ConsultarTodos();
                return lista;
            }
            catch(Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
            
        }
    }
}