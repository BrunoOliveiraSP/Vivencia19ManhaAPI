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

    
    public class SalaController : ControllerBase
    {
      Business.SalaBusiness business = new Business.SalaBusiness();


         [HttpPost]
         public ActionResult Inserir(Models.TbSala modelo)
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
         public ActionResult<List<Models.TbSala>> Consultar()
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
         public ActionResult<Models.TbSala> BuscarPorID(int id)
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
          [HttpGet("Buscar/{nome}")]
         public ActionResult<List<Models.TbSala>> BuscarPorInstituicao(string nome)
         {     
             try
            {
               return business.ConsultarPorInstituicao(nome);
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
         public ActionResult Alterar(Models.TbSala modelo)
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