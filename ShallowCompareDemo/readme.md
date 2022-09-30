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
Confira a solution ShallowCompareDemo.sln, suas classes e testes.

### Forma 1 - comparação direta

### Forma 2 - com reflection

### Forma 3 - com destructurers + tuples