namespace Aoxe.Extensions.Configuration.Flattener.NewtonsoftJson;

public class JsonFlattener(JsonSerializerSettings? jsonSerializerSettings = null) : IFlattener
{
    public Dictionary<string, string?> Flatten(Stream stream)
    {
        var result = new Dictionary<string, string?>();
        if (stream.IsNullOrEmpty())
            return result;
        var data = JsonSerializer
            .Create(jsonSerializerSettings)
            .Deserialize(new StreamReader(stream), typeof(JObject));
        if (data is null)
            return result;
        var jsonObject = (JObject)data;
        Flatten(jsonObject, result, null);
        return result;
    }

    private static void Flatten(JToken token, Dictionary<string, string?> result, string? prefix)
    {
        switch (token)
        {
            case JObject obj:
                foreach (var property in obj.Properties())
                    Flatten(property.Value, result, Join(prefix, property.Name));
                break;
            case JArray array:
                for (var i = 0; i < array.Count; i++)
                    Flatten(array[i], result, Join(prefix, i.ToString()));
                break;
            default:
                if (!prefix.IsNullOrWhiteSpace())
                    result[prefix!] = token.ToString();
                break;
        }
    }

    private static string Join(string? prefix, string name) =>
        string.IsNullOrEmpty(prefix) ? name : $"{prefix}:{name}";
}
