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

        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void TomlEmptyStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddTomlStream(new MemoryStream());
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Null(configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void TomlFileTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddTomlFile("./Test.toml");
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }
}
