namespace Aoxe.Extensions.Configuration.NewtonsoftJson;

public static class NewtonsoftJsonConfigurationExtension
{
    public static IConfigurationBuilder AddJsonStream(
        this IConfigurationBuilder builder,
        Stream stream
    ) => builder.Add(new AoxeStreamConfigurationSource(new JsonFlattener()) { Stream = stream });

    public static IConfigurationBuilder AddJsonFile(
        this IConfigurationBuilder builder,
        string path,
        bool optional = false
    ) =>
        builder.Add(
            new AoxeFileConfigurationSource(new JsonFlattener())
            {
                Path = path,
                Optional = optional
            }
        );
}
