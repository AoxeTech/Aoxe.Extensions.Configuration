namespace Aoxe.Extensions.Configuration.Flattener.Xml;

public class XmlFlattener : IFlattener
{
    public Dictionary<string, string?> Flatten(Stream stream)
    {
        var result = new Dictionary<string, string?>();
        if (stream.IsNullOrEmpty())
            return result;
        var xmlDocument = XDocument.Load(stream);
        if (xmlDocument.Root is null)
            throw new XmlException("The XML document is empty or malformed.");
        Flatten(xmlDocument.Root, result, null);
        return result;
    }

    private static void Flatten(
        XElement element,
        Dictionary<string, string?> result,
        string? prefix
    )
    {
        element
            .Elements()
#if NETSTANDARD2_0
            .Where(p => p is not null)
#endif
            .ForEach(child =>
            {
                var key = Join(prefix, child!.Name.LocalName);
                if (child.HasElements)
                    Flatten(child, result, key);
                else
                    result[key] = child.Value;
            });
    }

    private static string Join(string? prefix, string name) =>
        string.IsNullOrEmpty(prefix) ? name : $"{prefix}:{name}";
}
