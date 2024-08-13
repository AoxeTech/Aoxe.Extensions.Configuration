namespace Aoxe.Extensions.Configuration.YamlDotNet;

public class AoxeYamlDotNetStreamConfigurationSource()
    : AoxeStreamConfigurationSource(new YamlFlattener());
