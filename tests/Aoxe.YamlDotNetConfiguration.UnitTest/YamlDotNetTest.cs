namespace Aoxe.YamlDotNetConfiguration.UnitTest;

public class YamlDotNetTest
{
    [Fact]
    public void YamlStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddYamlStream(new MemoryStream(File.ReadAllBytes("./Test.yaml")));
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void YamlEmptyStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddYamlStream(new MemoryStream());
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Null(configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void YamlFileTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddYamlFile("./Test.yaml");
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }
}
