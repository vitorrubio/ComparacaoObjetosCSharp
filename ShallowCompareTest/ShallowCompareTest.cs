using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShallowCompareDemo;
using System;

namespace ShallowCompareTest
{
    [TestClass]
    public class ShallowCompareTest
    {
        [TestMethod]
        public void ComparacaoDiretaDeveriaResultarFalse()
        {
            Agendamento a = new Agendamento();
            Agendamento b = new Agendamento();
            Assert.IsFalse(a == b);
            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void ComparacaoDeDuasVariaveisComMesmaInstanciaDeveResultarTrue()
        {
            Agendamento a;
            Agendamento b;
            a = b = new Agendamento();
            Assert.IsTrue(a == b);
            Assert.IsTrue(a.Equals(b));

            Assert.IsTrue(b == a);
            Assert.IsTrue(b.Equals(a));

            Assert.IsTrue(a == a);
            Assert.IsTrue(a.Equals(a));

            Assert.IsTrue(b == b);
            Assert.IsTrue(b.Equals(b));
        }

        [TestMethod]
        public void OperadorIgualdadeFuncionaComDatas()
        {
            var a = new DateTime(2022, 8, 19);
            var b = new DateTime(2022, 8, 19);
            Assert.IsTrue(a == b);
            Assert.IsTrue(b == a);
        }

        [TestMethod]
        public void OperadorIgualdadeNaoFuncionaComDatasBoxed()
        {
            object a = new DateTime(2022, 8, 19); //boxing: guardando um value type em um object
            object b = new DateTime(2022, 8, 19); //boxing: guardando um value type em um object
            Assert.IsFalse(a == b);
        }

        [TestMethod]
        public void DatasBoxedDevemSerComparadasComEquals()
        {
            object a = new DateTime(2022, 8, 19); //boxing: guardando um value type em um object
            object b = new DateTime(2022, 8, 19); //boxing: guardando um value type em um object
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
        }

        [TestMethod]
        public void ComparacaoManualObjetosDevemSerIguais()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1 };
            var b = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1 };

            Assert.IsTrue(ComparadorDeObjetos.SaoIguais(a, b));
            Assert.IsTrue(ComparadorDeObjetos.SaoIguais(b, a));
        }

        [TestMethod]
        public void ComparacaoManualObjetosDevemSerDiferentes()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1 };
            var b = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 4, Observacao = "teste", Total = 3.1 }; //nota diferente

            Assert.IsFalse(ComparadorDeObjetos.SaoIguais(a, b));
        }





        [TestMethod]
        public void ComparacaoComReflectionIgnorandoIdObjetosDevemSerIguais()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var b = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 1 };

            Assert.IsTrue(ComparadorDeObjetos.SaoIguaisUsandoReflection(a, b, "Id"));
            Assert.IsTrue(ComparadorDeObjetos.SaoIguaisUsandoReflection(b, a, "Id"));
        }

        [TestMethod]
        public void ComparacaoComReflectionSemIgnorarIdObjetosDevemSerDiferentes()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var b = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 1 };

            Assert.IsFalse(ComparadorDeObjetos.SaoIguaisUsandoReflection(a, b));
        }

        [TestMethod]
        public void ComparacaoComReflectionObjetosDevemSerDiferentes()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var b = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 4, Observacao = "teste", Total = 3.1, Id = 1 }; //nota diferente

            Assert.IsFalse(ComparadorDeObjetos.SaoIguaisUsandoReflection(a, b, "Id"));
        }








        [TestMethod]
        public void ComparacaoDeObjetosDeClassesDiferentesComReflectionIgnorandoIdObjetosDevemSerIguais()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var b = new AgendamentoDto { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1 };

            Assert.IsTrue(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(a, b, "Id", "PropriedadeNovaApenasDesseLado"));
            Assert.IsTrue(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(b, a, "Id", "PropriedadeNovaApenasDesseLado"));
        }


        [TestMethod]
        public void ComparacaoDeObjetosDeClassesDiferentesComReflectionObjetosDevemSerIguais_SemIgnorarId()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 1 };
            var b = new AgendamentoDto { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1 };

            Assert.IsTrue(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(a, b, "Id", "PropriedadeNovaApenasDesseLado"));
            Assert.IsTrue(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(b, a, "Id", "PropriedadeNovaApenasDesseLado"));
        }

        [TestMethod]
        public void ComparacaoDeObjetosDeClassesDiferentesComReflectionSemIgnorarIdObjetosDevemSerDiferentes()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var b = new AgendamentoDto { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 4, Observacao = "teste", Total = 3.1 }; //nota diferente, Id sempre será ignorado porque não tem dos dois lados

            Assert.IsFalse(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(a, b));
        }

        [TestMethod]
        public void ComparacaoDeObjetosDeClassesDiferentesComReflectionObjetosDevemSerDiferentes()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var b = new AgendamentoDto { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 4, Observacao = "teste", Total = 3.1 }; //nota diferente

            Assert.IsFalse(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(a, b, "Id"));
        }






        [TestMethod]
        public void StructsEquals()
        {
            var a = new AgendamentoStruct { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var b = new AgendamentoStruct { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));

        }


        [TestMethod]
        public void StructsNotEquals()
        {
            var a = new AgendamentoStruct { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var b = new AgendamentoStruct { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 4, Observacao = "teste", Total = 3.1, Id = 0 }; //nota diferente

            Assert.IsFalse(a.Equals(b));
            Assert.IsFalse(b.Equals(a));

        }




        [TestMethod]
        public void ComparacaoTiposDiferentesDeveSerIgual()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var b = new AgendamentoStruct { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var c = new AgendamentoDto { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1};

            Assert.IsTrue(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(a, b, "Id", "PropriedadeNovaApenasDesseLado"));
            Assert.IsTrue(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(b, c, "Id", "PropriedadeNovaApenasDesseLado"));
            Assert.IsTrue(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(c, a, "Id", "PropriedadeNovaApenasDesseLado"));
            Assert.IsTrue(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(c, b, "Id", "PropriedadeNovaApenasDesseLado"));
            Assert.IsTrue(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(b, a, "Id", "PropriedadeNovaApenasDesseLado"));
        }


        [TestMethod]
        public void ComparacaoTiposDiferentesComValoresDiferentesDeveSerDiferente()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var b = new AgendamentoStruct { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 4, Observacao = "teste", Total = 3.1, Id = 0 };//nota diferente
            var c = new AgendamentoDto { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 3, Observacao = "teste", Total = 3.1 };//nota diferente

            Assert.IsFalse(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(a, b, "Id", "PropriedadeNovaApenasDesseLado"));
            Assert.IsFalse(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(b, c, "Id", "PropriedadeNovaApenasDesseLado"));
            Assert.IsFalse(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(c, a, "Id", "PropriedadeNovaApenasDesseLado"));
            Assert.IsFalse(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(c, b, "Id", "PropriedadeNovaApenasDesseLado"));
            Assert.IsFalse(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(b, a, "Id", "PropriedadeNovaApenasDesseLado"));
        }




        [TestMethod]
        public void ComparacaoTiposDiferentesSemIgnorarPropriedadesDeveSerDiferente()
        {
            var a = new Agendamento { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var b = new AgendamentoStruct { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1, Id = 0 };
            var c = new AgendamentoDto { Ativo = true, Inicio = new DateTime(2022, 8, 19), Fim = new DateTime(2022, 8, 20), Nota = 5, Observacao = "teste", Total = 3.1 };

            //esses de fato são iguais 
            Assert.IsTrue(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(a, b));
            Assert.IsTrue(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(b, a));

            //diferentes por causa de propriedades diferentes
            Assert.IsFalse(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(b, c));
            Assert.IsFalse(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(c, a));
            Assert.IsFalse(ComparadorDeObjetos.ObjetosDiferentesSaoIguaisUsandoReflection(c, b));
            
        }
    }
}
