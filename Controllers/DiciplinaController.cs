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
        Business.DiciplinaBusiness busi = new Business.DiciplinaBusiness();

        [HttpPut("Alterar")]
        public void Alterar(TbDisciplina disciplina)
        {
            busi.Alterar(disciplina);
        }

        [HttpPost("Inserir")]
        public ActionResult<Models.TbDisciplina> Insert (Models.TbDisciplina livro)
        {
          try
          {
              busi.Inserir(livro);
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
          busi.Remover(id);
        }

        [HttpGet("ConsultarPorDisciplina/{nome}")]
        public List<Models.TbDisciplina> listarPorNome (string nome)
        {
         List<Models.TbDisciplina> list = busi.ListarPorNome(nome);
         return list;
        }

        [HttpGet("ConsultarTudo")]
        public List<Models.TbDisciplina> Listar()
        {
          List<Models.TbDisciplina> list = busi.Listar();
          return list;
        }

        [HttpGet("Sigla/{sigla}")]
        public List<Models.TbDisciplina> Listarporsigla(string sigla)
        {
                List<Models.TbDisciplina> Listarporsigla=busi.Listarporsigla(sigla);

                return Listarporsigla;
        }
    }
}