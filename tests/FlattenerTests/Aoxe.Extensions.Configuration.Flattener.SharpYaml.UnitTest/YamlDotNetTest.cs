namespace Aoxe.Extensions.Configuration.Flattener.SharpYaml.UnitTest;

public class YamlDotNetTest
{
    [Fact]
    public void YamlStreamTest()
    {
        Assert.Equal(
            "nestedStringValue",
            new YamlFlattener().Flatten(new MemoryStream(File.ReadAllBytes("./Test.yaml")))[
                "nestedObject:nestedStringKey"
            ]
        );
    }

    [Fact]
    public void YamlEmptyStreamTest()
    {
        Assert.Empty(new YamlFlattener().Flatten(new MemoryStream()));
    }
}
