namespace Aoxe.Extensions.Configuration.Flattener.Xml;

public class XmlFlattener : IFlattener
{
    public IDictionary<string, string?> Flatten(Stream stream) =>
        stream.IsNullOrEmpty()
            ? new Dictionary<string, string?>()
            : XmlStreamConfigurationProvider.Read(stream, XmlDocumentDecryptor.Instance);
}
