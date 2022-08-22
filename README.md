# Compara��o de Objetos em C#
Enquanto a compara��o de valores de vari�veis primitivas como inteiros ou strings e value types como bytes e chars pode ser f�cil, a compara��o de dois objetos em uma linguagem cmo C# � dif�cil.
O .Net Framework vem com algumas solu��es padr�es para compara��o de alguns objetos e estruturas distribu�dos com o ambiente .Net, mas para todos os objetos feitos pelo desenvolvedor, existe o m�todo Equals.
O m�todo Equals vai retornar true se e somente se dois objetos s�o exatamente a mesma inst�ncia. 
O Equals � virtual, significando que ele pode ser sobrescrito para implementar seu pr�prio mecanismo de igualdade. Mas voc� deve implementar Equals sempre junto com GetHashCode e com muito cuidado, pois ele pode ter impactos negativos em listas, ordena��o e distinct. 
Comparar as propriedades de um objeto mas n�o de suas listas ou objetos relacionados pode ser feito manualmente ou de v�rias outras formas. N�s chamamos essa compara��o rasa de Shallow Compare.
Comparar tudo, inclusive comparar recursivamente os objetos e cole��es associados a um objeto chamamos de Deep Compare. 


# Exemplo de Shallow Compare ou Compara��o Rasa

## Problema: comparar se uma lista de objetos vindos de uma API ou Banco de Dados j� cont�m um objeto "*SEMELHANTE*" a um objeto novo vindo de um formul�rio/tela/cadastro 

Para resolver esse problema voc� precisa saber se as propriedades, e apenas as propriedades do objeto s�o iguais. Voc� deve desprezar o Id, j� que objetos do tipo Entidade tem sua "Identidade" (o Id) e ele vem preenchido do banco de dados, mas os objetos novos n�o tem o Id ou o mesmo � Zero.
Esse tipo de compara��o, comparando apenas as propriedades � chamada de Shallow Compare ou Compara��o Rasa.

## Problema: comparar se dois objetos do C# tem os mesmos valores

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
Usando o m�todo Equals padr�o tamb�m n�o funcionaria nesse contexto* 

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


Uma das maneiras de fazer isso � comparando as propriedades uma a uma. Outra maneira � usando reflection para comparar as propriedades e fornecer uma lista de propriedades a ignorar. 
Tamb�m existem as possibilidades das novas vers�es do C# de se usar Record Types ou Destructurers + Tuples para a compara��o. E existe tamb�m a interface IEquatable, que te for�a a implementar o Equals corretamente.
No tutorial a seguir faremos em uma classe est�tica separadamente m�todos para comparar objetos manualmente ou usando reflection. Voc� pode colocar esse c�digo na sua classe que deseja comparar, ou em classes utilit�rias do seu projeto. 





### Observa��es e Fontes
* � poss�vel sobrecarregar o m�todo Equals para verificar se dois objetos s�o iguais e at� sobrecarregar o operador de igualdade, mas n�o � o caso nesse contexto. N�o � disso que estamos falando agora. Geralmente para entidades que s�o persistidas em banco de dados fazemos o Equals baseado no Id. mas h� uma forma correta de sobrecarregar o Equals, e se voc� sobrecarrega o Equals � obrigado a sobrecarregar o GetHashCode tamb�m. Fazer errado a sobrecarga desses dois m�todos pode levar a consequ�ncias desastrosas como falhas em ordena��o, compara��o, viola��o de chaves prim�rias e falhas ao incluir, excluir ou juntar listas.
* Mais tarde veremos a implementa��o correta de Equals e GetHashCode.


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


### Modo correto de implementar Equals
- [Equals](https://docs.microsoft.com/en-us/dotnet/api/system.object.equals?view=net-6.0)