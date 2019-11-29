using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Vivencia19ManhaAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        Business.CursoBusiness business = new Business.CursoBusiness();
        [HttpPost]
        public void InserirCurso(Models.TbCurso curso)
        {
            business.InserirCurso(curso);
        }
        
        [HttpPut]
        public void AlterarCurso(Models.TbCurso curso)
        {
            business.Alterar(curso);
        }
        [HttpDelete("{id}")]
        public void RemoverCurso(int id)
        {
            business.Remover(id);
        }
        [HttpGet]
        public List<Models.TbCurso> ConsultarCurso()
        {
            List<Models.TbCurso> consulta = business.Consultar();

            return consulta;
        }
        
        [HttpGet("{id}")]
        public List<Models.TbCurso> ConsultarPorId(int id)
        {
            List<Models.TbCurso> consulta = business.ConsultarPorID(id);

            return consulta;
        }
    }
}