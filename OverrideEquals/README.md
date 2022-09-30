
O Equals � virtual, significando que ele pode ser sobrescrito para implementar seu pr�prio mecanismo de igualdade. Mas voc� deve implementar Equals sempre junto com GetHashCode e com muito cuidado, pois ele pode ter impactos negativos em listas, ordena��o e distinct. 


### Modo correto de implementar Equals
- [Equals](https://docs.microsoft.com/en-us/dotnet/api/system.object.equals?view=net-6.0)