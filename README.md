# Comparação de Objetos em C#
Enquanto a comparação de valores de variáveis primitivas como inteiros ou strings e value types como bytes e chars pode ser fácil, a comparação de dois objetos em uma linguagem cmo C# é difícil.
Para entender a razão disso você precisa entender primeiro o que são objetos. Leia a seção "O que são objetos". Se isso não for segredo para você pule para a seção "Comparação de Objetos".


## O que são objetos?
Quando você cria uma variável "a" do tipo int, double, byte, char no C# você está reservando um espaço de memória, dando o nome para ele e armazenando o valor ali. A variável contém o próprio valor. 
Se você cria uma nova variável "b" e atribui o valor de a, nesse momento você copiou o valor e as duas são iguais. 
Se você mudar o valor de "a" os dois valores passarão a ser diferentes.
```
int a = 2; //a armazena 2, é o próprio valor
int b = a; //copio o valor de a em b
bool antes =  (a == b); //verdadeiro
a = 3; //mudo  o valor de a
bool depois =  (a == b); //falso
```

Com isso provamos que "a" e "b" não são a mesma "variável", não estão no mesmo lugar na memória. 


Mas com objetos (reference types) a coisa é diferente.

Considere que você tem uma classe Usuario feita da seguinte maneira:
```
    public class UsuarioClasse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
```

E você cria *UM* objeto assim:

E você cria dois objetos idênticos em suas propriedades:
```
    UsuarioClasse uc1 = new UsuarioClasse { Id = 1, Nome = "João", DataNascimento = DateTime.Today };
    UsuarioClasse uc2 = uc1;
```

Esses objetos são iguais? 
Se você chamar uc1 == uc2 ou uc1.Equals(uc2) ambos vão ser verdadeiros

```
    Console.WriteLine($"Os itens são iguais com == ? {uc1 == uc2}");
    Console.WriteLine($"Os itens são iguais com .Equals ? {uc1.Equals(uc2)}");
```

Mas se você mudar uma propriedade de uc1, por exemplo uc1.Nome = "Jose", ainda assim os dois objetos serão iguais. E se verificar o valor de *uc2.Nome* verá que o nome "mudou sozinho".

```
    uc1.Nome = "Jose";
    Console.WriteLine(uc2.Nome); //saiu "José", mas não era "João" ?
    Console.WriteLine($"Os itens são iguais com == ? {uc1 == uc2}"); //verdadeiro
    Console.WriteLine($"Os itens são iguais com .Equals ? {uc1.Equals(uc2)}"); //verdadeiro    
```

Como você percebeu, diferentemente dos nossos inteiros "a" e "b", as variáveis "uc1" e "uc2" são o *MESMO* objeto e não podem ser modificadas separadamente. 
Isso acontece porque um objeto é uma instância de uma classe na memória, e as variáveis "uc1" e "uc2" são referências que apontam para esse objeto. Ou seja, "uc1" e "uc2" são *PONTEIROS* e como elas apontam para o mesmo objeto, no mesmo lugar, você não tem dois objetos, você na verdade tem um único objeto com duas variáveis apontando pra ele. 

E se você criar dois objetos idênticos em suas propriedades, mas com instâncias diferentes?
```
    UsuarioClasse uc1 = new UsuarioClasse { Id = 1, Nome = "João", DataNascimento = DateTime.Today };
    UsuarioClasse uc2 = new UsuarioClasse { Id = 1, Nome = "João", DataNascimento = DateTime.Today };
```

A pergunta é: será que esses objetos são iguais? Como podemos compará-los? 

```
    Console.WriteLine($"Os itens são iguais com == ? {uc1 == uc2}"); //falso
    Console.WriteLine($"Os itens são iguais com .Equals ? {uc1.Equals(uc2)}"); //falso
```

O método Equals vai retornar true *se e somente se dois* objetos são exatamente a mesma instância. 

Como vimos, a comparação desses dois objetos sempre vai ser falsa, apesar dos valores das propriedades serem iguais. Esses dois objetos são diferentes porque você de fato tem duas instâncias diferentes na memória.

O .Net Framework vem com algumas soluções padrões para comparação de alguns [objetos e estruturas](ValueAndReferenceTypes/readme.md). Você pode criar uma struct, record ou record struct, nesses tipos de dados a comparação com == funciona. Lembrando que record é um reference type também, é um tipo especial de classe, enquanto structs e record structs são tipos estruturados (value types) semelhantes ao struct de C/C++ ou ao *record* do Pascal/Delphi.

Existe também a possibilidade de fazer o [override do .Equals e do operador ==](OverrideEquals/readme.md), ou de implementar a [interface IEquatable](IEquatableDemo/readme.md).

E por último, quando você precisa comparar as propriedades de objetos de tipos diferentes e ainda ignorar algumas propriedades (como Ids, que geralmente são gerados automaticamente pelo banco de dados), você pode criar alguma estratégia de [Shallow Compare](ShallowCompare/readme.md) ou comparação rasa.



## Guia deste repositório
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
