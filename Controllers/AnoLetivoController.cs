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
    public class AnoLetivoController
    {
        Business.AnoLetivoBusiness business = new  Business.AnoLetivoBusiness();

        [HttpPost]
        public void Inserir(Models.TbAnoLetivo anoLetivo)
        {
            business.Inserir(anoLetivo);
        }

        [HttpPut]
        public void Alterar(Models.TbAnoLetivo anoLetivo)
        {
            business.Alterar(anoLetivo);
        }

        [HttpDelete("{id}")]
        public void Remover(int id)
        {
            business.Deletar(id);
        }

        [HttpGet]
        public List<Models.TbAnoLetivo> ConsultarTodos()
        {
            List<Models.TbAnoLetivo> lista = business.ConsultarTodos();

            return lista;
        }
    }
}