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
    public class TurmaController:ControllerBase
    {
        Business.TurmaBusiness business = new Business.TurmaBusiness();

        [HttpPost]
        public void InserirTurma(Models.TbTurma modelo)
        {
            business.InserirTurma(modelo);
        }
        [HttpGet]
         public List<Models.TbTurma> ConsultarTurma()
        {
           List<Models.TbTurma> lista =  business.ConsultarTurma(modelo);
           return lista;
        }
        [HttpPut]
        public void AlterarTurma(Models.TbTurma modelo)
        {
            business.AlterarTurma(modelo);
        }
        [HttpDelete]
         public void RemoverTurma(int id)
        {
            business.RemoverTurma(id);
        }
        

    }
    
     
    
    
}