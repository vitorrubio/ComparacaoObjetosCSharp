# Exemplo de Shallow Compare ou Comparação Rasa

## Cenario
### Comparar se uma lista de objetos vindos de uma API ou Banco de Dados já contém um objeto "*SEMELHANTE*" a um objeto novo vindo de um formulário/tela/cadastro 
Para resolver esse problema você precisa saber se as propriedades, e apenas as propriedades do objeto são iguais. Você deve desprezar o Id, já que objetos do tipo Entidade tem sua "Identidade" (o Id) e ele vem preenchido do banco de dados, mas os objetos novos não tem o Id ou o mesmo é Zero.
Esse tipo de comparação, comparando apenas as propriedades é chamada de Shallow Compare ou Comparação Rasa.
Comparar as propriedades de um objeto mas não de suas listas ou objetos relacionados/internos pode ser feito manualmente ou de várias outras formas. Nós chamamos essa comparação rasa de Shallow Compare.
Comparar tudo, inclusive comparar recursivamente os objetos e coleções associados a um objeto chamamos de Deep Compare. 

### Problema: comparar se dois objetos do C# tem os mesmos valores
As vezes temos que comparar dois objetos para ver se são "iguais", mas o que é igualdade de objetos?
O exemplo e explicação que segue esse repo está em C# mas o conceito pode se aplicar também a Java e Delphi.
Como se compara dois objetos? Na maioria das linguagens orientadas a objetos as variáveis objetos são Tipos de Referência [(reference types)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types) e isso significa que na verdade elas são ponteiros: números inteiros de 4 bytes apontando pra algum lugar da memória. 
Então se você tem uma classe Agendamento e duas variáveis:

```
Agendamento a = new Agendamento();
Agendamento b = new Agendamento();
bool iguais = a == b;
Console.WriteLine(iguais); //false

```

Compará-los dessa maneira retornará false, por mais que suas propriedades sejam sempre iguais.
Usando o método Equals padrão também não funcionaria nesse contexto

```
Agendamento a = new Agendamento();
Agendamento b = new Agendamento();
bool iguais = a.Equals( b);
Console.WriteLine(iguais); //false

```

Tipos de Referência ou objetos funcionam assim: só são iguais quando duas variáveis apontam para a mesma instância (mesmo objeto)

```
Agendamento a;
Agendamento b;
a = b = new Agendamento();
bool iguais = a.Equals( b);
Console.WriteLine(iguais); //true
iguais = a == b;
Console.WriteLine(iguais); //true
```

## Então como comparar?
Uma das maneiras de fazer isso é comparando as propriedades uma a uma. 
Outra maneira é usando reflection para comparar as propriedades e fornecer uma lista de propriedades a ignorar. 
Também existem as possibilidades das novas versões do C# de se usar Record Types ou Destructurers + Tuples para a comparação. 
No tutorial a seguir faremos em uma classe estática separadamente métodos para comparar objetos manualmente ou usando reflection. 
Você pode colocar esse código na sua classe que deseja comparar, ou em classes utilitárias do seu projeto. 
Confira a solution ShallowCompareDemo.sln, suas classes e testes. A classe estática ComparadorDeObjetos tem métodos que testam a igualdade de objetos sob várias óticas. 

### Forma 1 - comparação direta

### Forma 2 - com reflection *
É possível também, via reflection, comparar se objetos de classes diferentes ou até de structs diferentes são iguais.

### Forma 3 - com destructurers + tuples
O C# moderno tem tuples (tuplas em português), que são conjuntos de dados estruturados sem necessariamente estarem orgnizados em um tipo customizado. É uma estrutura de dados semelhante a um registro em uma tabela de banco de dados, ou um struct do C#, mas com seus dados "soltos" ou "abertos".
Alguns tipos de dados, como DictionaryEntry, record e record struct, podem ser desconstruídos em forma de tuplas e comparados. Outros tipos, como classes e structs definidos pelo programador, não tem esse suporte nativo a desconstrutores, mas um desconstrutor pode ser criado.  
Criando desconstrutores para seus tipos no C# permite que você possa comparar dois objetos usando tuplas, permitindo também que algumas propriedades geradas por banco de dados ou calculadas (como Ids, totais etc) sejam ignoradas usando o operador de descarte "_".
Na prática a comparação usando desconstrutores é a mesma coisa que a prática comparando as propriedades manualmente, podendo ser até mais verbosa, pois envolve a criação das variáveis, desconstrução, criação das tuplas e comparação das mesmas, o que pode ser propenso a erros. É uma curosidade interessante mas eu não recomendo isso no código do dia a dia. 
Você pode ter desconstrutores com números de parâmetros diferentes, mas não pode ter dois desconstrutores com o mesmo número de parâmetros.

## Referencias

### Tuplas
- [Tuplas](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples)

### Desconstrutores
- [Desconstrutores](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/functional/deconstruct)