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


        public void Deconstruct(out int id, out DateTime inicio, out DateTime fim, out int nota, out double total, out string observacao, out bool ativo)
        {
            id = this.Id;
            inicio = this.Inicio;
            fim = this.Fim;
            nota = this.Nota;
            total = this.Total;
            observacao = this.Observacao;
            ativo = this.Ativo;
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
