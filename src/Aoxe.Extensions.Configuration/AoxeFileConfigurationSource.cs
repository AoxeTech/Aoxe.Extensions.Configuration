namespace Aoxe.Extensions.Configuration;

public class AoxeFileConfigurationSource(IFlattener flattener) : FileConfigurationSource
{
    public override IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        EnsureDefaults(builder);
        return new AoxeFileConfigurationProvider(this, flattener);
    }
}
