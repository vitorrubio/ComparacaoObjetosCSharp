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
Confira a solution ShallowCompareDemo.sln, suas classes e testes.

### Forma 1 - compara��o direta

### Forma 2 - com reflection

### Forma 3 - com destructurers + tuples