using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuesAndReferenceTypes
{
    public class UsuarioClasse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }

    public struct UsuarioStruct
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }

    //Novo no C# 9, é um reference type
    public record UsuarioRecord(int Id, string Nome, DateTime DataNascimento);

    //novo no C# 10, é um value type
    public record struct UsuarioRecordStruct(int Id, string Nome, DateTime DataNascimento);
}
