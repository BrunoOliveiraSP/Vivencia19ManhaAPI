using System;

namespace Vivencia19ManhaAPI.Business
{
    public class DiciplinaBusiness
    {
        Database.diciplinaDatabase db = new Database.diciplinaDatabase();
        internal void Inserir(Models.TbDisciplina disciplina)
        {
            if(Verificar(disciplina))
                db.InserirDisciplina(disciplina);
        }

        internal void Alterar(Models.TbDisciplina disciplina)
        {
            if(Verificar(disciplina))
                db.Alterar(disciplina);
        }

        public bool Verificar(Models.TbDisciplina disciplina)
        {
            //if(disciplina.BtAtivo == 0)
            //    return false;
            if(string.IsNullOrEmpty(disciplina.DsSigla))
                return false;
            if(string.IsNullOrEmpty(disciplina.DtInclusao.ToString()))
                return false;
            if(string.IsNullOrEmpty(disciplina.NmDisciplina))
                return false;
            if(disciplina.IdFuncionarioAlteracao == 0)
                return false;
            return true;
        }

        ///public List<Models.TbDisciplina> lista ()
        //{
           

           // return db.lista();
        //}  

    }
}