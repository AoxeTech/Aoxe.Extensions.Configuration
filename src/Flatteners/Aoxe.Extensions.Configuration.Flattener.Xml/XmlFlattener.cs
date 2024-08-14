namespace Aoxe.Extensions.Configuration.Flattener.Xml;

public class XmlFlattener : IFlattener
{
    public Dictionary<string, string?> Flatten(Stream stream)
    {
        var xmlDocument = XDocument.Load(stream);
        if (xmlDocument.Root is null)
            throw new XmlException("The XML document is empty or malformed.");
        var result = new Dictionary<string, string?>();
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
            .Where(p => p is not null)
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
