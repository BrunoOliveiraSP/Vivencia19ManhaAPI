using System;
using System.Collections;
using System.Collections.Generic;

namespace Vivencia19ManhaAPI.Models
{
    public class ProfessorRequest
    {
        public TbProfessor Professor { get; set;}

        public List<TbDisciplina> Disciplina { get; set; }
    }
}