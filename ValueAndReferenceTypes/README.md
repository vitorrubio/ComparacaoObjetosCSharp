# Value Types e Reference Types
Em C# existem Value Types e Reference Types.
Value Types são tipos que são sempre passados por valor. Atribuir uma variável a outra na prática copia o seu valor, se for um tipo simples (int, byte) ou copia seus membros se for uma struct. 
Passar um value type como parâmetro para um método implica na cópia do seu valor para esse parâmetro.
Reference Types são sempre passados por referência. Objetos de classes são sempre reference types. Na prática objetos são ponteiros que apontam para a área na memória onde os dados do objeto estão de verdde.
Atribuir uma variável contendo um objeto para outra variável *NÃO* duplica o objeto. Na verdade você tem duas variáveis apontando para o mesmo objeto, mas continua com um objeto só. 
Passar uma variável do tipo reference type como argumento para um método resulta em passar uma referência para o próprio objeto, e ele pode ser modificado.
Outra diferença fundamental é com relação a área de memória do programa que os tipos são guardados. Value Types são alocados na Stack, enquanto que Reference Types são guardados na Heap. 
Uma exceção à regra são as Strings. Strings são Reference Types, mesmo assim se comportam como Value Types. Isso é feito para facilitar o seu uso pelo Dev. 
Alguns objetos são Reference Types mas podem ter alguns métodos especiais, como [override do .Equals e do operador ==](./OverrideEquals/) para se comportarem como Value Types. Strings são esse tipo de objeto.

## Classes
- Objetos são instâncias de classes e são tipos de referência (reference types)

## Structs
- Variáveis do tipo Struct são Value Types

## Records
- Records são tipos especiais de classes que já tem o [override do .Equals e do operador ==](./OverrideEquals/)  feitos pelo compilador, sem a necessidade de ser feito pelo desenvolvedor. Isso garante que eles se comportem parcialmente como Value Types.

## Record Struct
- Tipos criados com as palavras chave `record` e `struct` ao mesmo tempo são tipos Value Types, alocados na Stack e ainda possuem o override do operador == já feito pelo compilador. Assim estruturas mais complexas podem se comportar como um simples int ou byte e o operador == é válido para comparar duas variáveis desse tipo. 


## Lembre-se
- atribuir, passar como argumento para um método ou retornar de um método um valor do tipo Value Type implica na cópia do valor
- atribuir, passar como argumento ou retornar um Reference Type significa passar uma referência para o objeto na memória
- Se um método altera um Value Type o valor alterado só é acessível dentro do método.
- Se um método altera um Reference Type o objeto original é alterado, e as alterações podem ser vistas fora do método.
- Strings são exceções a regra: elas são Reference Types por definição, mas se comportam como Value Types
- Value Types são alocados na Stack.
- Reference Types são alocados na Heap.


## Fontes
- [Value types (C# reference)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types)
- [ValueType Class](https://learn.microsoft.com/en-us/dotnet/api/system.valuetype?view=net-6.0)
- [Reference types (C# Reference)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types)
- [Types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types)

- [Reference Types X Value Types](http://www.linhadecodigo.com.br/artigo/2238/reference-types-e-sua-diferenca-para-value-types-em-csharp.aspx)
- [Reference Types X Value Types](https://www.albahari.com/valuevsreftypes.aspx)

- [Create record types](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records)
- [with expression (C# reference)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression)