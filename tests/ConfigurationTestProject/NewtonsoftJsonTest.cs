namespace ConfigurationTestProject;

public class NewtonsoftJsonTest
{
    [Fact]
    public void JsonStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonStream(
            new MemoryStream(File.ReadAllBytes("./Files/Test.json"))
        );
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("JsonApp", configuration["jsonApp:jsonName"]);
    }
}
