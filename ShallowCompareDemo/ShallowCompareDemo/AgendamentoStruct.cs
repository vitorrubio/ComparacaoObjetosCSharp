using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShallowCompareDemo
{
    public struct AgendamentoStruct
    {
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int Nota { get; set; }
        public double Total { get; set; }
        public string Observacao { get; set; }
        public bool Ativo { get; set; }
    }
}
