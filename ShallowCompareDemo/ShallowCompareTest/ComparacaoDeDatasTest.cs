using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShallowCompareDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShallowCompareTest
{
    [TestClass]
    public class ComparacaoDeDatasTest
    {

        List<Agendamento> _agendamentos = new List<Agendamento>();

        [TestInitialize]
        public void Initialize()
        {
            _agendamentos = new List<Agendamento>()
            {
                new Agendamento {Inicio = new DateTime(2022, 8, 24, 0, 0, 0,0, DateTimeKind.Unspecified) },
                new Agendamento {Inicio = new DateTime(2022, 8, 24, 0, 0, 0,0, DateTimeKind.Unspecified) },
                new Agendamento {Inicio = new DateTime(2022, 8, 25, 0, 0, 0,0, DateTimeKind.Unspecified) },
                new Agendamento {Inicio = new DateTime(2022, 8, 25, 0, 0, 0,0, DateTimeKind.Unspecified) },
                new Agendamento {Inicio = new DateTime(2022, 8, 26, 0, 0, 0,0, DateTimeKind.Unspecified) },
                new Agendamento {Inicio = new DateTime(2022, 8, 26, 0, 0, 0,0, DateTimeKind.Unspecified) },
            };
        }

        [TestMethod]
        public void FiltroDataUtcTest()
        {
            var data = new DateTime(2022, 08, 25, 0, 0, 0, DateTimeKind.Utc);
            Assert.IsFalse(_agendamentos.Any(a => a.Inicio == data), "as datas não são diferentes"); //deveria não encontrar nada e ser diferente
            Assert.IsFalse(_agendamentos[2].Inicio == data, "as datas não são diferentes");

        }


        [TestMethod]
        public void FiltroDataLocalTest()
        {
            var data = new DateTime(2022, 08, 25, 0, 0, 0, DateTimeKind.Local);
            Assert.IsTrue(_agendamentos.Any(a => a.Inicio == data), "as datas são diferentes"); //deveria passar sem dar erro
            Assert.IsTrue(_agendamentos[2].Inicio == data, "as datas são diferentes");
        }

        [TestMethod]
        public void FiltroDataNaoEspecificadaTest()
        {
            var data = new DateTime(2022, 08, 25, 0, 0, 0, DateTimeKind.Unspecified);
            Assert.IsTrue(_agendamentos.Any(a => a.Inicio == data), "as datas são diferentes"); //deveria passar sem dar erro
            Assert.IsTrue(_agendamentos[2].Inicio == data, "as datas são diferentes");
        }




        [TestMethod]
        public void FiltroComparandoDateInternoTest()
        {
            var data = new DateTime(2022, 08, 25, 0, 0, 0, DateTimeKind.Utc);
            Assert.IsTrue(_agendamentos.Any(a => a.Inicio == data.Date), "as datas deveriam ser iguais aqui");
            Assert.IsTrue(_agendamentos[2].Inicio == data, "as datas deveriam ser iguais aqui");
        }


        [TestMethod]
        public void FiltroDesmontandoTest()
        {
            var data = new DateTime(2022, 08, 25, 0, 0, 0, DateTimeKind.Utc);
            data = new DateTime(data.Year, data.Month, data.Day);

            Assert.IsTrue(_agendamentos.Any(a => a.Inicio == data.Date), "as datas deveriam ser iguais aqui");
            Assert.IsTrue(_agendamentos[2].Inicio == data, "as datas deveriam ser iguais aqui");
        }

    }
}
