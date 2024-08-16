namespace Aoxe.Extensions.Configuration.Flattener.Tomlet;

public class TomlFlattener : IFlattener
{
    public IDictionary<string, string?> Flatten(Stream stream)
    {
        var result = new Dictionary<string, string?>();
        if (stream.IsNullOrEmpty())
            return result;
        var toml = stream.ReadString(Encoding.UTF8).Replace("\uFEFF", string.Empty);
        var tomlTable = new TomlParser().Parse(toml);
        Flatten(tomlTable, result, null);
        return result;
    }

    private static void Flatten(TomlTable table, Dictionary<string, string?> result, string? prefix)
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
                    for (var i = 0; i < array.Count; i++)
                        if (array[i] is TomlTable tomlTable)
                            Flatten(tomlTable, result, Join(key, i.ToString()));
                    break;
                default:
                    result[key] = kvp.Value.ToString();
                    break;
            }
        }
    }

    private static string Join(string? prefix, string name) =>
        string.IsNullOrEmpty(prefix) ? name : $"{prefix}:{name}";
}
