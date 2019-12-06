using System;

namespace Vivencia19ManhaAPI.Models
{
    public class TurmaResponse
    {
        public int IdTurma { get; set; }
        public int IdCurso { get; set; }
        public int IdAnoLetivo { get; set; }
        public string NmTurma { get; set; }
        public string TpPeriodo { get; set; }
        public int NrCapacidadeMax { get; set; }

        public int NrAno { get; set; }

        public string NmCurso { get; set; }
    }
}