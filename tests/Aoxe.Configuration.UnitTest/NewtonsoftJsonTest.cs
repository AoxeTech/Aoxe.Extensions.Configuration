namespace Aoxe.Configuration.UnitTest;

public class NewtonsoftJsonTest
{
    [Fact]
    public void JsonStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.Add(
            new AoxeStreamConfigurationSource(new JsonFlattener())
            {
                Stream = new MemoryStream(File.ReadAllBytes("./Test.json"))
            }
        );
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void JsonEmptyStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.Add(
            new AoxeStreamConfigurationSource(new JsonFlattener()) { Stream = new MemoryStream() }
        );
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Null(configuration["nestedStringValue"]);
    }

    [Fact]
    public void JsonFileTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.Add(
            new AoxeFileConfigurationSource(new JsonFlattener()) { Path = "./Test.json" }
        );
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }
}
