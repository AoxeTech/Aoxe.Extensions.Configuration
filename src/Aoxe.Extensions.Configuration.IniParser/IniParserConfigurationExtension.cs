﻿namespace Aoxe.Extensions.Configuration.IniParser;

public static class IniParserConfigurationExtension
{
    public static IConfigurationBuilder AddIniStream(
        this IConfigurationBuilder builder,
        Stream stream
    ) => builder.Add(new AoxeStreamConfigurationSource(new IniFlattener()) { Stream = stream });

    public static IConfigurationBuilder AddIniFile(
        this IConfigurationBuilder builder,
        string path,
        bool optional = false,
        bool reloadOnChange = false,
        int reloadDelay = 250,
        IFileProvider? fileProvider = null,
        Action<FileLoadExceptionContext>? onLoadException = null
    ) =>
        builder.Add(
            new AoxeFileConfigurationSource(new IniFlattener())
            {
                Path = path,
                Optional = optional,
                ReloadOnChange = reloadOnChange,
                ReloadDelay = reloadDelay,
                FileProvider = fileProvider,
                OnLoadException = onLoadException
            }
        );
}
