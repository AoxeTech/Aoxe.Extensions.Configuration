namespace Aoxe.Extensions.Configuration.Tomlyn;

public static class TomlynConfigurationExtension
{
    public static IConfigurationBuilder AddTomlStream(
        this IConfigurationBuilder builder,
        Stream utf8Stream
    ) =>
        builder.Add(new AoxeStreamConfigurationSource(new TomlFlattener()) { Stream = utf8Stream });
}
