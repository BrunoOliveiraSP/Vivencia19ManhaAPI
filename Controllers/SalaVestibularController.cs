using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Vivencia19ManhaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaVestibularController : ControllerBase
    {
         Business.SalaVestibularBusiness business = new Business.SalaVestibularBusiness();

         [HttpPost]
         public ActionResult Inserir(Models.TbSalaVestibular modelo)
         {            
            try
            {
               business.Inserir(modelo);
               return Ok();
            }
            catch(System.ArgumentException ex)
            {
               Models.ErrorModel erro = new Models.ErrorModel(500,ex.Message);
               return StatusCode(500,erro);
            }
         }


         [HttpGet]
         public ActionResult<List<Models.SalaVestibularResponse1>> Consultar()
         {         
            
             try
            {
               return business.Consultar();
            }
            catch(System.ArgumentException ex)
            {
               Models.ErrorModel erro = new Models.ErrorModel(500,ex.Message);
               return StatusCode(500,erro);
            }
         }


          [HttpGet("{id}")]
         public ActionResult<Models.TbSalaVestibular> BuscarPorID(int id)
         {    
             try
            {
               return business.BuscarPorID(id);
            }
            catch(System.ArgumentException ex)
            {
               Models.ErrorModel erro = new Models.ErrorModel(500,ex.Message);
               return StatusCode(500,erro);
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
            catch(System.ArgumentException ex)
            {
               Models.ErrorModel erro = new Models.ErrorModel(500,ex.Message);
               return StatusCode(500,erro);
            }
         }


         [HttpPut]
         public ActionResult Alterar(Models.TbSalaVestibular modelo)
         {           
              try
            {
               business.Alterar(modelo);
               return Ok();
            }
            catch(System.ArgumentException ex)
            {
               Models.ErrorModel erro = new Models.ErrorModel(500,ex.Message);
               return StatusCode(500,erro);
            }
         }
    }
}