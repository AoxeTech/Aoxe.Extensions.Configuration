namespace Aoxe.Extensions.Configuration.YamlDotNet;

public static class YamlDotNetConfigurationExtension
{
    public static IConfigurationBuilder AddJsonStream(
        this IConfigurationBuilder builder,
        Stream stream
    ) => builder.Add(new AoxeStreamConfigurationSource(new YamlFlattener()) { Stream = stream });
}
