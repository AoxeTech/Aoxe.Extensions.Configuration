namespace Aoxe.Extensions.Configuration.Flattener.Xml.UnitTest;

public class XmlTest
{
    [Fact]
    public void XmlStreamTest()
    {
        Assert.Equal(
            "nestedStringValue",
            new XmlFlattener().Flatten(new MemoryStream(File.ReadAllBytes("./Test.xml")))[
                "nestedObject:nestedStringKey"
            ]
        );
    }

    [Fact]
    public void XmlEmptyStreamTest()
    {
        Assert.Empty(new XmlFlattener().Flatten(new MemoryStream()));
    }
}
