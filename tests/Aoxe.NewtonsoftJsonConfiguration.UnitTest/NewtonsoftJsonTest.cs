﻿namespace Aoxe.NewtonsoftJsonConfiguration.UnitTest;

public class NewtonsoftJsonTest
{
    [Fact]
    public void JsonStreamTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonStream(new MemoryStream(File.ReadAllBytes("./Test.json")));
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("JsonApp", configuration["jsonApp:jsonName"]);
    }

    [Fact]
    public void JsonFileTest()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile("./Test.json");
        IConfiguration configuration = configurationBuilder.Build();

        Assert.Equal("JsonApp", configuration["jsonApp:jsonName"]);
    }
}