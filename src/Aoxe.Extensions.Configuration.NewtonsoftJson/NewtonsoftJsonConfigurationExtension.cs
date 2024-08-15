namespace Aoxe.Extensions.Configuration.NewtonsoftJson;

public static class NewtonsoftJsonConfigurationExtension
{
    public static IConfigurationBuilder AddJsonStream(
        this IConfigurationBuilder builder,
        Stream stream,
        JsonSerializerSettings? jsonSerializerSettings = null
    ) =>
        builder.Add(
            new AoxeStreamConfigurationSource(new JsonFlattener(jsonSerializerSettings))
            {
                Stream = stream
            }
        );

    public static IConfigurationBuilder AddJsonFile(
        this IConfigurationBuilder builder,
        string path,
        JsonSerializerSettings? jsonSerializerSettings = null,
        bool optional = false,
        bool reloadOnChange = false,
        int reloadDelay = 250,
        IFileProvider? fileProvider = null,
        Action<FileLoadExceptionContext>? onLoadException = null
    ) =>
        builder.Add(
            new AoxeFileConfigurationSource(new JsonFlattener(jsonSerializerSettings))
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
