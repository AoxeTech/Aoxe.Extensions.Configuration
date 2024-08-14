﻿namespace Aoxe.Extensions.Configuration.YamlDotNet;

public static class YamlDotNetConfigurationExtension
{
    public static IConfigurationBuilder AddYamlStream(
        this IConfigurationBuilder builder,
        Stream stream
    ) => builder.Add(new AoxeStreamConfigurationSource(new YamlFlattener()) { Stream = stream });

    public static IConfigurationBuilder AddYamlFile(
        this IConfigurationBuilder builder,
        string path,
        bool optional = false
    ) =>
        builder.Add(
            new AoxeFileConfigurationSource(new YamlFlattener())
            {
                Path = path,
                Optional = optional
            }
        );
}