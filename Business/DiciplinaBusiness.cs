namespace Vivencia19ManhaAPI.Business
{
    public class DiciplinaBusiness
    {
<<<<<<< HEAD
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
=======
        Models.Vivencia19ManhaAPI db = new Models.Vivencia19ManhaAPI();
        public void Deletar(int id)
        {
            if (id == 0)
                throw new exception("Id inválido");

                Deletar.Remover(id);
        }  
>>>>>>> d9fdf1b76d69c8a4d30c0b7c63121ed23d498fce
    }
}