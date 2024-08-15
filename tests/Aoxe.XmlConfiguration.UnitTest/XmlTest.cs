namespace Aoxe.XmlConfiguration.UnitTest;

public class XmlTest
{
    [Fact]
    public void XmlStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddXmlStream(new MemoryStream(File.ReadAllBytes("./Test.xml")));
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void XmlEmptyStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddXmlStream(new MemoryStream());
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Null(configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void XmlFileTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddXmlFile("./Test.xml");
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }
}
