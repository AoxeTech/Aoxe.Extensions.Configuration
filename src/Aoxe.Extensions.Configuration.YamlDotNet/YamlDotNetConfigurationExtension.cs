namespace Aoxe.Extensions.Configuration.YamlDotNet;

public static class YamlDotNetConfigurationExtension
{
    public static IConfigurationBuilder AddYamlStream(
        this IConfigurationBuilder builder,
        Stream stream
    ) => builder.Add(new AoxeStreamConfigurationSource(new YamlFlattener()) { Stream = stream });

    public static IConfigurationBuilder AddYamlFile(
        this IConfigurationBuilder builder,
        string path,
        bool optional = false,
        bool reloadOnChange = false,
        int reloadDelay = 250,
        IFileProvider? fileProvider = null,
        Action<FileLoadExceptionContext>? onLoadException = null
    ) =>
        builder.Add(
            new AoxeFileConfigurationSource(new YamlFlattener())
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
