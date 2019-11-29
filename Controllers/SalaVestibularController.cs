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
    public class SalaVestibularController
    {
         Business.SalaVestibularBusiness business = new Business.SalaVestibularBusiness();


         [HttpPost]
         public void Inserir(Models.TbSalaVestibular modelo)
         {
            business.Inserir(modelo);
         }


         [HttpGet]
         public List<Models.TbSalaVestibular> Consultar()
         {         
            return business.Consultar();
         }


          [HttpGet("{id}")]
         public Models.TbSalaVestibular BuscarPorID(int id)
         {
            return business.BuscarPorID(id);
         }


         [HttpDelete("{id}")]
         public void Remover(int id)
         {
            business.Deletar(id);
         }


         [HttpPut]
         public void Alterar(Models.TbSalaVestibular modelo)
         {
            business.Alterar(modelo);
         }
    }
}