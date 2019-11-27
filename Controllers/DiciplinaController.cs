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

        [HttpPut]
        [Route("Alterar")]
        public void Alterar(TbDisciplina disciplina)
        {
            busi.Alterar(disciplina);
        }
        [HttpPost]
         public void insert (Models.TbDisciplina livro)
        {
          
          busi.Inserir(livro);

        }
         [HttpDelete("{id}")]

        public void remover (int id)
        {
          busi.remover(id);
        }

         [HttpGet("{nome}")]
        public List<Models.TbDisciplina> lista (string nome)
        {
         
         List<Models.TbDisciplina> list = busi.listarPorNome(nome);
         return list;

        }


 
    }
}