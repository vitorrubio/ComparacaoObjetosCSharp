using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShallowCompareDemo
{
    public static class ComparadorDeObjetos
    {

        /// <summary>
        /// compara manualmente se dois objetos Agendamento são iguais
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool SaoIguais(Agendamento a, Agendamento b)
        {
            return
                a.Inicio == b.Inicio
                && a.Fim == b.Fim
                && a.Nota == b.Nota
                && a.Total == b.Total
                && a.Observacao == b.Observacao;
        }


        /// <summary>
        /// compara via reflection se dois objetos Agendamento são iguais
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="ignoreProps"></param>
        /// <returns></returns>
        public static bool SaoIguaisUsandoReflection(Agendamento a, Agendamento b, params string[] ignoreProps)
        {
            //se os dois são null então ambos são iguais 
            if(a == null && b == null)
            {
                return true;
            }

            //se um dos dois são null então são diferentes
            if (a == null || b == null)
            {
                return false;
            }


            //se são a mesma referencia, retorna true e evita demais comparações
            if(object.ReferenceEquals(a,b))
            {
                return true;
            }

            //obtendo apenas as propriedades não ignoradas
            var propriedades = a.GetType().GetProperties().Where(x => x.CanRead && !ignoreProps.Contains(x.Name));

            foreach(var propriedade in propriedades)
            {
                //usando aqui o .Equals em vez do == porque se o valor estiver boxed (transformado em object) o == não funciona e retorna false (como se fosse reference type), o .Equals chama o Equals padrão do tipo
                if (!propriedade.GetValue(a).Equals( propriedade.GetValue(b)))
                {
                    return false;
                }
            }

            return true;

        }




        /// <summary>
        /// compara via reflection se dois objetos quaisquer são iguais por comparar as propriedades por nome
        /// se b não tiver as mesmas propriedades que A, retorna false
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="ignoreProps"></param>
        /// <returns></returns>
        public static bool ObjetosDiferentesSaoIguaisUsandoReflection(Object a, Object b, params string[] ignoreProps)
        {
            //se os dois são null então ambos são iguais 
            if(a == null && b == null)
            {
                return true;
            }

            //se um dos dois são null então são diferentes
            if (a == null || b == null)
            {
                return false;
            }

            //se são a mesma referencia, retorna true e evita demais comparações
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }

            //obtendo apenas as propriedades não ignoradas
            var nomesPropriedadesA = a.GetType().GetProperties().Where(x => x.CanRead && !ignoreProps.Contains(x.Name)).Select(p => p.Name);
            
            //var nomesPropriedadesB = b.GetType().GetProperties().Where(x => x.CanRead && !ignoreProps.Contains(x.Name)).Select(p => p.Name);
            // propriedadesComuns = nomesPropriedadesA.Intersect(nomesPropriedadesB).Distinct().ToList();
            //var propriedades = a.GetType().GetProperties().Where(x => propriedadesComuns.Contains(x.Name) );

            var propriedades = a.GetType().GetProperties().Where(x => x.CanRead && !ignoreProps.Contains(x.Name));

            foreach (var propriedade in propriedades)
            {
                //usando aqui o .Equals em vez do == porque se o valor estiver boxed (transformado em object) o == não funciona e retorna false (como se fosse reference type), o .Equals chama o Equals padrão do tipo
                if (!propriedade.GetValue(a).Equals( b.GetType().GetProperty(propriedade.Name)?.GetValue(b)))
                {
                    return false;
                }
            }

            return true;

        }


    }
}
