namespace ConfigurationTestProject;

public class YamlDotNetTest
{
    [Fact]
    public void YamlStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddYamlStream(
            new MemoryStream(File.ReadAllBytes("./Files/Test.yaml"))
        );
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nginx:latest", configuration["yamlServices:web:image"]);
    }
}
