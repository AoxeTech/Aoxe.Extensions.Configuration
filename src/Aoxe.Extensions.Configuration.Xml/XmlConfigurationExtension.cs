namespace Aoxe.Extensions.Configuration.Xml;

public static class XmlConfigurationExtension
{
    public static IConfigurationBuilder AddXmlStream(
        this IConfigurationBuilder builder,
        Stream stream
    ) => builder.Add(new AoxeStreamConfigurationSource(new XmlFlattener()) { Stream = stream });
}
