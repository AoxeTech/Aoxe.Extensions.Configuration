namespace Aoxe.IniParserConfiguration.UnitTest;

public class IniTest
{
    [Fact]
    public void IniStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddIniStream(new MemoryStream(File.ReadAllBytes("./Test.ini")));
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("IniMyApp", configuration["IniGeneral:IniAppname"]);
    }

    [Fact]
    public void IniEmptyStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddIniStream(new MemoryStream());
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Null(configuration["IniGeneral:IniAppname"]);
    }

    [Fact]
    public void IniFileTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddIniFile("./Test.ini");
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("IniMyApp", configuration["IniGeneral:IniAppname"]);
    }
}
