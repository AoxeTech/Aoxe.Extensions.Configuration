namespace ConfigurationTestProject;

public class IniTest
{
    [Fact]
    public void IniStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddIniStream(new MemoryStream(File.ReadAllBytes("./Files/Test.ini")));
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("IniMyApp", configuration["IniGeneral:IniAppname"]);
    }
}
