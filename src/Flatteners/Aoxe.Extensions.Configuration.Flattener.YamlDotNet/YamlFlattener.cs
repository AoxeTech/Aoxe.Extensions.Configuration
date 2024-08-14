namespace Aoxe.Extensions.Configuration.Flattener.YamlDotNet;

public class YamlFlattener : IFlattener
{
    public Dictionary<string, string?> Flatten(Stream stream)
    {
        var result = new Dictionary<string, string?>();
        if (stream.IsNullOrEmpty())
            return result;
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        var yamlObject = deserializer.Deserialize<Dictionary<object, object?>>(
            stream.ReadString(Encoding.UTF8)
        );
        Flatten(yamlObject, result, null);
        return result;
    }

    private static void Flatten(
        Dictionary<object, object?> dictionary,
        Dictionary<string, string?> result,
        string? prefix
    )
    {
        foreach (var kvp in dictionary)
        {
            var name = kvp.Key.ToString();
            if (string.IsNullOrWhiteSpace(name))
                continue;
            var key = Join(prefix, name);
            switch (kvp.Value)
            {
                case Dictionary<object, object?> nestedDictionary:
                    Flatten(nestedDictionary, result, key);
                    break;
                case IList<object> list:
                    for (var i = 0; i < list.Count; i++)
                        if (list[i] is Dictionary<object, object?> listItem)
                            Flatten(listItem, result, Join(key, i.ToString()));
                        else
                            result[Join(key, i.ToString())] = list[i].ToString();
                    break;
                default:
                    result[key] = kvp.Value is null ? string.Empty : kvp.Value.ToString();
                    break;
            }
        }
    }

    private static string Join(string? prefix, string name) =>
        string.IsNullOrEmpty(prefix) ? name : $"{prefix}:{name}";
}
