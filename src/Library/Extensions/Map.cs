namespace Library.Extensions;

public static partial class ListExtensions
{
    public static IEnumerable<B> Map<A, B>(this List<A> list, Func<A, B> f)
    {
        foreach (A item in list)
            yield return f(item);
    }
}