namespace Aoxe.XmlConfiguration.UnitTest;

public class XmlTest
{
    [Fact]
    public void XmlStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddXmlStream(new MemoryStream(File.ReadAllBytes("./Test.xml")));
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("xmlApp", configuration["xmlApp:xmlName"]);
    }

    [Fact]
    public void XmlFileTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddXmlFile("./Test.xml");
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("xmlApp", configuration["xmlApp:xmlName"]);
    }
}
