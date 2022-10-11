# Value Types e Reference Types
Em C# existem Value Types e Reference Types.
Value Types s�o tipos que s�o sempre passados por valor. Atribuir uma vari�vel a outra na pr�tica copia o seu valor, se for um tipo simples (int, byte) ou copia seus membros se for uma struct. 
Passar um value type como par�metro para um m�todo implica na c�pia do seu valor para esse par�metro.
Reference Types s�o sempre passados por refer�ncia. Objetos de classes s�o sempre reference types. Na pr�tica objetos s�o ponteiros que apontam para a �rea na mem�ria onde os dados do objeto est�o de verdde.
Atribuir uma vari�vel contendo um objeto para outra vari�vel *N�O* duplica o objeto. Na verdade voc� tem duas vari�veis apontando para o mesmo objeto, mas continua com um objeto s�. 
Passar uma vari�vel do tipo reference type como argumento para um m�todo resulta em passar uma refer�ncia para o pr�prio objeto, e ele pode ser modificado.
Outra diferen�a fundamental � com rela��o a �rea de mem�ria do programa que os tipos s�o guardados. Value Types s�o alocados na Stack, enquanto que Reference Types s�o guardados na Heap. 
Uma exce��o � regra s�o as Strings. Strings s�o Reference Types, mesmo assim se comportam como Value Types. Isso � feito para facilitar o seu uso pelo Dev. 
Alguns objetos s�o Reference Types mas podem ter alguns m�todos especiais, como [override do .Equals e do operador ==](./OverrideEquals/) para se comportarem como Value Types. Strings s�o esse tipo de objeto.

## Classes
- Objetos s�o inst�ncias de classes e s�o tipos de refer�ncia (reference types)

## Structs
- Vari�veis do tipo Struct s�o Value Types

## Records
- Records s�o tipos especiais de classes que j� tem o [override do .Equals e do operador ==](./OverrideEquals/)  feitos pelo compilador, sem a necessidade de ser feito pelo desenvolvedor. Isso garante que eles se comportem parcialmente como Value Types.

## Record Struct
- Tipos criados com as palavras chave `record` e `struct` ao mesmo tempo s�o tipos Value Types, alocados na Stack e ainda possuem o override do operador == j� feito pelo compilador. Assim estruturas mais complexas podem se comportar como um simples int ou byte e o operador == � v�lido para comparar duas vari�veis desse tipo. 


## Lembre-se
- atribuir, passar como argumento para um m�todo ou retornar de um m�todo um valor do tipo Value Type implica na c�pia do valor
- atribuir, passar como argumento ou retornar um Reference Type significa passar uma refer�ncia para o objeto na mem�ria
- Se um m�todo altera um Value Type o valor alterado s� � acess�vel dentro do m�todo.
- Se um m�todo altera um Reference Type o objeto original � alterado, e as altera��es podem ser vistas fora do m�todo.
- Strings s�o exce��es a regra: elas s�o Reference Types por defini��o, mas se comportam como Value Types
- Value Types s�o alocados na Stack.
- Reference Types s�o alocados na Heap.


## Fontes
- [Value types (C# reference)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types)
- [ValueType Class](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype?view=net-6.0)
- [Reference types (C# Reference)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types)
- [Types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types)

- [Reference Types X Value Types](http://www.linhadecodigo.com.br/artigo/2238/reference-types-e-sua-diferenca-para-value-types-em-csharp.aspx)
- [Reference Types X Value Types](https://www.albahari.com/valuevsreftypes.aspx)

- [Create record types](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records)
- [with expression (C# reference)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression)