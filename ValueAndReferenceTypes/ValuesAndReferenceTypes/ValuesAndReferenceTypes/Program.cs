// See https://aka.ms/new-console-template for more information

using ValuesAndReferenceTypes;

UsuarioClasse uc1 = new UsuarioClasse { Id = 1, Nome = "João", DataNascimento = DateTime.Today };
UsuarioClasse uc2 = new UsuarioClasse { Id = 1, Nome = "João", DataNascimento = DateTime.Today };
Console.WriteLine($"Os itens UsuarioClasse são iguais com == ? {uc1 == uc2}");
Console.WriteLine($"Os itens UsuarioClasse são iguais com Equals ? {uc1.Equals(uc2)}");


UsuarioStruct us1 = new UsuarioStruct { Id = 1, Nome = "João", DataNascimento = DateTime.Today };
UsuarioStruct us2 = new UsuarioStruct { Id = 1, Nome = "João", DataNascimento = DateTime.Today };
//Console.WriteLine($"Os itens UsuarioStruct são iguais com == ? {us1 == us2}"); //não pode se não sobrecarregar  o operador
Console.WriteLine($"Os itens UsuarioStruct são iguais com Equals ? {us1.Equals(us2)}");



UsuarioRecord ur1 = new UsuarioRecord(1, "João", DateTime.Today);
UsuarioRecord ur2 = new UsuarioRecord(1, "João", DateTime.Today);
Console.WriteLine($"Os itens UsuarioRecord são iguais com == ? {ur1 == ur2}");
Console.WriteLine($"Os itens UsuarioRecord são iguais com Equals ? {ur1.Equals(ur2)}");


UsuarioRecordStruct urs1 = new UsuarioRecordStruct(1, "João", DateTime.Today);
UsuarioRecordStruct urs2 = new UsuarioRecordStruct(1, "João", DateTime.Today);
Console.WriteLine($"Os itens UsuarioRecordStruct são iguais com == ? {urs1 == urs2}");
Console.WriteLine($"Os itens UsuarioRecordStruct são iguais com Equals ? {urs1.Equals(urs2)}");


Console.ReadLine();

