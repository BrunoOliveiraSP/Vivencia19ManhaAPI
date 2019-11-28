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

        [HttpPut("Alterar")]//daORA /
        public void Alterar(TbDisciplina disciplina)
        {
            busi.Alterar(disciplina);
        }

        [HttpPost("Inserir")]//daORA
         public void insert (Models.TbDisciplina livro)
        {
          busi.Inserir(livro);
        }

        [HttpDelete("Remover/{id}")]//daORA
        public void remover (int id)
        {
          busi.remover(id);
        }

        [HttpGet("ConsultarPorDisciplina/{nome}")]//daORA
        public List<Models.TbDisciplina> listarPorNome (string nome)
        {
         List<Models.TbDisciplina> list = busi.listarPorNome(nome);
         return list;
        }

        [HttpGet("ConsultarTudo")]//daORA :)
        public List<Models.TbDisciplina> listar()
        {
          List<Models.TbDisciplina> list = busi.listar();
          return list;
        }

        [HttpGet("Sigla/{sigla}")]//daORA
        public List<Models.TbDisciplina> Listarporsigla(string sigla)
        {
                List<Models.TbDisciplina> Listarporsigla=busi.LIstarporsigla(sigla);

                return Listarporsigla;
        }
    }
}