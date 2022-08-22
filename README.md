# Comparação de Objetos em C#
Enquanto a comparação de valores de variáveis primitivas como inteiros ou strings e value types como bytes e chars pode ser fácil, a comparação de dois objetos em uma linguagem cmo C# é difícil.
O .Net Framework vem com algumas soluções padrões para comparação de alguns objetos e estruturas distribuídos com o ambiente .Net, mas para todos os objetos feitos pelo desenvolvedor, existe o método Equals.
O método Equals vai retornar true se e somente se dois objetos são exatamente a mesma instância. 
O Equals é virtual, significando que ele pode ser sobrescrito para implementar seu próprio mecanismo de igualdade. Mas você deve implementar Equals sempre junto com GetHashCode e com muito cuidado, pois ele pode ter impactos negativos em listas, ordenação e distinct. 
Comparar as propriedades de um objeto mas não de suas listas ou objetos relacionados pode ser feito manualmente ou de várias outras formas. Nós chamamos essa comparação rasa de Shallow Compare.
Comparar tudo, inclusive comparar recursivamente os objetos e coleções associados a um objeto chamamos de Deep Compare. 


# Exemplo de Shallow Compare ou Comparação Rasa

## Problema: comparar se uma lista de objetos vindos de uma API ou Banco de Dados já contém um objeto "*SEMELHANTE*" a um objeto novo vindo de um formulário/tela/cadastro 

Para resolver esse problema você precisa saber se as propriedades, e apenas as propriedades do objeto são iguais. Você deve desprezar o Id, já que objetos do tipo Entidade tem sua "Identidade" (o Id) e ele vem preenchido do banco de dados, mas os objetos novos não tem o Id ou o mesmo é Zero.
Esse tipo de comparação, comparando apenas as propriedades é chamada de Shallow Compare ou Comparação Rasa.

## Problema: comparar se dois objetos do C# tem os mesmos valores

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
Usando o método Equals padrão também não funcionaria nesse contexto* 

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


Uma das maneiras de fazer isso é comparando as propriedades uma a uma. Outra maneira é usando reflection para comparar as propriedades e fornecer uma lista de propriedades a ignorar. 
Também existem as possibilidades das novas versões do C# de se usar Record Types ou Destructurers + Tuples para a comparação. E existe também a interface IEquatable, que te força a implementar o Equals corretamente.
No tutorial a seguir faremos em uma classe estática separadamente métodos para comparar objetos manualmente ou usando reflection. Você pode colocar esse código na sua classe que deseja comparar, ou em classes utilitárias do seu projeto. 





### Observações e Fontes
* É possível sobrecarregar o método Equals para verificar se dois objetos são iguais e até sobrecarregar o operador de igualdade, mas não é o caso nesse contexto. Não é disso que estamos falando agora. Geralmente para entidades que são persistidas em banco de dados fazemos o Equals baseado no Id. mas há uma forma correta de sobrecarregar o Equals, e se você sobrecarrega o Equals é obrigado a sobrecarregar o GetHashCode também. Fazer errado a sobrecarga desses dois métodos pode levar a consequências desastrosas como falhas em ordenação, comparação, violação de chaves primárias e falhas ao incluir, excluir ou juntar listas.
* Mais tarde veremos a implementação correta de Equals e GetHashCode.


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