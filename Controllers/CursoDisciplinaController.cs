using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Vivencia19ManhaAPI.Controllers
{
    public class CursoDisciplinaController
    {
        Business.CursoDisciplinaBusiness business = new Business.CursoDisciplinaBusiness();

        [HttpPost]
        public void Inserir(Models.TbCursoDisciplina cursoDisciplina)
        {
            business.Inserir(cursoDisciplina);
        }
        
        [HttpPut]
        public void AlterarCurso(int id, Models.TbCursoDisciplina cursoDisciplina)
        {
            business.Alterar(id, cursoDisciplina);
        }
        [HttpDelete]
        public void RemoverCurso(int id)
        {
            business.Deletar(id);
        }
        [HttpGet]
        public List<Models.TbCursoDisciplina> Consultar()
        {
            List<Models.TbCursoDisciplina> consulta = business.Consultar();

            return consulta;
        }
        
        [HttpGet]
        public List<Models.TbCursoDisciplina> ConsultarPorId(int id)
        {
            List<Models.TbCursoDisciplina> consulta = business.ConsultarPorId(id);

            return consulta;
        }
    }
}