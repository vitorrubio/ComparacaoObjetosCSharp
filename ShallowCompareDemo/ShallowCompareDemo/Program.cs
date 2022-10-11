using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShallowCompareDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TesteIgualdadeBasicoFalhando();
            TesteIgualdadeBasico();

            TestaDatas();

            TesteManual();
            TesteComReflection();
            TesteObjetoQualquerComReflection();

            TesteIgualdadeComTuplas();
            TesteDesigualdadeComTuplas();

            Console.ReadLine();
        }

        /// <summary>
        /// nesse método os objetos não são iguais
        /// </summary>
        static void TesteIgualdadeBasicoFalhando()
        {
            Console.WriteLine("Verificando se os objetos A e B são iguais (vai dar false)");
            Agendamento a = new Agendamento();
            Agendamento b = new Agendamento();
            bool iguais = a == b;
            Console.WriteLine(iguais); //false
            iguais = a.Equals(b);
            Console.WriteLine(iguais); //false
        }

        /// <summary>
        /// nesse método os objetos são iguais
        /// </summary>
        static void TesteIgualdadeBasico()
        {
            Console.WriteLine("Verificando se os objetos A e B são iguais (vai dar true)");
            Agendamento a;
            Agendamento b;
            a = b = new Agendamento();
            bool iguais = a == b;
            Console.WriteLine(iguais); //true
            iguais = a.Equals(b);
            Console.WriteLine(iguais); //true
        }


        static void TestaDatas()
        {
            var a = new DateTime(2022, 8, 19);
            var b = new DateTime(2022, 8, 19);

            Console.WriteLine("testando se duas datas 19/08/2022 são iguais com == ");
            Console.WriteLine(a == b);

            Console.WriteLine("testando se duas datas 19/08/2022 são iguais com .Equals ");
            Console.WriteLine(a.Equals(b));
        }


        static void TesteManual()
        {
            Console.WriteLine("Esses objetos devem ser iguais");
            Console.WriteLine(ComparadorDeObjetos.ComparacaoDireta(
                    new Agendamento {Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1 },
                    new Agendamento {Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1 }
                ));

            Console.WriteLine("Esses objetos devem ser diferentes, a nota está diferente");
            Console.WriteLine(ComparadorDeObjetos.ComparacaoDireta(
                    new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1 },
                    new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 4, Observacao = "teste", Total = 3.1 }
                ));
        }


        static void TesteComReflection()
        {
            Console.WriteLine("Esses objetos devem ser iguais, repare o Id diferente sendo ignorado");
            Console.WriteLine(ComparadorDeObjetos.ComparacaoReflection(
                    new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 1 },
                    new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 2 },
                    "Id"
                ));

            Console.WriteLine("Esses objetos devem ser diferentes, a nota está diferente, repare o Id diferente sendo ignorado");
            Console.WriteLine(ComparadorDeObjetos.ComparacaoReflection(
                    new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 1 },
                    new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 4, Observacao = "teste", Total = 3.1, Id = 2 },
                    "Id"
                ));
        }


        static void TesteObjetoQualquerComReflection()
        {
            Console.WriteLine("Esses objetos devem ser iguais, repare o Id diferente sendo ignorado e o AgendamentoDTO não tem Id");
            Console.WriteLine(ComparadorDeObjetos.ComparacaoTiposDiferentes(
                    new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 1 },
                    new AgendamentoDto { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1 },
                    "Id"
                ));

            Console.WriteLine("Esses objetos devem ser diferentes, a nota está diferente, repare o Id diferente sendo ignorado e o AgendamentoDTO não tem Id");
            Console.WriteLine(ComparadorDeObjetos.ComparacaoTiposDiferentes(
                    new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 1 },
                    new AgendamentoDto { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 4, Observacao = "teste", Total = 3.1 },
                    "Id"
                ));
        }


        static void TesteIgualdadeComTuplas()
        {
            DateTime inicio;
            DateTime fim; 
            int nota; 
            double total; 
            string observacao; 
            bool ativo;

            var agendamento = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 1 };
            (_, inicio, fim, nota, total, observacao, ativo) = agendamento;
            var t1 = (inicio, fim, nota, total, observacao, ativo);

            var agendamentoDto = new AgendamentoDto { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, PropriedadeExclusivaDoDto = false };
            (inicio, fim, nota, total, observacao, ativo, _) = agendamentoDto;
            var t2 = (inicio, fim, nota, total, observacao, ativo);

            var agendamentoStruct = new AgendamentoStruct { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 1 };
            (_, inicio, fim, nota, total, observacao, ativo) = agendamentoStruct;
            var t3 = (inicio, fim, nota, total, observacao, ativo);

            Console.WriteLine($"agendamento e agendamentoDto são iguais? { t1==t2 }");
            Console.WriteLine($"agendamento e agendamentoStruct são iguais? {t1 == t3}");
            Console.WriteLine($"agendamentoDto e agendamentoStruct são iguais? {t2  == t3}");
            Console.WriteLine("");
        }



        static void TesteDesigualdadeComTuplas()
        {
            DateTime inicio;
            DateTime fim;
            int nota;
            double total;
            string observacao;
            bool ativo;

            var agendamento = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 1 };
            (_, inicio, fim, nota, total, observacao, ativo) = agendamento;
            var t1 = (inicio, fim, nota, total, observacao, ativo);

            var agendamentoDto = new AgendamentoDto { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 6, Observacao = "teste", Total = 3.1, PropriedadeExclusivaDoDto = false };
            (inicio, fim, nota, total, observacao, ativo, _) = agendamentoDto;
            var t2 = (inicio, fim, nota, total, observacao, ativo);

            var agendamentoStruct = new AgendamentoStruct { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 7, Observacao = "teste", Total = 3.1, Id = 1 };
            (_, inicio, fim, nota, total, observacao, ativo) = agendamentoStruct;
            var t3 = (inicio, fim, nota, total, observacao, ativo);

            Console.WriteLine($"agendamento e agendamentoDto são iguais? {t1 == t2}");
            Console.WriteLine($"agendamento e agendamentoStruct são iguais? {t1 == t3}");
            Console.WriteLine($"agendamentoDto e agendamentoStruct são iguais? {t2 == t3}");
            Console.WriteLine("");
        }
    }
}
