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
         public void Inserir(Models.TbSala modelo)
         {
            business.Inserir(modelo);
         }


         [HttpGet]
         public List<Models.TbSala> Consultar()
         {         
            return business.Consultar();
         }


          [HttpGet("{id}")]
         public Models.TbSala BuscarPorID(int id)
         {
            return business.BuscarPorID(id);
         }


         [HttpDelete("{id}")]
         public void Remover(int id)
         {
            business.Deletar(id);
         }


         [HttpPut]
         public void Alterar(Models.TbSala modelo)
         {
            business.Alterar(modelo);
         }
    }
}