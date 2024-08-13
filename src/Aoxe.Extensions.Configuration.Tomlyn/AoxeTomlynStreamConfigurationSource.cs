namespace Aoxe.Extensions.Configuration.Tomlyn;

public class AoxeTomlynStreamConfigurationSource()
    : AoxeStreamConfigurationSource(new TomlFlattener());
