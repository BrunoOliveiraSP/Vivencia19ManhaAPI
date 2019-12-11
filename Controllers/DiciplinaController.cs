using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivencia19ManhaAPI.Models;

namespace Vivencia19ManhaAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class DiciplinaController : ControllerBase
    {
        Business.DiciplinaBusiness business = new Business.DiciplinaBusiness();

        [HttpPut("Alterar")]
        public void Alterar(TbDisciplina disciplina)
        {
            business.Alterar(disciplina);
        }

        [HttpPost("Inserir")]
        public ActionResult<Models.TbDisciplina> Insert (Models.TbDisciplina livro)
        {
          try
          {
              business.Inserir(livro);
              return livro;
          }
          catch(System.ArgumentException ex)
          {
              Models.ErrorModel erro = new Models.ErrorModel(500,ex.Message);
              return StatusCode(500,erro);
          }
        }

        [HttpDelete("Remover/{id}")]
        public void Remover (int id)
        {
          business.Remover(id);
        }

        [HttpGet("ConsultarPorDisciplina/{nome}")]
        public List<Models.TbDisciplina> ListarPorNome (string nome)
        {
         List<Models.TbDisciplina> list = business.ListarPorNome(nome);
         return list;
        }

        [HttpGet("ConsultarTudo")]
        public List<Models.TbDisciplina> Listar()
        {
          List<Models.TbDisciplina> list = business.Listar();
          return list;
        }

        [HttpGet("Sigla/{sigla}")]
        public List<Models.TbDisciplina> ListarPorsigla(string sigla)
        {
                List<Models.TbDisciplina> Listarporsigla = business.ListarPorsigla(sigla);

                return Listarporsigla;
        }

        [HttpGet("ListarDisciplina/{disciplina}/{sigla}")]
        public List<Models.TbDisciplina> ListarDisciplina(string disciplina, string sigla)
        {
                List<Models.TbDisciplina> ListarDisciplina = business.ListarDisciplina(disciplina, sigla);

                return ListarDisciplina;
        }
    }
}