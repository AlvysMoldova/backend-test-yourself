namespace ConsoleApp
{
    class Program
    {
        public static void Main()
        {
            var list = new List<int>() { 1, 2, 3 };

            var result1 = Map(list, x => x + 1);

            var result2 = Fold(list, "", (sum, x) => sum + x.ToString());

            var result3 = Map2(list, x => x + 1);
        }

        public static List<B> Map<A, B>(List<A> list, Func<A, B> f)
        {
            var result = new List<B>(list.Count);

            foreach (var item in list)
            {
                result.Add(f(item));
            }

            return result;
        }

        public static B Fold<A, B>(List<A> list, B initial, Func<B, A, B> folder)
        {
            foreach (var item in list)
            {
                initial = folder(initial, item);
            }

            return initial;
        }

        public static List<B> Map2<A, B>(List<A> list, Func<A, B> f)
        {
            var result = new List<B>(list.Count);

            Fold(list, result, (r, i) =>
            {
                r.Add(f(i));
                return r;
            });

            return result;
        }
    }
}