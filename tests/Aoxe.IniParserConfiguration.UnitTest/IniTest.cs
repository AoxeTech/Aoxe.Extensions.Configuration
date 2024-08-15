namespace Aoxe.IniParserConfiguration.UnitTest;

public class IniTest
{
    [Fact]
    public void IniStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddIniStream(new MemoryStream(File.ReadAllBytes("./Test.ini")));
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nestedStringValue", configuration["nestedSection:nestedStringKey"]);
    }

    [Fact]
    public void IniEmptyStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddIniStream(new MemoryStream());
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Null(configuration["nestedSection:nestedStringKey"]);
    }

    [Fact]
    public void IniFileTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddIniFile("./Test.ini");
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nestedStringValue", configuration["nestedSection:nestedStringKey"]);
    }
}
