namespace ConfigurationTestProject;

public class XmlTest
{
    [Fact]
    public void XmlStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddXmlStream(new MemoryStream(File.ReadAllBytes("./Files/Test.xml")));
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("xmlApp", configuration["xmlApp:xmlName"]);
    }
}
