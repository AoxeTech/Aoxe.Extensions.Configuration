namespace Aoxe.Extensions.Configuration.Tomlyn;

public static class TomlynConfigurationExtension
{
    public static IConfigurationBuilder AddTomlStream(
        this IConfigurationBuilder builder,
        Stream stream
    ) => builder.Add(new AoxeStreamConfigurationSource(new TomlFlattener()) { Stream = stream });
}
