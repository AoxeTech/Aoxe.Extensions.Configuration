namespace Aoxe.NewtonsoftJsonConfiguration.UnitTest;

public class NewtonsoftJsonTest
{
    [Fact]
    public void JsonStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonStream(new MemoryStream(File.ReadAllBytes("./Test.json")));
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void JsonEmptyStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonStream(new MemoryStream());
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Null(configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void JsonFileTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile("./Test.json");
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }
}
