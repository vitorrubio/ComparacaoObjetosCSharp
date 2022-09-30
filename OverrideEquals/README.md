
O Equals é virtual, significando que ele pode ser sobrescrito para implementar seu próprio mecanismo de igualdade. Mas você deve implementar Equals sempre junto com GetHashCode e com muito cuidado, pois ele pode ter impactos negativos em listas, ordenação e distinct. 


### Modo correto de implementar Equals
- [Equals](https://docs.microsoft.com/en-us/dotnet/api/system.object.equals?view=net-6.0)