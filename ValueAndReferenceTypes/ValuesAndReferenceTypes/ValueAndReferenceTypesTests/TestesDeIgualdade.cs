using ValuesAndReferenceTypes;

namespace ValueAndReferenceTypesTests
{
    [TestClass]
    public class TestesDeIgualdade
    {
        [TestMethod]
        public void ReferenceTypeEqualityTest()
        {

            UsuarioClasse uc1 = new UsuarioClasse { Id = 1, Nome = "João", DataNascimento = DateTime.Today };
            UsuarioClasse uc2 = new UsuarioClasse { Id = 1, Nome = "João", DataNascimento = DateTime.Today };
            Assert.IsFalse(uc1.Equals(uc2));
            Assert.IsFalse(uc2.Equals(uc1));
            Assert.IsFalse(uc1 == uc2);

        }


        [TestMethod]
        public void ValueTypeEqualityTest()
        {

            UsuarioStruct us1 = new UsuarioStruct { Id = 1, Nome = "João", DataNascimento = DateTime.Today };
            UsuarioStruct us2 = new UsuarioStruct { Id = 1, Nome = "João", DataNascimento = DateTime.Today };
            Assert.IsTrue(us1.Equals(us2));
            Assert.IsTrue(us2.Equals(us1));

        }


        [TestMethod]
        public void RecordTypeEqualityTest()
        {

            UsuarioRecord ur1 = new UsuarioRecord(1, "João", DateTime.Today);
            UsuarioRecord ur2 = new UsuarioRecord(1, "João", DateTime.Today);
            Assert.IsTrue(ur1.Equals(ur2));
            Assert.IsTrue(ur2.Equals(ur1));
            Assert.IsTrue(ur1 == ur2);

        }


        [TestMethod]
        public void RecordStructTypeEqualityTest()
        {

            UsuarioRecordStruct urs1 = new UsuarioRecordStruct(1, "João", DateTime.Today);
            UsuarioRecordStruct urs2 = new UsuarioRecordStruct(1, "João", DateTime.Today);
            Assert.IsTrue(urs1.Equals(urs2));
            Assert.IsTrue(urs2.Equals(urs1));
            Assert.IsTrue(urs1 == urs2);

        }
    }
}