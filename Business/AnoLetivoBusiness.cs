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
            bool anoExiste = database.AnoExiste(anoLetivo.NrAno, anoLetivo.IdAnoLetivo);

            if(anoLetivo.DtInicio.Year != anoLetivo.NrAno)
            throw new ArgumentException("Ano da data de Inicio é diferente de Ano!");

            if(anoLetivo.DtFim.Year != anoLetivo.NrAno)
            throw new ArgumentException("Ano da data Fim é diferente de Ano!");

            if(anoLetivo.DtFim <= anoLetivo.DtInicio)
            throw new ArgumentException("Data Final Inválida!");

            if(anoLetivo.TpStatus == string.Empty)
            throw new ArgumentException("Status Obrigatório!");

            if(anoLetivo.NrAno == 0)
            throw new ArgumentException("Ano Obrigatório!");

            if(anoExiste == true)
            throw new ArgumentException("Ano já existe!");

            database.Inserir(anoLetivo);
        }

        public void Alterar(TbAnoLetivo anoLetivo)
        {
            bool anoExiste = database.AnoExiste(anoLetivo.NrAno, anoLetivo.IdAnoLetivo);

            if(anoLetivo.DtInicio.Year != anoLetivo.NrAno)
            throw new ArgumentException("Ano da data de Inicio é diferente de Ano!");

            if(anoLetivo.DtFim.Year != anoLetivo.NrAno)
            throw new ArgumentException("Ano da data Fim é diferente de Ano!");

            if(anoLetivo.DtFim <= anoLetivo.DtInicio)
            throw new ArgumentException("Data Final Inválida!");

            if(anoLetivo.TpStatus == string.Empty)
            throw new ArgumentException("Status Obrigatório!");

            if(anoLetivo.NrAno == 0)
            throw new ArgumentException("Ano Obrigatório!");

            if(anoExiste == true)
            throw new ArgumentException("Ano já existe!");

            if(anoLetivo.IdAnoLetivo == 0)
            throw new ArgumentException("ID Inválido!");

            database.Alterar(anoLetivo);
        }

        public void Deletar(int id)
        {
            if(id == 0)
            throw new ArgumentException("ID Inválido!");
            
            database.Deletar(id);
        }
        
        public List<TbAnoLetivo> ConsultarTodos()
        {
            List<TbAnoLetivo> lista = database.ConsultarTodos();

            return lista;
        }
    }
}