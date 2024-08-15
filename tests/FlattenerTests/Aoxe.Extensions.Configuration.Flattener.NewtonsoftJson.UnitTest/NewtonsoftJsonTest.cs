namespace Aoxe.Extensions.Configuration.Flattener.NewtonsoftJson.UnitTest;

public class NewtonsoftJsonTest
{
    [Fact]
    public void JsonStreamTest()
    {
        Assert.Equal(
            "nestedStringValue",
            new JsonFlattener().Flatten(new MemoryStream(File.ReadAllBytes("./Test.json")))[
                "nestedObject:nestedStringKey"
            ]
        );
    }

    [Fact]
    public void JsonEmptyStreamTest()
    {
        Assert.Empty(new JsonFlattener().Flatten(new MemoryStream()));
    }
}
