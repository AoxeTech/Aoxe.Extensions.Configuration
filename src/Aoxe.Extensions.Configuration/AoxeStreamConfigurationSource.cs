namespace Aoxe.Extensions.Configuration;

public class AoxeStreamConfigurationSource(IFlatten flatten) : StreamConfigurationSource
{
    public override IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new AoxeStreamConfigurationProvider(this, flatten);
}
