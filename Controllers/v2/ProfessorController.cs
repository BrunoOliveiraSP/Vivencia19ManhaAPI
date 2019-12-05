using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vivencia19ManhaAPI.Models;

namespace Vivencia19ManhaAPI.Controllers.v2
{
    [ApiController]
    [Route("v2/[controller]")]
    public class ProfessorController : ControllerBase
    {
        Business.v2.ProfessorBusiness bussines = new Business.v2.ProfessorBusiness();

        [HttpPost]
        public ActionResult<Models.ProfessorRequest> Inserir(Models.ProfessorRequest request)
        {
            try
            {
                bussines.Inserir(request);
                return request;    
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }

        [HttpGet]
        public ActionResult<List<Models.ProfessorResponse>> ListarTodos()
        {
            try
            {
                List<Models.ProfessorResponse> lista = bussines.ListarTodos();
                return lista;
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }
    }
}