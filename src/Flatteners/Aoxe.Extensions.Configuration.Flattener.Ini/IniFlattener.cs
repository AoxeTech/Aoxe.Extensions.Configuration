namespace Aoxe.Extensions.Configuration.Flattener.Ini;

public class IniFlattener : IFlattener
{
    public IDictionary<string, string?> Flatten(Stream stream) =>
        IniStreamConfigurationProvider.Read(stream);
}
