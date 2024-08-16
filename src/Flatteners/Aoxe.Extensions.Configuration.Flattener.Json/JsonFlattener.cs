namespace Aoxe.Extensions.Configuration.Flattener.Json;

public class JsonFlattener : IFlattener
{
    public IDictionary<string, string?> Flatten(Stream stream) => JsonStreamProvider.Parse(stream);

    private sealed class JsonStreamProvider : JsonStreamConfigurationProvider
    {
        private JsonStreamProvider(JsonStreamConfigurationSource source)
            : base(source) { }

        internal static IDictionary<string, string?> Parse(Stream stream)
        {
            if (stream.IsNullOrEmpty())
                return new Dictionary<string, string?>();
            var provider = new JsonStreamProvider(
                new JsonStreamConfigurationSource { Stream = stream }
            );
            provider.Load();
            return provider.Data;
        }
    }
}
