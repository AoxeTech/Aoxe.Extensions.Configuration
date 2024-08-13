namespace Aoxe.Extensions.Configuration;

public class AoxeStreamConfigurationSource(IFlattener flattener) : StreamConfigurationSource
{
    public override IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new AoxeStreamConfigurationProvider(this, flattener);
}
