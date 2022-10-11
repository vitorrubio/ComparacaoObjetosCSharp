# Exemplo de Shallow Compare ou Compara��o Rasa

## Cenario
### Comparar se uma lista de objetos vindos de uma API ou Banco de Dados j� cont�m um objeto "*SEMELHANTE*" a um objeto novo vindo de um formul�rio/tela/cadastro 
Para resolver esse problema voc� precisa saber se as propriedades, e apenas as propriedades do objeto s�o iguais. Voc� deve desprezar o Id, j� que objetos do tipo Entidade tem sua "Identidade" (o Id) e ele vem preenchido do banco de dados, mas os objetos novos n�o tem o Id ou o mesmo � Zero.
Esse tipo de compara��o, comparando apenas as propriedades � chamada de Shallow Compare ou Compara��o Rasa.
Comparar as propriedades de um objeto mas n�o de suas listas ou objetos relacionados/internos pode ser feito manualmente ou de v�rias outras formas. N�s chamamos essa compara��o rasa de Shallow Compare.
Comparar tudo, inclusive comparar recursivamente os objetos e cole��es associados a um objeto chamamos de Deep Compare. 

### Problema: comparar se dois objetos do C# tem os mesmos valores
As vezes temos que comparar dois objetos para ver se s�o "iguais", mas o que � igualdade de objetos?
O exemplo e explica��o que segue esse repo est� em C# mas o conceito pode se aplicar tamb�m a Java e Delphi.
Como se compara dois objetos? Na maioria das linguagens orientadas a objetos as vari�veis objetos s�o Tipos de Refer�ncia [(reference types)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types) e isso significa que na verdade elas s�o ponteiros: n�meros inteiros de 4 bytes apontando pra algum lugar da mem�ria. 
Ent�o se voc� tem uma classe Agendamento e duas vari�veis:

```
Agendamento a = new Agendamento();
Agendamento b = new Agendamento();
bool iguais = a == b;
Console.WriteLine(iguais); //false

```

Compar�-los dessa maneira retornar� false, por mais que suas propriedades sejam sempre iguais.
Usando o m�todo Equals padr�o tamb�m n�o funcionaria nesse contexto

```
Agendamento a = new Agendamento();
Agendamento b = new Agendamento();
bool iguais = a.Equals( b);
Console.WriteLine(iguais); //false

```

Tipos de Refer�ncia ou objetos funcionam assim: s� s�o iguais quando duas vari�veis apontam para a mesma inst�ncia (mesmo objeto)

```
Agendamento a;
Agendamento b;
a = b = new Agendamento();
bool iguais = a.Equals( b);
Console.WriteLine(iguais); //true
iguais = a == b;
Console.WriteLine(iguais); //true
```

## Ent�o como comparar?
Uma das maneiras de fazer isso � comparando as propriedades uma a uma. 
Outra maneira � usando reflection para comparar as propriedades e fornecer uma lista de propriedades a ignorar. 
Tamb�m existem as possibilidades das novas vers�es do C# de se usar Record Types ou Destructurers + Tuples para a compara��o. 
No tutorial a seguir faremos em uma classe est�tica separadamente m�todos para comparar objetos manualmente ou usando reflection. 
Voc� pode colocar esse c�digo na sua classe que deseja comparar, ou em classes utilit�rias do seu projeto. 
Confira a solution ShallowCompareDemo.sln, suas classes e testes. A classe est�tica ComparadorDeObjetos tem m�todos que testam a igualdade de objetos sob v�rias �ticas. 

### Forma 1 - compara��o direta

### Forma 2 - com reflection *
� poss�vel tamb�m, via reflection, comparar se objetos de classes diferentes ou at� de structs diferentes s�o iguais.

### Forma 3 - com destructurers + tuples
O C# moderno tem tuples (tuplas em portugu�s), que s�o conjuntos de dados estruturados sem necessariamente estarem orgnizados em um tipo customizado. � uma estrutura de dados semelhante a um registro em uma tabela de banco de dados, ou um struct do C#, mas com seus dados "soltos" ou "abertos".
Alguns tipos de dados, como DictionaryEntry, record e record struct, podem ser desconstru�dos em forma de tuplas e comparados. Outros tipos, como classes e structs definidos pelo programador, n�o tem esse suporte nativo a desconstrutores, mas um desconstrutor pode ser criado.  
Criando desconstrutores para seus tipos no C# permite que voc� possa comparar dois objetos usando tuplas, permitindo tamb�m que algumas propriedades geradas por banco de dados ou calculadas (como Ids, totais etc) sejam ignoradas usando o operador de descarte "_".
Na pr�tica a compara��o usando desconstrutores � a mesma coisa que a pr�tica comparando as propriedades manualmente, podendo ser at� mais verbosa, pois envolve a cria��o das vari�veis, desconstru��o, cria��o das tuplas e compara��o das mesmas, o que pode ser propenso a erros. � uma curosidade interessante mas eu n�o recomendo isso no c�digo do dia a dia. 
Voc� pode ter desconstrutores com n�meros de par�metros diferentes, mas n�o pode ter dois desconstrutores com o mesmo n�mero de par�metros.

## Referencias

### Tuplas
- [Tuplas](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples)

### Desconstrutores
- [Desconstrutores](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/functional/deconstruct)