namespace Aoxe.Extensions.Configuration.Parser.Tomlyn;

public class TomlFlattener : IParser
{
    public Dictionary<string, string?> Flatten(Stream stream)
    {
        var ms = new MemoryStream();
        stream.CopyTo(ms);
        var bytes = ms.ToArray();
        var tomlTable = Toml.Parse(bytes).ToModel();
        var result = new Dictionary<string, string?>();
        Flatten(tomlTable, result, null);
        return result;
    }

    private void Flatten(TomlTable table, Dictionary<string, string?> result, string? prefix)
    {
        foreach (var kvp in table)
        {
            var key = Join(prefix, kvp.Key);
            switch (kvp.Value)
            {
                case TomlTable nestedTable:
                    Flatten(nestedTable, result, key);
                    break;
                case TomlArray array:
                {
                    for (var i = 0; i < array.Count; i++)
                    {
                        if (array[i] is TomlTable tomlTable)
                            Flatten(tomlTable, result, Join(key, i.ToString()));
                    }

                    break;
                }
                default:
                    result[key] = kvp.Value.ToString();
                    break;
            }
        }
    }

    private static string Join(string? prefix, string name)
    {
        return string.IsNullOrEmpty(prefix) ? name : $"{prefix}:{name}";
    }
}
