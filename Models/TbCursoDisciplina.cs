using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vivencia19ManhaAPI.Models
{
    [Table("tb_curso_disciplina")]
    public partial class TbCursoDisciplina
    {
        [Key]
        [Column("id_curso_disciplina", TypeName = "int(11)")]
        public int IdCursoDisciplina { get; set; }
        [Column("id_curso", TypeName = "int(11)")]
        public int IdCurso { get; set; }
        [Column("id_disciplina", TypeName = "int(11)")]
        public int IdDisciplina { get; set; }
        [Column("nr_carga_horaria", TypeName = "int(11)")]
        public int NrCargaHoraria { get; set; }

        
        [InverseProperty(nameof(TbCurso.TbCursoDisciplina))]
        public virtual TbCurso IdCursoNavigation { get; set; }
        
        [InverseProperty(nameof(TbDisciplina.TbCursoDisciplina))]
        public virtual TbDisciplina IdDisciplinaNavigation { get; set; }
    }
}
