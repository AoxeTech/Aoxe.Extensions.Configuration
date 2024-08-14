namespace Aoxe.Extensions.Configuration.Xml;

public static class XmlConfigurationExtension
{
    public static IConfigurationBuilder AddXmlStream(
        this IConfigurationBuilder builder,
        Stream stream
    ) => builder.Add(new AoxeStreamConfigurationSource(new XmlFlattener()) { Stream = stream });

    public static IConfigurationBuilder AddXmlFile(
        this IConfigurationBuilder builder,
        string path,
        bool optional = false
    ) =>
        builder.Add(
            new AoxeFileConfigurationSource(new XmlFlattener()) { Path = path, Optional = optional }
        );
}
