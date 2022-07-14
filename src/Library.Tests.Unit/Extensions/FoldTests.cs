using System.Collections.Generic;
using Library.Extensions;
using Xunit;

namespace Library.Tests.Unit;

public class FoldTests
{
    [Fact]
    public void Sum()
    {
        var items = new List<int> { 1, 2, 3 };
        int result = items.Fold(0, (sum, x) => sum + x);

        Assert.Equal(result, 6);
    }

    [Fact]
    public void Concat()
    {
        var items = new List<int> { 1, 2, 3 };
        string result = items.Fold("", (str, x) => str + x.ToString());

        Assert.Equal(result, "123");
    }
}