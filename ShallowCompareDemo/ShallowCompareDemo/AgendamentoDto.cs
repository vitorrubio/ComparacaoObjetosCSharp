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
        public bool Ativo { get; set; }

        public bool PropriedadeExclusivaDoDto { get; set; }

        public void Deconstruct(out DateTime inicio, out DateTime fim, out int nota, out double total, out string observacao, out bool ativo, out bool propExclusivaDto)
        {
            inicio = this.Inicio;
            fim = this.Fim;
            nota = this.Nota;
            total = this.Total;
            observacao = this.Observacao;
            ativo = this.Ativo;
            propExclusivaDto = this.PropriedadeExclusivaDoDto;
        }

        public void Deconstruct(out DateTime inicio, out DateTime fim, out int nota, out double total, out string observacao, out bool ativo)
        {
            inicio = this.Inicio;
            fim = this.Fim;
            nota = this.Nota;
            total = this.Total;
            observacao = this.Observacao;
            ativo = this.Ativo;
        }
    }
}
