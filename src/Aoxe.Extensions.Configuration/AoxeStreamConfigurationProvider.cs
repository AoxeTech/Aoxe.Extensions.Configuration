namespace Aoxe.Extensions.Configuration;

public class AoxeStreamConfigurationProvider(
    AoxeStreamConfigurationSource source,
    IFlattener flattener
) : StreamConfigurationProvider(source)
{
    public override void Load(Stream stream) => Data = flattener.Flatten(stream);
}
