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
        
        [HttpGet("{nome}")]
        public List<Models.TbCurso> ConsultarPorId(string nome)
        {
            List<Models.TbCurso> consulta = business.ConsultarPorID(nome);

            return consulta;
        }

        [HttpGet("{sigla}")]
        public List<Models.TbCurso> ConsultarPorSigla(string sigla)
        {
            List<Models.TbCurso> consulta = business.ConsultarPorSigla(sigla);

            return consulta;
        }
    }
}