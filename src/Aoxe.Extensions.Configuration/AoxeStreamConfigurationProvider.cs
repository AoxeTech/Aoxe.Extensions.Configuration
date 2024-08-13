namespace Aoxe.Extensions.Configuration;

public class AoxeStreamConfigurationProvider(AoxeStreamConfigurationSource source, IFlatten flatten)
    : StreamConfigurationProvider(source)
{
    public override void Load(Stream stream) => Data = flatten.Flatten(stream);
}
