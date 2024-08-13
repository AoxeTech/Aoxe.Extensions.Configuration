using System.Text;

namespace ConfigurationTestProject;

public class TomlynTest
{
    [Fact]
    public void TomlStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddTomlStream(
            new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText("./Files/Test.toml")))
        );
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("TomlMyApp", configuration["tomlgeneral:tomlappname"]);
    }
}
