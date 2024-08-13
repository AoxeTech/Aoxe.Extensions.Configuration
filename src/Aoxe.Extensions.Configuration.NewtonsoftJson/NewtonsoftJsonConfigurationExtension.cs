namespace Aoxe.Extensions.Configuration.NewtonsoftJson;

public static class NewtonsoftJsonConfigurationExtension
{
    public static IConfigurationBuilder AddJsonStream(
        this IConfigurationBuilder builder,
        Stream stream
    ) => builder.Add(new AoxeStreamConfigurationSource(new JsonFlattener()) { Stream = stream });
}
