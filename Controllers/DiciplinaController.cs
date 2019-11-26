using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivencia19ManhaAPI.Models;

namespace Vivencia19ManhaAPI.Controllers
{
    public class DiciplinaController
    {
    [ApiContrller]
    [Route("[Controller]")]
    public class DiciplinaController
    {
        [HttpDelete("{id}")]
        public void Remover(int id)
        {
            bus.Remover(id);
        }
    } 
    }
}