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


    public class ProfessorDisciplinaController : ControllerBase
    {
        Business.ProfessorDisciplinaBusiness business = new Business.ProfessorDisciplinaBusiness();

        [HttpPost]

        public void Inserir(Models.TbProfessorDisciplina profdisc)
        {
            business.Inserir(profdisc);
        }

        [HttpDelete("{Id}")]
        public void Remover(int Id)
        {
            business.Remover(Id);
        }

        [HttpGet]

        public List<Models.TbProfessorDisciplina> ListarTodos()
        {
            return business.ListarTodos();
        }

        [HttpPut]
        public void Alterar(Models.TbProfessorDisciplina profdisc)
        {
            business.Alterar(profdisc);
        }

    }
}