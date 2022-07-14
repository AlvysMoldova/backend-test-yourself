namespace Library.Extensions;

public static partial class ListExtensions
{
    public static B Fold<A, B>(this List<A> list, B initial, Func<B, A, B> folder)
    {
        foreach (var element in list)
            initial = folder(initial, element);

        return initial;
    }
}