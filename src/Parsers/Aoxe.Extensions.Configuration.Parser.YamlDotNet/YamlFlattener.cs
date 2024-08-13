namespace Aoxe.Extensions.Configuration.Parser.YamlDotNet;

public class YamlFlattener : IParser
{
    public Dictionary<string, string?> Flatten(Stream stream)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        var ms = new MemoryStream();
        stream.CopyTo(ms);
        var bytes = ms.ToArray();
        var yamlObject = deserializer.Deserialize<Dictionary<object, object?>>(
            Encoding.UTF8.GetString(bytes)
        );
        var result = new Dictionary<string, string?>();
        Flatten(yamlObject, result, null);
        return result;
    }

    private void Flatten(
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
                {
                    for (var i = 0; i < list.Count; i++)
                    {
                        if (list[i] is Dictionary<object, object?> listItem)
                        {
                            Flatten(listItem, result, Join(key, i.ToString()));
                        }
                        else
                        {
                            result[Join(key, i.ToString())] = list[i].ToString();
                        }
                    }

                    break;
                }
                default:
                    result[key] = kvp.Value is null ? string.Empty : kvp.Value.ToString();
                    break;
            }
        }
    }

    private static string Join(string? prefix, string name)
    {
        return string.IsNullOrEmpty(prefix) ? name : $"{prefix}:{name}";
    }
}
