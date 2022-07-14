using System.Collections.Generic;
using System.Linq;
using Library.Extensions;
using Xunit;

namespace Library.Tests.Unit;

public class MapTests
{
    [Fact]
    public void Increment()
    {
        var items = new List<int> { 1, 2, 3 };
        IEnumerable<int> mappedItems = items.Map(x => x + 1);

        Assert.Equal(2, mappedItems.ElementAt(0));
        Assert.Equal(3, mappedItems.ElementAt(1));
        Assert.Equal(4, mappedItems.ElementAt(2));
    }

    [Fact]
    public void Text()
    {
        var items = new List<string> { "1", "2", "3" };
        IEnumerable<string> mappedItems = items.Map(x => x.ToString());

        Assert.Equal("1", mappedItems.ElementAt(0));
        Assert.Equal("2", mappedItems.ElementAt(1));
        Assert.Equal("3", mappedItems.ElementAt(2));
    }
}