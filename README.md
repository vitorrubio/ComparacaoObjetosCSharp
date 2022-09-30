# Compara��o de Objetos em C#
Enquanto a compara��o de valores de vari�veis primitivas como inteiros ou strings e value types como bytes e chars pode ser f�cil, a compara��o de dois objetos em uma linguagem cmo C# � dif�cil.
Para entender a raz�o disso voc� precisa entender primeiro o que s�o objetos. Leia a se��o "O que s�o objetos". Se isso n�o for segredo para voc� pule para a se��o "Compara��o de Objetos".


## O que s�o objetos?
Quando voc� cria uma vari�vel "a" do tipo int, double, byte, char no C# voc� est� reservando um espa�o de mem�ria, dando o nome para ele e armazenando o valor ali. A vari�vel cont�m o pr�prio valor. 
Se voc� cria uma nova vari�vel "b" e atribui o valor de a, nesse momento voc� copiou o valor e as duas s�o iguais. 
Se voc� mudar o valor de "a" os dois valores passar�o a ser diferentes.
```
int a = 2; //a armazena 2, � o pr�prio valor
int b = a; //copio o valor de a em b
bool antes =  (a == b); //verdadeiro
a = 3; //mudo  o valor de a
bool depois =  (a == b); //falso
```

Com isso provamos que "a" e "b" n�o s�o a mesma "vari�vel", n�o est�o no mesmo lugar na mem�ria. 


Mas com objetos (reference types) a coisa � diferente.

Considere que voc� tem uma classe Usuario feita da seguinte maneira:
```
    public class UsuarioClasse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
```

E voc� cria *UM* objeto assim:

E voc� cria dois objetos id�nticos em suas propriedades:
```
    UsuarioClasse uc1 = new UsuarioClasse { Id = 1, Nome = "Jo�o", DataNascimento = DateTime.Today };
    UsuarioClasse uc2 = uc1;
```

Esses objetos s�o iguais? 
Se voc� chamar uc1 == uc2 ou uc1.Equals(uc2) ambos v�o ser verdadeiros

```
    Console.WriteLine($"Os itens s�o iguais com == ? {uc1 == uc2}");
    Console.WriteLine($"Os itens s�o iguais com .Equals ? {uc1.Equals(uc2)}");
```

Mas se voc� mudar uma propriedade de uc1, por exemplo uc1.Nome = "Jose", ainda assim os dois objetos ser�o iguais. E se verificar o valor de *uc2.Nome* ver� que o nome "mudou sozinho".

```
    uc1.Nome = "Jose";
    Console.WriteLine(uc2.Nome); //saiu "Jos�", mas n�o era "Jo�o" ?
    Console.WriteLine($"Os itens s�o iguais com == ? {uc1 == uc2}"); //verdadeiro
    Console.WriteLine($"Os itens s�o iguais com .Equals ? {uc1.Equals(uc2)}"); //verdadeiro    
```

Como voc� percebeu, diferentemente dos nossos inteiros "a" e "b", as vari�veis "uc1" e "uc2" s�o o *MESMO* objeto e n�o podem ser modificadas separadamente. 
Isso acontece porque um objeto � uma inst�ncia de uma classe na mem�ria, e as vari�veis "uc1" e "uc2" s�o refer�ncias que apontam para esse objeto. Ou seja, "uc1" e "uc2" s�o *PONTEIROS* e como elas apontam para o mesmo objeto, no mesmo lugar, voc� n�o tem dois objetos, voc� na verdade tem um �nico objeto com duas vari�veis apontando pra ele. 

E se voc� criar dois objetos id�nticos em suas propriedades, mas com inst�ncias diferentes?
```
    UsuarioClasse uc1 = new UsuarioClasse { Id = 1, Nome = "Jo�o", DataNascimento = DateTime.Today };
    UsuarioClasse uc2 = new UsuarioClasse { Id = 1, Nome = "Jo�o", DataNascimento = DateTime.Today };
```

A pergunta �: ser� que esses objetos s�o iguais? Como podemos compar�-los? 

```
    Console.WriteLine($"Os itens s�o iguais com == ? {uc1 == uc2}"); //falso
    Console.WriteLine($"Os itens s�o iguais com .Equals ? {uc1.Equals(uc2)}"); //falso
```

O m�todo Equals vai retornar true *se e somente se dois* objetos s�o exatamente a mesma inst�ncia. 

Como vimos, a compara��o desses dois objetos sempre vai ser falsa, apesar dos valores das propriedades serem iguais. Esses dois objetos s�o diferentes porque voc� de fato tem duas inst�ncias diferentes na mem�ria.

O .Net Framework vem com algumas solu��es padr�es para compara��o de alguns [objetos e estruturas](ValueAndReferenceTypes/readme.md). Voc� pode criar uma struct, record ou record struct, nesses tipos de dados a compara��o com == funciona. Lembrando que record � um reference type tamb�m, � um tipo especial de classe, enquanto structs e record structs s�o tipos estruturados (value types) semelhantes ao struct de C/C++ ou ao *record* do Pascal/Delphi.

Existe tamb�m a possibilidade de fazer o [override do .Equals e do operador ==](OverrideEquals/readme.md), ou de implementar a [interface IEquatable](IEquatableDemo/readme.md).

E por �ltimo, quando voc� precisa comparar as propriedades de objetos de tipos diferentes e ainda ignorar algumas propriedades (como Ids, que geralmente s�o gerados automaticamente pelo banco de dados), voc� pode criar alguma estrat�gia de [Shallow Compare](ShallowCompare/readme.md) ou compara��o rasa.



## Guia deste reposit�rio
- [objetos e estruturas](ValueAndReferenceTypes/readme.md)
- [override do .Equals e do operador ==](OverrideEquals/readme.md) (cuidado com o uso deste)
- [interface IEquatable](IEquatableDemo/readme.md)
- [Shallow Compare](ShallowCompare/readme.md) 



### Fontes
- [Reference Types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types)
- [Value Types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types)
- [Equality Comparisons](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/equality-comparisons)
- [value equality](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type)
- [Reference Types X Value Types](http://www.linhadecodigo.com.br/artigo/2238/reference-types-e-sua-diferenca-para-value-types-em-csharp.aspx)
- [Reference Types X Value Types](https://www.albahari.com/valuevsreftypes.aspx)
- [Deep Compare](https://www.cyotek.com/blog/comparing-the-properties-of-two-objects-via-reflection)
- [Deep Compare](https://devblog.cyotek.com/post/comparing-the-properties-of-two-objects-via-reflection)
- [How to compare two objects (testing for equality) in C#](https://grantwinney.com/how-to-compare-two-objects-testing-for-equality-in-c/)
- [Comparing object properties in c#](https://stackoverflow.com/questions/506096/comparing-object-properties-in-c-sharp)
