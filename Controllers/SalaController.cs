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


     [HttpPost]
     public void Inserir(Models.TbSala modelo)
     {
        Database.SalaDatabase db = new Database.SalaDatabase();
        db.Inserir(modelo);
     }
     [HttpGet]
     public List<Models.TbSala> Consultar()
     {
        Database.SalaDatabase db = new Database.SalaDatabase();
        return db.Consultar();
     }
    }
}