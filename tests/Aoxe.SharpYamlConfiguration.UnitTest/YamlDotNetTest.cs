namespace Aoxe.SharpYamlConfiguration.UnitTest;

public class YamlDotNetTest
{
    [Fact]
    public void YamlStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddYamlStream(new MemoryStream(File.ReadAllBytes("./Test.yaml")));
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nginx:latest", configuration["yamlServices:web:image"]);
    }

    [Fact]
    public void YamlEmptyStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddYamlStream(new MemoryStream());
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Null(configuration["yamlServices:web:image"]);
    }

    [Fact]
    public void YamlFileTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddYamlFile("./Test.yaml");
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nginx:latest", configuration["yamlServices:web:image"]);
    }
}
