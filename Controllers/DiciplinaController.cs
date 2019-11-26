<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> d9fdf1b76d69c8a4d30c0b7c63121ed23d498fce
using Vivencia19ManhaAPI.Models;

namespace Vivencia19ManhaAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class DiciplinaController : ControllerBase
    {
<<<<<<< HEAD
        Business.DiciplinaBusiness busi = new Business.DiciplinaBusiness();

        //[HttpPost]
        //[]

        [HttpPut]
        [Route("Alterar")]
        public void Alterar(TbDisciplina disciplina)
        {
            busi.Alterar(disciplina);
        }
=======
    [ApiContrller]
    [Route("[Controller]")]
    public class DiciplinaController
    {
       
    } 
>>>>>>> d9fdf1b76d69c8a4d30c0b7c63121ed23d498fce
    }
}