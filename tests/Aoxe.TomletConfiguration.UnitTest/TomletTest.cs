namespace Aoxe.TomletConfiguration.UnitTest;

public class TomletTest
{
    [Fact]
    public void TomlStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddTomlStream(
            new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText("./Test.toml")))
        );
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("TomlMyApp", configuration["tomlgeneral:tomlappname"]);
    }

    [Fact]
    public void TomlFileTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddTomlFile("./Test.toml");
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("TomlMyApp", configuration["tomlgeneral:tomlappname"]);
    }
}
