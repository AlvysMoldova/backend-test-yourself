using System;
using System.Collections.Generic;

namespace backend_test_yourself
{
    internal class Program
    {
        public static List<B> Map<A, B>(List<A> list, Func<A, B> f)
        {
            var result = new List<B>();

            foreach (var element in list)
            {
                result.Add(f(element));
            }

            return result;
        }

        public static B Fold<A, B>(List<A> list, B initial, Func<B, A, B> folder)
        {
            foreach (var element in list)
            {
                initial = folder(initial, element);
            }

            return initial;
        }

        public static List<B> Map2<A, B>(List<A> list, Func<A, B> f)
        {
            var result = Fold(list, new List<B>(), (newArray, x) =>
            {
                newArray.Add(f(x));
                return newArray;
            });

            return result;
        }

        public static void Main(string[] args)
        {
            var list = new List<int>() {1,2,3};

            var results1 = Map(list, x => x + 1);
            var results2 = Fold(list, "", (str,x) => str + x.ToString());
            var results3 = Map2(list, x => x.ToString());

        } 
    }
}