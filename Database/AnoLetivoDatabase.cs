using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Vivencia19ManhaAPI.Models;

namespace Vivencia19ManhaAPI.Database
{
    public class AnoLetivoDatabase
    {
        Models.db_a5064d_freiContext db = new db_a5064d_freiContext();
        public void Inserir(TbAnoLetivo anoLetivo)
        {
            db.TbAnoLetivo.Add(anoLetivo);

            db.SaveChanges();
        }

        public void Alterar(TbAnoLetivo anoLetivo)
        {
            TbAnoLetivo alterar = db.TbAnoLetivo.FirstOrDefault(x => x.IdAnoLetivo == anoLetivo.IdAnoLetivo);

            alterar.DtInicio = anoLetivo.DtInicio;
            alterar.TpStatus = anoLetivo.TpStatus;
            alterar.BtAtivo = anoLetivo.BtAtivo;
            alterar.DtFim = anoLetivo.DtFim;
            alterar.NrAno = anoLetivo.NrAno;

            db.SaveChanges();
        }

        public void Deletar(int id)
        {
            TbAnoLetivo deletar = db.TbAnoLetivo.FirstOrDefault(x => x.IdAnoLetivo == id);

            db.TbAnoLetivo.Remove(deletar);

            db.SaveChanges();
        }
        
        public List<TbAnoLetivo> ConsultarTodos()
        {
            List<TbAnoLetivo> lista = db.TbAnoLetivo.OrderBy(x => x.NrAno).ToList();

            return lista;
        }

        public bool AnoExiste(int ano, int IdAnoLetivo)
        {
            return db.TbAnoLetivo.Any(x => x.NrAno == ano && x.IdAnoLetivo != IdAnoLetivo);
        }
    }
}