using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            TestProblem1();
            TestProblem2();
            TestProblem3();

            Console.ReadLine();
        }

        static List<B> Map<A, B>(List<A> list, Func<A, B> f) {
            if (list == null) { 
                throw new ArgumentNullException("list");
            }
            if (f == null) { 
                throw new ArgumentNullException("null");
            }
            List<B> result = new List<B>();
            list.ForEach(v => result.Add(f(v)));
            return result;
        }

        static B Fold<A, B>(List<A> list, B initial, Func<B, A, B> folder)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            if (initial == null)
            {
                throw new ArgumentNullException("initial");
            }
            if (folder == null)
            {
                throw new ArgumentNullException("folder");
            }
            B state = initial;
            list.ForEach(v => { state = folder(state, v); });
            return state;
        }

        static List<B> Map2<A, B>(List<A> list, Func<A, B> f)
        {
            if (f == null)
            {
                throw new ArgumentNullException("f");
            }
            List<B> result = new List<B>();
            Fold(list, result, (List<B> s, A v) => { s.Add(f(v)); return s; });
            return result;
        }


        //===================================================================================================
        static void TestProblem1()
        {
            List<int> ints = new List<int>() { 1, 2, 3 };
            List<String> result = Map<int, String>(ints, x => x + "A");

            PrintFormatedResult(1, ints, result, "x => x + \"A\"");

            List<char> chars = new List<char>() { 'A', 'B', 'C' };
            List<int> result1 = Map<char, int>(chars, x => (int)x);

            PrintFormatedResult(1, chars, result1, "x => (int)x");
        }

        static void TestProblem2()
        {
            List<int> ints = new List<int>() { 1, 2, 3 };
            String result = Fold<int, String>(ints, "", (s, n) => s + n.ToString() + "_");

            PrintFormatedResult(2, ints, new List<String>() { result }, "(s, n) => s + n.ToString() + \"_\"");
        }

        static void TestProblem3()
        {
            List<int> ints = new List<int>() { 1, 2, 3 };
            List<int> result = Map2(ints, x => x*x );

            PrintFormatedResult(3, ints, result, "x => x*x");
        }

        static void PrintFormatedResult<A, B>(int idx, List<A> input, List<B> output, String descr)
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("Problem" + idx);
            Console.WriteLine("Param func: " + descr);
            Console.Write("Input: ");
            input.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.Write("Output: ");
            output.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }


    }

}
