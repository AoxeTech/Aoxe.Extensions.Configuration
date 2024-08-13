namespace Aoxe.Extensions.Configuration.IniParser;

public static class IniParserConfigurationExtension
{
    public static IConfigurationBuilder AddIniStream(
        this IConfigurationBuilder builder,
        Stream stream
    ) => builder.Add(new AoxeStreamConfigurationSource(new IniFlattener()) { Stream = stream });
}
