namespace Aoxe.Extensions.Configuration.Tomlet;

public static class TomletConfigurationExtension
{
    public static IConfigurationBuilder AddTomlStream(
        this IConfigurationBuilder builder,
        Stream stream
    ) => builder.Add(new AoxeStreamConfigurationSource(new TomlFlattener()) { Stream = stream });

    public static IConfigurationBuilder AddTomlFile(
        this IConfigurationBuilder builder,
        string path,
        bool optional = false,
        bool reloadOnChange = false,
        int reloadDelay = 250,
        IFileProvider? fileProvider = null,
        Action<FileLoadExceptionContext>? onLoadException = null
    ) =>
        builder.Add(
            new AoxeFileConfigurationSource(new TomlFlattener())
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
