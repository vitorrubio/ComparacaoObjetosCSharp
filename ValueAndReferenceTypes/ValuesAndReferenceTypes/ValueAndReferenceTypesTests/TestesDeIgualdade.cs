using ValuesAndReferenceTypes;

namespace ValueAndReferenceTypesTests
{
    [TestClass]
    public class TestesDeIgualdade
    {
        [TestMethod]
        public void ReferenceTypeEqualityTest()
        {

            UsuarioClasse uc1 = new UsuarioClasse { Id = 1, Nome = "Jo�o", DataNascimento = DateTime.Today };
            UsuarioClasse uc2 = new UsuarioClasse { Id = 1, Nome = "Jo�o", DataNascimento = DateTime.Today };
            Assert.IsFalse(uc1.Equals(uc2));
            Assert.IsFalse(uc2.Equals(uc1));
            Assert.IsFalse(uc1 == uc2);

        }


        [TestMethod]
        public void ValueTypeEqualityTest()
        {

            UsuarioStruct us1 = new UsuarioStruct { Id = 1, Nome = "Jo�o", DataNascimento = DateTime.Today };
            UsuarioStruct us2 = new UsuarioStruct { Id = 1, Nome = "Jo�o", DataNascimento = DateTime.Today };
            Assert.IsTrue(us1.Equals(us2));
            Assert.IsTrue(us2.Equals(us1));

        }


        [TestMethod]
        public void RecordTypeEqualityTest()
        {

            UsuarioRecord ur1 = new UsuarioRecord(1, "Jo�o", DateTime.Today);
            UsuarioRecord ur2 = new UsuarioRecord(1, "Jo�o", DateTime.Today);
            Assert.IsTrue(ur1.Equals(ur2));
            Assert.IsTrue(ur2.Equals(ur1));
            Assert.IsTrue(ur1 == ur2);

        }


        [TestMethod]
        public void RecordStructTypeEqualityTest()
        {

            UsuarioRecordStruct urs1 = new UsuarioRecordStruct(1, "Jo�o", DateTime.Today);
            UsuarioRecordStruct urs2 = new UsuarioRecordStruct(1, "Jo�o", DateTime.Today);
            Assert.IsTrue(urs1.Equals(urs2));
            Assert.IsTrue(urs2.Equals(urs1));
            Assert.IsTrue(urs1 == urs2);

        }

        [TestMethod]
        public void PassagemReferenceTypes()
        {
            //os dados de reference types podem ser mudados dentro de AlteraDados e refletem fora do m�todo
            UsuarioClasse uc1 = new UsuarioClasse { Id = 1, Nome = "Jo�o", DataNascimento = new DateTime(2000, 01, 01) };
            AlteraDados(uc1);
            Assert.AreNotEqual(1, uc1.Id);
            Assert.AreNotEqual("Jo�o", uc1.Nome);



            Pessoa p = new Pessoa { Id = 1, Nome = "Jo�o", DataNascimento = new DateTime(2000, 01, 01) };
            AlteraDados(p);
            Assert.AreNotEqual(1, p.Id);
            Assert.AreNotEqual("Jo�o", p.Nome);


            UsuarioRecord ur1 = new UsuarioRecord(1, "Jo�o", new DateTime(2000, 01, 01));
            AlteraDados(ur1);
            Assert.AreNotEqual(1, ur1.Id);
            Assert.AreNotEqual("Jo�o", ur1.Nome);

        }

        [TestMethod]
        public void PassagemValueTypes()
        {
            //os dados de Value Types n�o podem ser mudados dentro de AlteraDados porque o m�todo recebe uma c�pia, o que ele faz n�o pode ser acessado fora do m�todo
            UsuarioStruct us1 = new UsuarioStruct { Id = 1, Nome = "Jo�o", DataNascimento = new DateTime(2000, 01, 01) };
            AlteraDados(us1);
            Assert.AreEqual(1, us1.Id);
            Assert.AreEqual("Jo�o", us1.Nome);

            UsuarioRecordStruct urs1 = new UsuarioRecordStruct(1, "Jo�o", new DateTime(2000, 01, 01));
            AlteraDados(urs1);
            Assert.AreEqual(1, urs1.Id);
            Assert.AreEqual("Jo�o", urs1.Nome);


        }







        private void AlteraDados(UsuarioClasse u)
        {
            u.Id = 1000;
            u.Nome = "Maria";
            u.DataNascimento = DateTime.Now;
        }

        private void AlteraDados(UsuarioStruct u)
        {
            u.Id = 1000;
            u.Nome = "Maria";
            u.DataNascimento = DateTime.Now;
        }

        private void AlteraDados(UsuarioRecord u)
        {
            //impos�vel alterar diretamente porque os dados s�o imut�veis, init only
            /*
            u.Id = 1000;
            u.Nome = "Maria";
            u.DataNascimento = DateTime.Now;
            */


            //mudando com reflection
            u.GetType().GetProperties().FirstOrDefault(p => p.Name == "Nome").SetValue(u, "Maria");
            u.GetType().GetProperties().FirstOrDefault(p => p.Name == "Id").SetValue(u, 1000);

        }

        private void AlteraDados(Pessoa u)
        {
            u.Id = 1000;
            u.Nome = "Maria";
            u.DataNascimento = DateTime.Now;
        }

        private void AlteraDados(UsuarioRecordStruct u)
        {
            u.Id = 1000;
            u.Nome = "Maria";
            u.DataNascimento = DateTime.Now;
        }
    }
}