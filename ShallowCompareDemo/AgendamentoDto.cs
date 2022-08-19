using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShallowCompareDemo
{
    public class AgendamentoDto
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int Nota { get; set; }
        public double Total { get; set; }
        public string Observacao { get; set; }
    }
}
