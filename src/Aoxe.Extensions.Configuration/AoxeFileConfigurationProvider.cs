namespace Aoxe.Extensions.Configuration;

public class AoxeFileConfigurationProvider(AoxeFileConfigurationSource source, IFlattener flattener)
    : FileConfigurationProvider(source)
{
    public override void Load(Stream stream) => Data = flattener.Flatten(stream);
}
