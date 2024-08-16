namespace Aoxe.Extensions.Configuration.Flattener.Ini.UnitTest;

public class IniTest
{
    [Fact]
    public void IniStreamTest()
    {
        Assert.Equal(
            "nestedStringValue",
            new IniFlattener().Flatten(new MemoryStream(File.ReadAllBytes("./Test.ini")))[
                "nestedSection:nestedStringKey"
            ]
        );
    }

    [Fact]
    public void IniEmptyStreamTest()
    {
        Assert.Empty(new IniFlattener().Flatten(new MemoryStream()));
    }
}
