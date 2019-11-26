using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Vivencia19ManhaAPI.Models;
using System;

namespace Vivencia19ManhaAPI.Business
{
    public class AnoLetivoBusiness
    {
        Database.AnoLetivoDatabase database = new Database.AnoLetivoDatabase();
    
        public void Inserir(TbAnoLetivo anoLetivo)
        {
            if(anoLetivo.NrAno == 0)
            throw new ArgumentException("Ano Obrigatório");

            if(anoLetivo.DtFim <= anoLetivo.DtInicio)
            throw new ArgumentException("Data Final Inválida");

            if(anoLetivo.TpStatus == string.Empty)
            throw new ArgumentException("Status Obrigatório");

            database.Inserir(anoLetivo);
        }

        public void Alterar(TbAnoLetivo anoLetivo)
        {
            database.Alterar(anoLetivo);
        }

        public void Deletar(int id)
        {
            database.Deletar(id);
        }
        
        public List<TbAnoLetivo> ConsultarTodos()
        {
            List<TbAnoLetivo> lista = database.ConsultarTodos();

            return lista;
        }
    }
}