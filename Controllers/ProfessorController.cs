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
    public class ProfessorController : ControllerBase
    {
       Business.ProfessorBusiness bussines = new Business.ProfessorBusiness();

        [HttpPost]
        public void Inserir(Models.TbProfessor professor)
        {
            bussines.Inserir(professor);
        }

        [HttpPut]
        public void Alterar(Models.TbProfessor professor)
        {

        }

        [HttpDelete]
        public void Deletar(Models.TbProfessor professor)
        {

        }

        [HttpGet]
        public List<Models.TbProfessor> LIstarTodos()
        {
             return bussines.ListarTodos();


        }

        
    }
}