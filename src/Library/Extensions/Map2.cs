namespace Library.Extensions;

public static partial class ListExtensions
{
    public static List<B> Map2<A, B>(this List<A> list, Func<A, B> f)
    {
        return list.Fold(new List<B>(), (items, x) =>
        {
            items.Add(f(x));
            return items;
        });
    }
}