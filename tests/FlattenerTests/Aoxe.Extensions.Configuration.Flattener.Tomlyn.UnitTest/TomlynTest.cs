﻿namespace Aoxe.Extensions.Configuration.Flattener.Tomlyn.UnitTest;

public class TomlynTest
{
    [Fact]
    public void TomlStreamTest()
    {
        Assert.Equal(
            "nestedStringValue",
            new TomlFlattener().Flatten(
                new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText("./Test.toml")))
            )["nestedObject:nestedStringKey"]
        );
    }

    [Fact]
    public void TomlEmptyStreamTest()
    {
        Assert.Empty(new TomlFlattener().Flatten(new MemoryStream()));
    }
}